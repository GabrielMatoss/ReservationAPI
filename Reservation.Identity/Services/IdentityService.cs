using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Reservation.Application.DTOs.Request;
using Reservation.Application.DTOs.Response;
using Reservation.Application.Interfaces.Services;
using Reservation.Identity.Configurations;

namespace Reservation.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<JwtOptions> jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegisterRequest)
    {
        var identityUser = new IdentityUser
        {
            UserName = userRegisterRequest.Email,
            Email = userRegisterRequest.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(identityUser, userRegisterRequest.Password);
        if (!result.Succeeded)
        {
            var errorResult = result.Errors.Select(r => r.Description);
            throw new ArgumentException(errorResult.ToString());
        }

        await _userManager.SetLockoutEnabledAsync(identityUser, false);

        var userRegisterResponse = new UserRegisterResponse(
            userRegisterRequest.Name,
            userRegisterRequest.LastName,
            userRegisterRequest.Email);

        userRegisterResponse.HandlerMessage("Register successfully.");

        return userRegisterResponse;
    }

    public async Task<UserLoginResponse> Login(UserLoginRequest userLoginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(
                userLoginRequest.Email,
                userLoginRequest.Password,
                false,
                true);

        if (result.Succeeded)
        {
            return await GenerateCredentials(userLoginRequest.Email);
        }

        var userLoginResponse = new UserLoginResponse();

        if (!result.Succeeded)
        {
            userLoginResponse.HandlerMessage("Login failed, email or password is incorrect.");
        }

        return userLoginResponse;
    }

    private async Task<UserLoginResponse> GenerateCredentials(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new ArgumentException("User not found");

        var accessTokenClaims = await GetClaims(user, addClaimsToUser: true);
        var dateAccessTokenExpiration = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var accessToken = GenerateToken(accessTokenClaims, dateAccessTokenExpiration);

        return new UserLoginResponse(email: user.Email!, accessToken: accessToken, message: "Login success!");
    }

    private string GenerateToken(IEnumerable<Claim> claims, DateTime dateExpiration)
    {
        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: dateExpiration,
            notBefore: DateTime.Now,
            signingCredentials: _jwtOptions.SigningCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<IEnumerable<Claim>> GetClaims(IdentityUser user, bool addClaimsToUser)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString())
        };

        if (!addClaimsToUser) return claims;

        
        //Verifica se já existe e as cria
        if (!await _roleManager.RoleExistsAsync(Roles.Admin))
        {
            await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

        if (!await _roleManager.RoleExistsAsync(Roles.User))
        {
            await _roleManager.CreateAsync(new IdentityRole(Roles.User));
        }
        //Adiciona as roles ao usuario
        if (_userManager.Users.Count() == 1)
        {
            await _userManager.AddToRoleAsync(user, Roles.Admin);
        }

        if (!await _userManager.IsInRoleAsync(user, Roles.Admin))
        {
            await _userManager.AddToRoleAsync(user, Roles.User);
        }
        
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        claims.AddRange(userClaims);

        claims.AddRange(roles.Select(role => new Claim("role", role)));
        
        return claims;
    }
};
