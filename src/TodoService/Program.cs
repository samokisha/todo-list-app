using MassTransit;
using Microsoft.EntityFrameworkCore;
using TodoService;
using TodoService.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<ToDoContext>(builder => builder.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ToDoGetConsumer>();
            x.AddConsumer<ToDoPostConsumer>();
            x.AddConsumer<ToDoDeleteConsumer>();
            x.AddConsumer<ToDoPutConsumer>();

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq://localhost");
                configurator.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();
