using System.Collections.Generic;
using System.Threading.Tasks;
using TheRetinoblastomaWiki.Server.Features.Patients.Models;

namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public interface IPatientService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
        public Task<IEnumerable<PatientListingServiceModel>> ByUser(string userId);
        public Task<PatientDetailsServiceModel> Details(int id);
    }
}
