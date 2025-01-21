using System.ComponentModel.DataAnnotations;

namespace Reservation.Application.DTOs.Request;

public class UserRegisterRequest
{
    [Required(ErrorMessage = "Field {0} is mandatory")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "Field {0} is mandatory")]
    [StringLength(40, ErrorMessage = "The field {0} must have a maximum of 40 characters")]
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage = "Field {0} is mandatory")]
    [EmailAddress(ErrorMessage = "Field {0} is mandatory")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Field {0} is mandatory")]
    [StringLength(50, ErrorMessage = "The field {0} must have at least 6 characters and a maximum of 50 characters", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required(ErrorMessage = "Field {0} is mandatory")]
    [Compare(nameof(Password), ErrorMessage = "Passwords must be the same")]
    public string PasswordConfirm { get; set; } = null!;
}