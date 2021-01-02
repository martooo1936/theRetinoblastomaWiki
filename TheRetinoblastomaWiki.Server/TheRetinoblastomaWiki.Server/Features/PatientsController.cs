using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Models.Patients;
using TheRetinoblastomaWiki.Server.Infrastructure;
using TheRetinoblastomaWiki.Server.Data.Models;
using TheRetinoblastomaWiki.Server.Data;

namespace TheRetinoblastomaWiki.Server.Features
{
    public class PatientsController : ApiController
    {
        // inject the DB context

        private readonly TheRetinoblastomaWikiDbContext data;
        
        public PatientsController (TheRetinoblastomaWikiDbContext data) 
        {
            this.data = data;
        }
        // returns the id of the created patient
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreatePatientRequestModel model)
        {
            // get the id of the user
            var userId = this.User.GetId();
           

            var patient = new Patient 
            { 
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this.data.Add(patient);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), patient.Id);
        }
    }
}
