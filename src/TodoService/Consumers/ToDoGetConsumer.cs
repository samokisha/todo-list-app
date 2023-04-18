using MassTransit;
using ToDoList.Models.Requests;
using TodoService.Managers;
using ToDoService.Managers;

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
        var result = await _toDoManager.Read(context.Message, context.CancellationToken);

        var searchRequestResultModel = new SearchRequestResultModel()
        {
            ResponseModel = result.ResponseModel
        };

        await context.RespondAsync<SearchRequestResultModel>(searchRequestResultModel);
    }
}
