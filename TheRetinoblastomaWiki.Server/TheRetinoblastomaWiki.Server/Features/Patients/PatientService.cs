using System;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Data;
using TheRetinoblastomaWiki.Server.Data.Models;

namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public class PatientService : IPatientService
    {
        private readonly TheRetinoblastomaWikiDbContext data;

        public PatientService(TheRetinoblastomaWikiDbContext data) => this.data = data;
        
        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var patient = new Patient
            {
                ImageUrl = imageUrl,
                Description = description,
                UserId = userId
            };

            this.data.Add(patient);

            await this.data.SaveChangesAsync();

            return patient.Id;
        }
    }
}
