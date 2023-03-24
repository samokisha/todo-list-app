using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoGetConsumer : IConsumer<ToDoReadRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public async Task Consume(ConsumeContext<ToDoReadRequestModel> context)
    {
        await _toDoManager.GetAsync((ToDoReadRequestModel)context, context.CancellationToken);
        await context.RespondAsync<ToDoItemResponseModel>(new ToDoItemResponseModel()
        {
            Id = context.Message.Id
        });
    }
}
