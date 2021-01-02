using System.ComponentModel.DataAnnotations;
using static TheRetinoblastomaWiki.Server.Data.Validation.Patient;

namespace TheRetinoblastomaWiki.Server.Models.Patients
{
    public class CreatePatientRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        
    }
}
