using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{

    x.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("rabbitMQ");
        configurator.ConfigureEndpoints(context);
    });

    x.AddRequestClient<ToDoCreateRequestModel>(
        new Uri("exchange:post-consumer"));

    x.AddRequestClient<ToDoReadRequestModel>(
        new Uri("exchange:get-consumer"));

    x.AddRequestClient<ToDoUpdateRequestModel>(
        new Uri("exchange:put-consumer"));

    x.AddRequestClient<ToDoDeleteRequestModel>(
        new Uri("exchange:delete-consumer"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
