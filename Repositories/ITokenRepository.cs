using TestDotnet.Models.Domains;

namespace TestDotnet.Repositories;

public interface ITokenRepository
{
    public string CreateJwtToken(AppUser user, List<string> roles);
}