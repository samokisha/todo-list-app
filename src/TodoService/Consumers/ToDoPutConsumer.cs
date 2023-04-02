using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoPutConsumer : IConsumer<ToDoUpdateRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public ToDoPutConsumer(ToDoManager toDoManager)
    {
        _toDoManager = toDoManager;
    }

    public async Task Consume(ConsumeContext<ToDoUpdateRequestModel> context)
    {
        var result = await _toDoManager.PutAsync(context.Message, context.CancellationToken);
        await context.RespondAsync(new ToDoItemResponseModel
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description,
            IsDone = result.IsDone
        });

    }
}
