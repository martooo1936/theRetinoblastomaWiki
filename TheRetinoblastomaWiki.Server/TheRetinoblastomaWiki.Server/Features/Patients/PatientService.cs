using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Data;
using TheRetinoblastomaWiki.Server.Data.Models;
using TheRetinoblastomaWiki.Server.Features.Patients.Models;

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

        public async Task<IEnumerable<PatientListingServiceModel>> ByUser(string userId)
            => await this.data
            .Patients
            .Where(p => p.UserId == userId)
            .Select(p => new PatientListingServiceModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl
            })
            .ToListAsync();

        public async Task<PatientDetailsServiceModel> Details(int id)
        => await this.data
            .Patients
            .Where(p => p.Id == id)
            .Select(p => new PatientDetailsServiceModel
            {
                    Id = p.Id,
                    UserId = p.UserId,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    UserName = p.User.UserName
            })
            .FirstOrDefaultAsync();
    }
}
