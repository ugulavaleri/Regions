using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDotnet.CustomActionFilters;
using TestDotnet.Models.Domains;
using TestDotnet.Repositories;

namespace TestDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private IMapper _mapper;
        private IWalkRepository _walkRepository;
        
        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        [HttpGet]
        [ForMethodValidate("tst")]
        public async Task<IActionResult> Index(
            [FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool isAsc = true, 
            [FromQuery] int pageNumber = 1, [FromQuery]int pageSize = 1000
            )
        {
            List<Walk> walks = await _walkRepository.IndexAsync(filterOn, filterQuery, sortBy, isAsc, pageNumber, pageSize);
            List<WalkDto> walkDtos = _mapper.Map<List<WalkDto>>(walks);
            return Ok(walkDtos);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Show(Guid id)
        {
            Walk? walk = await _walkRepository.ShowAsync(id);
            
            if (walk == null) NotFound();
            
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            
            return Ok(walkDto);
        }
        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            Walk? walk = await _walkRepository.UpdateAsync(id,updateWalkRequestDto);
            
            if (walk == null) NotFound();
            
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            
            return Ok(walkDto);
        }
        
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            Walk walk = await _walkRepository.CreateAsync(addWalksRequestDto);
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);

            return Ok(walkDto);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Walk? walk = await _walkRepository.DeleteAsync(id);
            if (walk == null) NotFound();

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);

            return Ok(walkDto);
        }
    }
}
