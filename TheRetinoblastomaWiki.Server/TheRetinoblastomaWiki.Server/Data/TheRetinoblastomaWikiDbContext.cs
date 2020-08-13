


namespace TheRetinoblastomaWiki.Server.Data
{

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class TheRetinoblastomaWikiDbContext : IdentityDbContext
    {
        public TheRetinoblastomaWikiDbContext(DbContextOptions<TheRetinoblastomaWikiDbContext> options)
            : base(options)
        {
        }
    }
}
