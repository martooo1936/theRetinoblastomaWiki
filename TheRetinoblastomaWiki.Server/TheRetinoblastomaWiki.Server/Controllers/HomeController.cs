
namespace TheRetinoblastomaWiki.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class HomeController : ApiController
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
