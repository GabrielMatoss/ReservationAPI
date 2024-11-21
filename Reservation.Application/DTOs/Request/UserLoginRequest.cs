using System.ComponentModel.DataAnnotations;

namespace Reservation.Application.DTOs.Request;

public class UserLoginRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}