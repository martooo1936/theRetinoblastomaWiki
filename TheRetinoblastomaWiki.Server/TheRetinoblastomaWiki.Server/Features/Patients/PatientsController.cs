using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Features.Patients.Models;
using TheRetinoblastomaWiki.Server.Infrastructure.Extensions;

namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public class PatientsController : ApiController
    {
        // inject the DB context

        private readonly IPatientService patientService;
        
        public PatientsController (IPatientService patientService) => this.patientService = patientService;
        
        [Authorize]
        [HttpGet]
        // return all patients which are treated in the hospital
        public async Task<IEnumerable<PatientListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.patientService.ByUser(userId);

        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task <ActionResult<PatientDetailsServiceModel>> Details(int id)
             => await this.patientService.Details(id);
     


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
