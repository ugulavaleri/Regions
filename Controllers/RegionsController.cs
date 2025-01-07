using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDotnet.CustomActionFilters;
using TestDotnet.Data;
using TestDotnet.Models.Domains;
using TestDotnet.Models.DTO;
using TestDotnet.Repositories;

namespace TestDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        
        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Region> regions = await _regionRepository.IndexAsync();
            
            // DTOs
            // List<RegionDto> regionsDto = new List<RegionDto>();
            //
            // foreach (var region in regions)
            // {
            //     regionsDto.Add(new RegionDto()
            //     {
            //         Id = region.Id,
            //         Name = region.Name,
            //         Code = region.Code,
            //         RegionImageUrl = region.RegionImageUrl,
            //     });
            // }
            
            // map dtos
            //to  //from
            List<RegionDto> regionsDto = _mapper.Map<List<RegionDto>>(regions);
                
            return Ok(regionsDto);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Show([FromRoute] Guid id)
        {
            Region? region = await _regionRepository.ShowAsync(id);
            if (region == null)
                return NotFound();
            
            // RegionDto regionDto = new RegionDto()
            // {
            //     Id = region.Id,
            //     Name = region.Name,
            //     Code = region.Code,
            //     RegionImageUrl = region.RegionImageUrl,
            // };
            //to  //from
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            
            return Ok(regionDto);
        }
        
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            Region region = await _regionRepository.CreateAsync(addRegionRequestDto);
            
            // RegionDto regionDto = new RegionDto()
            // {
            //     Id = region.Id,
            //     Name = region.Name,
            //     Code = region.Code,
            //     RegionImageUrl = region.RegionImageUrl,
            // };
            
            //to  //from
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            
            return CreatedAtAction(nameof(Show), new { id = regionDto.Id},regionDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            Region? region = await _regionRepository.UpdateAsync(id, updateRegionRequestDto);
            
            if (region == null)
                return NotFound();
            
            // RegionDto regionDto = new RegionDto()
            // {
            //     Id = region.Id,
            //     Name = region.Name,
            //     Code = region.Code,
            //     RegionImageUrl = region.RegionImageUrl,
            // };
            //to  //from
            RegionDto regionDto = _mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region? region = await _regionRepository.DeleteAsync(id);
            if (region == null) return NotFound();
            
            // RegionDto regionDto = new RegionDto()
            // {
            //     Id = region.Id,
            //     Name = region.Name,
            //     Code = region.Code,
            //     RegionImageUrl = region.RegionImageUrl,
            // };
            //to  //from
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            
            return Ok(regionDto);
        }
    }
}
 