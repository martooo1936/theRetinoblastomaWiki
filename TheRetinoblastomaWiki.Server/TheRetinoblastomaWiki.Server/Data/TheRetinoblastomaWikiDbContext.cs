


namespace TheRetinoblastomaWiki.Server.Data
{

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TheRetinoblastomaWiki.Server.Data.Models;

    public class TheRetinoblastomaWikiDbContext : IdentityDbContext<User>
    {
        public TheRetinoblastomaWikiDbContext(DbContextOptions<TheRetinoblastomaWikiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany(u => u.Patients)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            base.OnModelCreating(builder);
        }
    }
}
