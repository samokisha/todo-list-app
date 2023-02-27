using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using TodoService;
using TodoService.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<ToDoContext>(builder => builder.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

    })
    .Build();

await host.RunAsync();

IServiceCollection services = new ServiceCollection();
services.AddMassTransit(x =>
{
    x.AddConsumer<ToDoGetConsumer>();
    x.AddConsumer<ToDoPostConsumer>();
    x.AddConsumer<ToDoDeleteConsumer>();
    x.AddConsumer<ToDoPutConsumer>();

    x.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("RabbitMQ");
        configurator.ConfigureEndpoints(context);
    });
});

//Добавить хост и подклчюение к контексту базы данных 
//пример https://github.com/samokisha/GuestBook/blob/master/StorageService/Program.cs
//services.AddDbContext<GuestBookContext>(
//                        builder =>
//                            builder.UseSqlServer(hostContext.Configuration.GetConnectionString("GuestBook"))
//                    );



