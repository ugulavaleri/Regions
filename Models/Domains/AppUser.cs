using Microsoft.AspNetCore.Identity;

namespace TestDotnet.Models.Domains;

public class AppUser : IdentityUser
{
    public string? Address { get; set; }
}
