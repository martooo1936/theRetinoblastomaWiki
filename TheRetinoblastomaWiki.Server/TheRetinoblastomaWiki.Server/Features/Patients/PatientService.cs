using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<PatientListingResponseModel>> ByUser(string userId)
            => await this.data
            .Patients
            .Where(p => p.UserId == userId)
            .Select(p => new PatientListingResponseModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl
            })
            .ToListAsync();
       
    }
}
