using Microsoft.IdentityModel.Tokens;

namespace Reservation.Identity.Configurations;

public class JwtOptions
{
    public SigningCredentials SigningCredentials { get; set; } = null!;
    public int AccessTokenExpiration { get; set; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}