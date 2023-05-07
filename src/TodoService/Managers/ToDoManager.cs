using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Data.Entities;

namespace TodoService.Managers;

public class ToDoManager
{
    private readonly ToDoContext _toDoContext;

    public ToDoManager(ToDoContext toDoContext)
    {
        _toDoContext = toDoContext;
    }

    public async Task<ToDoItemResponseModel> CreateAsync(ToDoCreateRequestModel createRequestModel, CancellationToken cancellationToken)
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

    public async Task<ToDoItemResponseModel?> ReadAsync(ToDoReadRequestModel readRequestModel, CancellationToken cancellationToken)
    {
        ToDoItemResponseModel? toDoItemResponseModel = null;

        var searchItemResult = await _toDoContext.TodoItem.Where(x => x.Id == readRequestModel.Id).SingleOrDefaultAsync(cancellationToken);

        if (searchItemResult != null)
        {
            toDoItemResponseModel = new ToDoItemResponseModel()
            {
                Id = searchItemResult.Id,
                Name = searchItemResult.Name,
                Description = searchItemResult.Description,
                IsDone = searchItemResult.IsDone
            };

            return toDoItemResponseModel;
        }

        return toDoItemResponseModel;
    }

    public async Task<ToDoItemResponseModel?> UpdateAsync(ToDoUpdateRequestModel updateRequestModel, CancellationToken cancellationToken)
    {
        ToDoItemResponseModel? toDoItemResponseModel = null;

        var updateItemResult = await _toDoContext.TodoItem.Where(x => x.Id == updateRequestModel.Id).SingleOrDefaultAsync(cancellationToken);

        if (updateItemResult != null)
        {
            updateItemResult.Name = updateRequestModel.Name;
            updateItemResult.Description = updateRequestModel.Description;
            updateItemResult.IsDone = updateRequestModel.IsDone;

            await _toDoContext.SaveChangesAsync(cancellationToken);

            toDoItemResponseModel = new ToDoItemResponseModel
            {
                Id = updateRequestModel.Id,
                Name = updateRequestModel.Name,
                Description = updateRequestModel.Description,
                IsDone = updateRequestModel.IsDone
            };
        }

        return toDoItemResponseModel;
    }

    public async Task<ToDoDeleteResponseModel> DeleteAsync(ToDoDeleteRequestModel deleteRequestModel, CancellationToken cancellationToken)
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
        else
        {
            return new ToDoDeleteResponseModel();
        }
    }
}
