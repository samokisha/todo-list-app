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

public class ToDoPutConsumer : IConsumer<ToDoUpdateRequestModel>
{
    public async Task Consume(ConsumeContext<ToDoUpdateRequestModel> context)
    {
        await context.RespondAsync<ToDoItemResponseModel>(new());
    }
}
