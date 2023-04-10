using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database.Domain;

namespace univesp.almox.apae.Database
{
    public class ApplicationDatabase : IdentityDbContext
    {
        public DbSet<Almoxarifado> Almoxarifado { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Saida> Saida { get; set; }
        public DbSet<Unidade> Unidade { get; set; }

        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options)
            : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .HaveColumnType("varchar(200)");

            configurationBuilder
                .Properties<decimal>()
                .HaveColumnType("decimal(18,4)");

            configurationBuilder
               .Properties<DateOnly>()
               .HaveColumnType("date");

            configurationBuilder
               .Properties<DateTime>()
               .HaveColumnType("datetime");

            configurationBuilder
               .Properties<bool>()
               .HaveColumnType("tinyint(1)");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
