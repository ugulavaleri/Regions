using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public string[] index()
        {
            string[] roles = new string[]
            {
                "Admin", "Product Owner", "User"
            };
            return roles;
        }
    }
}
