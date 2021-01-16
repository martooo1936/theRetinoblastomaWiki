namespace TheRetinoblastomaWiki.Server.Features.Patients.Models
{
    public class PatientDetailsServiceModel : PatientListingServiceModel
    {
        
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
