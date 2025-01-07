using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestDotnet.Models.Domains;

namespace TestDotnet.Repositories;

public class TokenRepository : ITokenRepository
{
    private IConfiguration _configuration;
    public TokenRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string CreateJwtToken(AppUser user, List<string> roles)
    {
        List<Claim> claims = new List<Claim>();
        
        claims.Add(new Claim(ClaimTypes.Email,user.Email));

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));
        }

        SymmetricSecurityKey? key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        SigningCredentials? credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken? token = new JwtSecurityToken(
            _configuration["Jwt:issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}