using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;

namespace TodoService.Managers;
internal class ToDoManager
{
    private readonly ToDoContext _toDoContext;
    public ToDoManager(ToDoContext toDoContext)
    {
        _toDoContext = toDoContext;
    }
    
    public async Task<ToDoItemResponseModel> PostAsync(ToDoCreateRequestModel createRequestModel,CancellationToken cancellationToken)
    {
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoItemResponseModel();
    }
    public async Task<ToDoItemResponseModel> GetAsync(ToDoReadRequestModel readRequestModel,CancellationToken cancellationToken)
    {
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoItemResponseModel();
    }
    public async Task<ToDoItemResponseModel> PutAsync(ToDoUpdateRequestModel updateRequestModel,CancellationToken cancellationToken)
    {
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoItemResponseModel();
    }
    public async Task<ToDoDeleteResponseModel> DeleteAsync(ToDoDeleteRequestModel deleteRequestModel,CancellationToken cancellationToken)
    {
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoDeleteResponseModel();
    }

}
