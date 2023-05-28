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
            yield return new ValidationResult("Field Id must be greater than 0");
        }
    }
}
