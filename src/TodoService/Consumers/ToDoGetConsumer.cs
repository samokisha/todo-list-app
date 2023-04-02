using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoGetConsumer : IConsumer<ToDoReadRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public ToDoGetConsumer(ToDoManager toDoManager)
    {
        _toDoManager = toDoManager;
    }
    public async Task Consume(ConsumeContext<ToDoReadRequestModel> context)
    {
        var result = await _toDoManager.GetAsync(context.Message, context.CancellationToken);
        await context.RespondAsync<ToDoItemResponseModel>(new ToDoItemResponseModel
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description,
            IsDone = result.IsDone
        });
    }
}
