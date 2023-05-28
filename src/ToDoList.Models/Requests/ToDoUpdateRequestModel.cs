using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models.Requests;

public class ToDoUpdateRequestModel : IValidatableObject
{
    [Required]
    public int? Id { get; set; }

    [StringLength(128)]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool? IsDone { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id <= 0)
        {
            yield return new ValidationResult("Field Id must be greater than 0");
        }
        else if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("Field Name is null or empty");
        }
        else if (IsDone == null)
        {
            yield return new ValidationResult("Field IsDone must have a value (true or false) and cannot be empty or null");
        }
    }
}
