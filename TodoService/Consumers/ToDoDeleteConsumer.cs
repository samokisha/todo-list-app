using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.Data.Entities;

namespace TodoService.Consumers;
public class ToDoDeleteConsumer : IConsumer<ToDoItem>
{

    readonly ILogger<ToDoDeleteConsumer> _logger;

    public ToDoDeleteConsumer(ILogger<ToDoDeleteConsumer> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task Consume(ConsumeContext<ToDoItem> context)
    {
        _logger.LogInformation("Deleted task: {Text}", context.Message.Name);
        await Task.CompletedTask;
    }
}
