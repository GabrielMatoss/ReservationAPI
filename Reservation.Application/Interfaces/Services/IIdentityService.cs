using Reservation.Application.DTOs.Request;
using Reservation.Application.DTOs.Response;

namespace Reservation.Application.Interfaces.Services;

public interface IIdentityService 
{
    Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegisterRequest);
    Task<UserLoginResponse> Login(UserLoginRequest userLoginResponse);
}