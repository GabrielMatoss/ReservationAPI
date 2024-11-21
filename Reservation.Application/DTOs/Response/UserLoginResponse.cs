namespace Reservation.Application.DTOs.Response;

public class UserLoginResponse
{
    public UserLoginResponse()
    {}
    public UserLoginResponse(string email, string accessToken) 
    {
        Email = email;
        AccessToken = accessToken;
        Message = "";
    }
        
    public string? AccessToken { get; private set; }
    public string? Message { get; private set; }
    public string? Email { get; private set; }

    public void HandlerMessage(string message)
    {
        Message = message;
    }
}