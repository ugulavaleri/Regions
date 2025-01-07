using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDotnet.Data;
using TestDotnet.Models.Domains;

namespace TestDotnet.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private TestDotNetDbContext _testDotNetDbContext;
    
    public SQLWalkRepository(TestDotNetDbContext testDotNetDbContext)
    {
        _testDotNetDbContext = testDotNetDbContext;
    }
    
    public async Task<List<Walk>> IndexAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAsc = true, int pageNumber = 1,int pageSize = 1000)
    {
        IQueryable<Walk> walkQuery = _testDotNetDbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();

        // Filtering
        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            if (filterOn.Equals("Name", StringComparison.CurrentCultureIgnoreCase))
            {
                walkQuery = walkQuery.Where(w => w.Name.Contains(filterQuery));
            }
            
            if (filterOn.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
            {
                walkQuery = walkQuery.Where(w => w.Description.Contains(filterQuery));
            }
        }
        
        // Sorting
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walkQuery = isAsc ? walkQuery.OrderBy(w => w.Name) : walkQuery.OrderByDescending(w => w.Name);
            }
            if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
                walkQuery = isAsc ? walkQuery.OrderBy(w => w.LengthInKm) : walkQuery.OrderByDescending(w => w.LengthInKm);
            }
        }
        
        // Pagination
        int skipResults = (pageNumber - 1) * pageSize;
        
        return await walkQuery.Skip(skipResults).Take(pageSize).ToListAsync();
    }
   
    public async Task<Walk?> ShowAsync([FromRoute] Guid id)
    {
        return await _testDotNetDbContext.Walks
            .Include(r => r.Region)
            .Include(d => d.Difficulty)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id,UpdateWalkRequestDto updateWalkRequestDto)
    {
        Walk? walk = await _testDotNetDbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
        if (walk == null) return null;

        walk.Name = updateWalkRequestDto.Name;
        walk.Description = updateWalkRequestDto.Description;
        walk.LengthInKm = updateWalkRequestDto.LengthInKm;
        walk.WalkImageUrl = updateWalkRequestDto.WalkImageUrl;
        walk.RegionId = updateWalkRequestDto.RegionId;
        walk.DifficultyID = updateWalkRequestDto.DifficultyID;
        await _testDotNetDbContext.SaveChangesAsync();
        
        return walk;
    }

    public async Task<Walk> CreateAsync(AddWalksRequestDto addWalksRequestDto)
    {
        Walk walk = new Walk()
        {
            Name = addWalksRequestDto.Name,
            Description = addWalksRequestDto.Description,
            LengthInKm = addWalksRequestDto.LengthInKm,
            WalkImageUrl = addWalksRequestDto.WalkImageUrl,
            DifficultyID = addWalksRequestDto.DifficultyID,
            RegionId = addWalksRequestDto.RegionId,
        };
        
        await _testDotNetDbContext.Walks.AddAsync(walk);
        await _testDotNetDbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        Walk? walk = await _testDotNetDbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
        if (walk == null) return null;
        _testDotNetDbContext.Walks.Remove(walk);
        await _testDotNetDbContext.SaveChangesAsync();
        
        return walk;
    }
}
