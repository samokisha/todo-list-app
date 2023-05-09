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
        var result = await _toDoManager.ReadAsync(context.Message, context.CancellationToken);

        var searchRequestResultModel = new SearchRequestResultModel()
        {
            ResponseModel = result
        };

        await context.RespondAsync<SearchRequestResultModel>(searchRequestResultModel);
    }
}
