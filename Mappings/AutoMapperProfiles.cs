using AutoMapper;
using TestDotnet.Models.Domains;
using TestDotnet.Models.DTO;

namespace TestDotnet.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // 
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<Walk, AddWalksRequestDto>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();
        CreateMap<Difficulty,DifficultyDto>().ReverseMap();
    }
}
