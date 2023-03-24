using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Data.Entities;

namespace TodoService.Managers;

internal class ToDoManager
{
    private readonly ToDoContext _toDoContext;
    private ToDoItem? _searchItemResult;
    public ToDoManager(ToDoContext toDoContext)
    {
        _toDoContext = toDoContext;
    }

    public async Task<ToDoItemResponseModel> PostAsync(ToDoCreateRequestModel createRequestModel, CancellationToken cancellationToken)
    {
        using (_toDoContext)
        {
            await _toDoContext.AddAsync(createRequestModel, cancellationToken);
            await _toDoContext.SaveChangesAsync(cancellationToken);
            return new ToDoItemResponseModel
            {
                Name = _searchItemResult.Name,
                Description = _searchItemResult.Description,
                IsDone = _searchItemResult.IsDone
            };
        }
    }

    public async Task<ToDoItemResponseModel?> GetAsync(ToDoReadRequestModel readRequestModel, CancellationToken cancellationToken)
    {
        try
        {
            using (_toDoContext)
            {
                _searchItemResult = await _toDoContext.TodoItem.Where(x => x.Id == readRequestModel.Id).SingleOrDefaultAsync(cancellationToken);
                return new ToDoItemResponseModel
                {
                    Id = _searchItemResult.Id,
                    Name = _searchItemResult.Name,
                    Description = _searchItemResult.Description,
                    IsDone = _searchItemResult.IsDone
                };
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<ToDoItemResponseModel> PutAsync(ToDoUpdateRequestModel updateRequestModel, CancellationToken cancellationToken)
    {
        using (_toDoContext)
        {
            _searchItemResult = await _toDoContext.TodoItem.Where(x => x.Id == updateRequestModel.Id).SingleOrDefaultAsync(cancellationToken);
            _toDoContext.Update<ToDoUpdateRequestModel>(updateRequestModel);
            await _toDoContext.SaveChangesAsync(cancellationToken);
            return new ToDoItemResponseModel
            {
                Id = _searchItemResult.Id,
                Name = _searchItemResult.Name,
                Description = _searchItemResult.Description,
                IsDone = _searchItemResult.IsDone
            };
        }
    }

    public async Task<ToDoDeleteResponseModel> DeleteAsync(ToDoDeleteRequestModel deleteRequestModel, CancellationToken cancellationToken)
    {
        try
        {
            using (_toDoContext)
            {
                _searchItemResult = await _toDoContext.TodoItem.Where(x => x.Id == deleteRequestModel.Id).SingleOrDefaultAsync(cancellationToken);
                _toDoContext.Remove<ToDoDeleteRequestModel>(deleteRequestModel);
                await _toDoContext.SaveChangesAsync(cancellationToken);
                return new ToDoDeleteResponseModel
                {
                    Id = _searchItemResult.Id
                };
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
