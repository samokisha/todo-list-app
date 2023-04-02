using ToDoList.Models.Responses;

namespace ToDoService.Managers;

internal class SearchRequestResult : ToDoItemResponseModel
{
    public ToDoItemResponseModel? ResponseModel { get; set; }
}
