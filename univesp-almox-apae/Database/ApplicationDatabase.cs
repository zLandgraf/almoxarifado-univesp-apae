using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using univesp.almox.apae.Database.Domain;

namespace univesp.almox.apae.Database
{
    public class ApplicationDatabase : IdentityDbContext
    {
        public DbSet<Material> Material { get; set; }
        public DbSet<Medida> Unidade { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<ItemEntrada> ItemEntrada { get; set; }
        public DbSet<Saida> Saida { get; set; }
        public DbSet<ItemSaida> ItemSaida { get; set; }
        public DbSet<Estoque> Estoque { get; set; }

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
