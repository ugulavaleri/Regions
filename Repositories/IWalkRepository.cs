using TestDotnet.Models.Domains;

namespace TestDotnet.Repositories;

public interface IWalkRepository
{
    public Task<List<Walk>> IndexAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAsc = true, int pageNumber = 1,int pageSize = 1000);
    public Task<Walk?> ShowAsync(Guid id);
    public Task<Walk?> UpdateAsync(Guid id,UpdateWalkRequestDto updateWalkRequestDto);
    public Task<Walk> CreateAsync(AddWalksRequestDto addWalksRequestDto);
    public Task<Walk?> DeleteAsync(Guid id);
}
