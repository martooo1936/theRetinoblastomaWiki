
namespace TheRetinoblastomaWiki.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // validate if the auth is working correctly
       // [Authorize]
        public IActionResult Get()
        {
            // test action result
            return Ok("Works");
        }
   
    }
}
