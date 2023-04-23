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
        var result = await _toDoManager.Update(context.Message, context.CancellationToken);

        await context.RespondAsync(new SearchRequestResultModel()
        {
            ResponseModel = result
        });
    }
}
