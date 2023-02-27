using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Data.Entities;

namespace TodoService.Consumers;
public class ToDoPutConsumer : IConsumer<ToDoItem>
{
    readonly ILogger<ToDoPutConsumer> _logger;

    public ToDoPutConsumer(ILogger<ToDoPutConsumer> logger)
    {
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }
    public async Task Consume(ConsumeContext<ToDoItem> context)
    {
        _logger.LogInformation("Updated task: {Text}", context.Message.Name);
        await Task.CompletedTask;
    }
}
