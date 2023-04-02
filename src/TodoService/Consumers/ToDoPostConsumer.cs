using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoPostConsumer : IConsumer<ToDoCreateRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public ToDoPostConsumer(ToDoManager toDoManager)
    {
        _toDoManager = toDoManager;
    }
    public async Task Consume(ConsumeContext<ToDoCreateRequestModel> context)
    {
        var result = await _toDoManager.PostAsync(context.Message, context.CancellationToken);
        await context.RespondAsync(new ToDoItemResponseModel
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description,
            IsDone = result.IsDone
        });
    }
}
