using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoDeleteConsumer : IConsumer<ToDoDeleteRequestModel>
{
    private readonly ToDoManager _toDoManager;

    public ToDoDeleteConsumer(ToDoManager toDoManager)
    {
        _toDoManager = toDoManager;
    }

    public async Task Consume(ConsumeContext<ToDoDeleteRequestModel> context)
    {
        var result = await _toDoManager.Delete(context.Message, context.CancellationToken);

        if (result != null)
        {
            await context.RespondAsync<ToDoDeleteResponseModel>(new ToDoDeleteResponseModel
            {
                Id = result.Id
            });
        }
    }
}
