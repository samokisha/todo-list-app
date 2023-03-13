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
            x.AddConsumer<ToDoGetConsumer>()
                .Endpoint(e => e.Name = "get-consumer");

            x.AddConsumer<ToDoPostConsumer>()
                .Endpoint(e => e.Name = "post-consumer");

            x.AddConsumer<ToDoDeleteConsumer>()
                .Endpoint(e => e.Name = "delete-consumer");

            x.AddConsumer<ToDoPutConsumer>()
                .Endpoint(e => e.Name = "update-consumer");

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitMQ");
                configurator.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();
