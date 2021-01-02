using System.ComponentModel.DataAnnotations;
using static TheRetinoblastomaWiki.Server.Data.Validation.Patient;

namespace TheRetinoblastomaWiki.Server.Features.Patients
{
    public class CreatePatientRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }
        
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

       

        
    }
}
