using Microsoft.IdentityModel.Tokens;

namespace Reservation.Identity.Configurations;

public class JwtOptions
{
    public SigningCredentials SigningCredentials { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}