using Microsoft.AspNetCore.Mvc;
using Reservation.Application.DTOs.Request;
using Reservation.Application.DTOs.Response;
using Reservation.Application.Interfaces.Services;

namespace Reservation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public UserController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [ProducesResponseType(typeof(UserRegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(UserRegisterRequest userRegisterRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _identityService.RegisterUser(userRegisterRequest);

        if (response.Message == null)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }

    [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [HttpPost("login")]
    public async Task<ActionResult<UserLoginResponse>> LoginUser(UserLoginRequest userLoginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = await _identityService.Login(userLoginRequest);
        if (result.AccessToken != null)
            return Ok(result);

        return Unauthorized(result);
    }

}
