using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestDotnet.Models.Domains;
using TestDotnet.Models.DTO;
using TestDotnet.Repositories;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // this comes from nuget package (Identity)
        private UserManager<AppUser> _userManager;
        private ITokenRepository _tokenRepository;

        public AuthController(UserManager<AppUser> userManager,ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            AppUser user = new AppUser()
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Email,
            };

            IdentityResult? resultUser = await _userManager.CreateAsync(user, registerRequestDto.Password);
            
            if (resultUser.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    resultUser =  await _userManager.AddToRolesAsync(user, registerRequestDto.Roles);
                    if (resultUser.Succeeded)
                    {
                        return Ok("User was registered");
                    }
                }
            }
            return BadRequest(registerRequestDto.Roles);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user != null)
            {
                bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (isValid)
                {
                    IList<string>? roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        string token = _tokenRepository.CreateJwtToken(user, roles.ToList());
                        LoginResponseDto loginResponseDto = new LoginResponseDto
                        {
                            token = token
                        };
                        
                        return Ok(loginResponseDto);
                    }
                    
                }
            }

            return BadRequest("something went wrong!");
        }
    }
}
