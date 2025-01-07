using Microsoft.EntityFrameworkCore;
using TestDotnet.Models.Domains;

namespace TestDotnet.Data;

public class TestDotNetDbContext:DbContext
{
    public TestDotNetDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) { }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // this is not good practice anymore.
        // now best is to use UseSeeding and UseAsyncSeeding methods when configuring db context in Pogram.cs
        // https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding#model-seed-data
        List<Difficulty> difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("84a217cf-5ac3-4b82-9fa8-0b3c1fa86c2e"),
                Name = "Easy",
            },
            new Difficulty()
            {
                Id = Guid.Parse("b7d92f6e-3c14-4d95-ae76-d8a40c33d847"),
                Name = "Medium",
            },
            new Difficulty()
            {
                Id = Guid.Parse("f5e89a1d-2c6b-48d9-b4c3-15f7ae94d2c1"),
                Name = "Hard",
            },
        };
        
        // this is not good practice anymore.
        // now best is to use UseSeeding and UseAsyncSeeding methods when configuring db context in Pogram.cs
        // https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding#model-seed-data
        List<Region> regions = new List<Region>()
        {
            new Region
            {
                Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                Name = "Northland",
                Code = "NTL",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                Name = "Bay Of Plenty",
                Code = "BOP",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                Name = "Wellington",
                Code = "WGN",
                RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                Name = "Nelson",
                Code = "NSN",
                RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            },
            new Region
            {
                Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                Name = "Southland",
                Code = "STL",
                RegionImageUrl = null
            },
        };
            

        modelBuilder.Entity<Difficulty>().HasData(difficulties);
        modelBuilder.Entity<Region>().HasData(regions);
    }
}
