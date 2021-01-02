using System.ComponentModel.DataAnnotations;
using static TheRetinoblastomaWiki.Server.Data.Validation.Patient;

namespace TheRetinoblastomaWiki.Server.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        // a patient can be added only by registered users / doctor 
        [Required]
        public string UserId { get; set; }

        // user navigational property
        public User User { get; set; }

    }
}
