
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TheRetinoblastomaWiki.Server.Data.Models
{
    //inherits identity user
    public class User: IdentityUser
    {
        public IEnumerable<Patient> Patients { get; } = new HashSet<Patient>();
    }
}
