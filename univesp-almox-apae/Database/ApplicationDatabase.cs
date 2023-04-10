using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace univesp.almox.apae.Database
{
    public class ApplicationDatabase : IdentityDbContext
    {
        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
