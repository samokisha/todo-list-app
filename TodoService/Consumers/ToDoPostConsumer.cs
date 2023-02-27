using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Data.Entities;

namespace TodoService.Consumers;
public class ToDoPostConsumer : IConsumer<ToDoItem>
{
    readonly ILogger<ToDoPostConsumer> _logger;

    public ToDoPostConsumer(ILogger<ToDoPostConsumer> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task Consume(ConsumeContext<ToDoItem> context)
    {
        _logger.LogInformation("Added task: {Text}", context.Message.Name);
        await Task.CompletedTask;
    }
}
