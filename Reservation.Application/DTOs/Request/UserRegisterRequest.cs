using System.ComponentModel.DataAnnotations;

namespace Reservation.Application.DTOs.Request;

public class UserRegisterRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [StringLength(40, ErrorMessage = "O campo {0} deve ter no máximo 40 caracteres!")]
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido!")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no mínimo 6 caracteres e no máximo 50 caracteres", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
    public string PasswordConfirm { get; set; } = null!;
}