using Microsoft.EntityFrameworkCore;
using TestDotnet.Data;
using TestDotnet.Models.Domains;

namespace TestDotnet.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private TestDotNetDbContext _testDotNetDbContext;
    
    public SQLRegionRepository(TestDotNetDbContext testDotNetDbContext)
    {
        _testDotNetDbContext = testDotNetDbContext;
    }
    
    public async Task<List<Region>> IndexAsync()
    {
        return await _testDotNetDbContext.Regions.ToListAsync();
    }

    public async Task<Region?> ShowAsync(Guid id)
    {
        return await _testDotNetDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Region> CreateAsync(AddRegionRequestDto addRegionRequestDto)
    {
        Region region = new Region()
        {
            Name = addRegionRequestDto.Name,
            Code = addRegionRequestDto.Code,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl,
        };

        _testDotNetDbContext.Regions.Add(region);
        await _testDotNetDbContext.SaveChangesAsync();

        return region;
    }

    public async Task<Region?> UpdateAsync(Guid id, UpdateRegionRequestDto updateRegionRequestDto)
    {
        Region? region = await _testDotNetDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

        if (region == null) return null;

        region.Name = updateRegionRequestDto.Name;
        region.Code = updateRegionRequestDto.Code;
        region.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
        await _testDotNetDbContext.SaveChangesAsync();

        return region;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        Region? region = await _testDotNetDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            
        if (region == null) return null;
            
        _testDotNetDbContext.Regions.Remove(region);
        await _testDotNetDbContext.SaveChangesAsync();

        return region;
    }
}
