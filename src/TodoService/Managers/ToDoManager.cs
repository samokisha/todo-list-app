using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Data.Entities;
using ToDoService.Managers;

namespace TodoService.Managers;

public class ToDoManager
{
    private readonly ToDoContext _toDoContext;

    public ToDoManager(ToDoContext toDoContext)
    {
        _toDoContext = toDoContext;
    }

    public async Task<ToDoItemResponseModel> PostAsync(ToDoCreateRequestModel createRequestModel, CancellationToken cancellationToken)
    {
        ToDoItem newToDoItem = new ToDoItem()
        {
            Name = createRequestModel.Name,
            Description = createRequestModel.Description,
            IsDone = createRequestModel.IsDone
        };
        await _toDoContext.TodoItem.AddAsync(newToDoItem, cancellationToken);
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoItemResponseModel()
        {
            Id = newToDoItem.Id,
            Name = newToDoItem.Name,
            Description = newToDoItem.Description,
            IsDone = newToDoItem.IsDone
        };
    }

    public async Task<ToDoItemResponseModel?> GetAsync(ToDoReadRequestModel readRequestModel, CancellationToken cancellationToken)
    {
        var searchItemResult = await _toDoContext.Set<ToDoItem>().FindAsync(readRequestModel.Id);

        if (searchItemResult != null)
        {
            return new SearchRequestResult
            {
                Id = searchItemResult.Id,
                Name = searchItemResult.Name,
                Description = searchItemResult.Description,
                IsDone = searchItemResult.IsDone
            };
        }
        else
        {
            return new SearchRequestResult()
            {
                ResponseModel = null
            };
        }
    }

    public async Task<ToDoItemResponseModel?> PutAsync(ToDoUpdateRequestModel updateRequestModel, CancellationToken cancellationToken)
    {
        var updateItemResult = await _toDoContext.Set<ToDoItem>().FindAsync(updateRequestModel.Id);
        if (updateItemResult != null)
        {
            _toDoContext.Entry(updateItemResult).CurrentValues.SetValues(updateRequestModel);
            await _toDoContext.SaveChangesAsync(cancellationToken);
            return new ToDoItemResponseModel
            {
                Id = updateRequestModel.Id,
                Name = updateRequestModel.Name,
                Description = updateRequestModel.Description,
                IsDone = updateRequestModel.IsDone
            };
        }
        else
        {
            return new SearchRequestResult()
            {
                ResponseModel = null
            };
        }
    }

    public async Task<ToDoDeleteResponseModel?> DeleteAsync(ToDoDeleteRequestModel deleteRequestModel, CancellationToken cancellationToken)
    {
        var deleteItemResult = await _toDoContext.TodoItem.Where(x => x.Id == deleteRequestModel.Id).SingleOrDefaultAsync(cancellationToken);
        if (deleteItemResult != null)
        {
            _toDoContext.Remove(deleteItemResult);
            await _toDoContext.SaveChangesAsync(cancellationToken);
            return new ToDoDeleteResponseModel()
            {
                Id = deleteItemResult.Id
            };
        }
        return null;
    }
}
