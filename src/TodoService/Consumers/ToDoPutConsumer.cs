using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Managers;

namespace TodoService.Consumers;

public class ToDoPutConsumer : IConsumer<ToDoUpdateRequestModel>
{
    private readonly ToDoManager _toDoManager;
    public async Task Consume(ConsumeContext<ToDoUpdateRequestModel> context)
    {
        await _toDoManager.PutAsync((ToDoUpdateRequestModel)context, context.CancellationToken);
        await context.RespondAsync<ToDoItemResponseModel>(new ToDoItemResponseModel()
        {
            Name = $"Name of task {context.Message.Name}",
            Description = $"Description of task {context.Message.Description}"
        });
    }
}
