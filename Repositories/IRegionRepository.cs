using TestDotnet.Models.Domains;
using TestDotnet.Models.DTO;

namespace TestDotnet.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> IndexAsync();

    Task<Region?> ShowAsync(Guid id);

    Task<Region> CreateAsync(AddRegionRequestDto addRegionRequestDto);

    Task<Region?> UpdateAsync(Guid id, UpdateRegionRequestDto updateRegionRequestDto);

    Task<Region?> DeleteAsync(Guid id);
}
