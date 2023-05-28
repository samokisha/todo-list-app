using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Requests;

public class ToDoCreateRequestModel
{
    [Required]
    [StringLength(128)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool? IsDone { get; set; }
}
