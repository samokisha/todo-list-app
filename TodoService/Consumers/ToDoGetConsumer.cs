using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Data.Entities;

namespace TodoService.Consumers;
public class ToDoGetConsumer : IConsumer<ToDoItem>
{
    readonly ILogger<ToDoGetConsumer> _logger;
    public ToDoGetConsumer(ILogger<ToDoGetConsumer> logger)
    {
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }
    public async Task Consume(ConsumeContext<ToDoItem> context)
    {
        _logger.LogInformation("Got task: {Text}", context.Message.Name);
        await Task.CompletedTask;
    }
}
