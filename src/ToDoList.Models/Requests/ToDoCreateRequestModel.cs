namespace ToDoList.Models.Requests;

public class ToDoCreateRequestModel
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsDone { get; set; }
}
