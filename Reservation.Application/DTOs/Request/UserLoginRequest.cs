using System.ComponentModel.DataAnnotations;

namespace Reservation.Application.DTOs.Request;

public class UserLoginRequest
{
    [Required(ErrorMessage = "Field {0} is mandatory")]
    [EmailAddress(ErrorMessage = "Field {0} is mandatory")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Field {0} is mandatory")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}