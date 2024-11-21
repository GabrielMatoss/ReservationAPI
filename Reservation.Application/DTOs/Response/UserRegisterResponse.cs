namespace Reservation.Application.DTOs.Response;

public class UserRegisterResponse
{
    public UserRegisterResponse(string name, string lastname, string email)
    {
        Name = name;
        LastName = lastname;
        Email = email;
        Message = "";
    }
    
    public string Name { get; private set; }
    public string LastName { get; private set; } 
    public string Email { get; private set; }
    public string? Message { get; private set; }
    
    public void HandlerMessage(string message)
    {
        Message = message;
    }
}