using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Infrastructure;


namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public class PatientsController : ApiController
    {
        // inject the DB context

        private readonly IPatientService patientService;
        
        public PatientsController (IPatientService patientService) => this.patientService = patientService;
        
        // returns the id of the created patient
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreatePatientRequestModel model)
        {
            // get the id of the user
            var userId = this.User.GetId();

            #region refactored
            /*
            var patient = new Patient 
            { 
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this.data.Add(patient);

            await this.data.SaveChangesAsync();
            */
            #endregion refactored

            var id = await this.patientService.Create(
                model.ImageUrl, 
                model.Description, 
                userId);
            return Created(nameof(this.Create), id);
        }
    }
}
