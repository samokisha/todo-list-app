using MassTransit;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

namespace TodoService.Consumers;

public class ToDoGetConsumer : IConsumer<ToDoReadRequestModel>
{
    public async Task Consume(ConsumeContext<ToDoReadRequestModel> context)
    {
        await context.RespondAsync<ToDoItemResponseModel>(new ToDoItemResponseModel()
        {
            Id = context.Message.Id
        });
    }
}
