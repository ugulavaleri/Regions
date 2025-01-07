using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestDotnet.Models.Domains;

namespace TestDotnet.Data;

public class TestDotnetAuthDbContext : IdentityDbContext<AppUser> // custom user for extra fields in database.
{
    public TestDotnetAuthDbContext(DbContextOptions<TestDotnetAuthDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string readerId = "54edf878-5b46-4422-9c89-a3b22d5992a7";
        string writerId = "8c6d89e4-1f3a-4c84-9d4b-7e59876c3d28";
        
        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = readerId,
                ConcurrencyStamp = readerId,
                Name = "reader",
                NormalizedName = "reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerId,
                ConcurrencyStamp = writerId,
                Name = "writer",
                NormalizedName = "writer".ToUpper()
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}