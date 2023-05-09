using MassTransit;
using Microsoft.EntityFrameworkCore;
using TodoService;
using TodoService.Consumers;
using TodoService.Managers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");

        services.AddDbContext<ToDoContext>(builder => builder.UseSqlServer(connectionString));

        services.AddScoped<ToDoManager>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<ToDoGetConsumer>();

            x.AddConsumer<ToDoPostConsumer>();

            x.AddConsumer<ToDoDeleteConsumer>();

            x.AddConsumer<ToDoPutConsumer>();

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq://rabbitmq");
                configurator.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();
