using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Requests;

public class ToDoReadRequestModel : IValidatableObject
{
    [Required]
    public int? Id { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id <= 0)
        {
            yield return new ValidationResult("Must be greater than 0", new[] { nameof(Id) });
        }
    }
}
