using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revachess.Client.Models
{
  public class UserViewModel : IValidatableObject
  {
    [Required(ErrorMessage = "Required")]
    [DataType(DataType.Text)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Required")]
    [DataType(DataType.Text)]
    public string Password { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (Password.Length <= 3)
      {
        yield return new ValidationResult("Passwords too short", new[] { "Password" });
      }
    }
  }
}