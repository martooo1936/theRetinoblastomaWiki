
namespace TheRetinoblastomaWiki.Server.Features
{
    using Microsoft.AspNetCore.Mvc;

    // base abstract class for API controllers
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {

    }
}
