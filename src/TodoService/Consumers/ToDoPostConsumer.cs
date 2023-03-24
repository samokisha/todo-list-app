using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoPostConsumer : IConsumer<ToDoCreateRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public async Task Consume(ConsumeContext<ToDoCreateRequestModel> context)
    {
        await _toDoManager.PostAsync((ToDoCreateRequestModel)context, context.CancellationToken);
        await context.RespondAsync<ToDoItemResponseModel>(new ToDoItemResponseModel()
        {
            Name = $"Name of task {context.Message.Name}",
            Description = $"Description of task{context.Message.Description}"
        });
    }
}
