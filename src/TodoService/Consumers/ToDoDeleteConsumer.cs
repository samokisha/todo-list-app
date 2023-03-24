using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoDeleteConsumer : IConsumer<ToDoDeleteRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public async Task Consume(ConsumeContext<ToDoDeleteRequestModel> context)
    {
        await _toDoManager.DeleteAsync((ToDoDeleteRequestModel)context, context.CancellationToken);
        await context.RespondAsync<ToDoDeleteResponseModel>(new ToDoDeleteResponseModel()
        {
            Id = context.Message.Id
        });
    }
}
