using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Requests;
using ToDoList.Models.Responses;
using TodoService.Data.Entities;
using ToDoService.Managers;

namespace TodoService.Managers;

internal class ToDoManager
{
    private readonly ToDoContext _toDoContext;
    private ToDoItem ? _searchItemResult;
    public ToDoManager(ToDoContext toDoContext)
    {
        _toDoContext = toDoContext;
    }

    public async Task<ToDoItemResponseModel> PostAsync(ToDoCreateRequestModel createRequestModel, CancellationToken cancellationToken)
    {
        await _toDoContext.AddAsync(createRequestModel,cancellationToken);
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoItemResponseModel();
    }

    public async Task<ToDoItemResponseModel?> GetAsync(ToDoReadRequestModel readRequestModel, CancellationToken cancellationToken)
    {
        _searchItemResult = await _toDoContext.TodoItem.Where(x => x.Id == readRequestModel.Id).SingleOrDefaultAsync(cancellationToken);

        if (_searchItemResult is null)
        {
            return null;
        }
        else
        {
            return new ToDoItemResponseModel
            {
                Id = _searchItemResult.Id,
                Name = _searchItemResult.Name,
                Description = _searchItemResult.Description,
                IsDone = _searchItemResult.IsDone
            };
        }
    }

    public async Task<ToDoItemResponseModel> PutAsync(ToDoUpdateRequestModel updateRequestModel, CancellationToken cancellationToken)
    {
        _toDoContext.Update<ToDoUpdateRequestModel>(updateRequestModel);
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoItemResponseModel();
    }

    public async Task<ToDoDeleteResponseModel> DeleteAsync(ToDoDeleteRequestModel deleteRequestModel, CancellationToken cancellationToken)
    {
        _toDoContext.Remove<ToDoDeleteRequestModel>(deleteRequestModel);
        await _toDoContext.SaveChangesAsync(cancellationToken);
        return new ToDoDeleteResponseModel();
    }
}
