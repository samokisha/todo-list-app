using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Data.Entities;

namespace TodoService.Consumers;

public class ToDoDeleteConsumer : IConsumer<ToDoDeleteRequestModel>
{
    public async Task Consume(ConsumeContext<ToDoDeleteRequestModel> context)
    {
        await context.RespondAsync<ToDoDeleteResponseModel>(new ToDoDeleteResponseModel()
        {
            Id = context.Message.Id
        });
    }
}
