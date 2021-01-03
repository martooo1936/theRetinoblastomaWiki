using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public interface IPatientService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
        public Task<IEnumerable<PatientListingResponseModel>> ByUser(string userId); 
    }
}
