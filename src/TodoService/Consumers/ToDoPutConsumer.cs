using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        await context.RespondAsync<ToDoItemResponseModel>(new ToDoItemResponseModel()
        {
            Name = $"Name of task {context.Message.Name}",
            Description = $"Description of task {context.Message.Description}"
        });
    }
}
