using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Models.Patients;

namespace TheRetinoblastomaWiki.Server.Controllers
{
    public class PatientsController : ApiController
    {
        // returns the id of the created patient
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create()
    }
}
