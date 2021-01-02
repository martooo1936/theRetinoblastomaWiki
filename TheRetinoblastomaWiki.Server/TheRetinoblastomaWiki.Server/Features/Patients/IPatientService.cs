using System.Threading.Tasks;

namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public interface IPatientService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
    }
}
