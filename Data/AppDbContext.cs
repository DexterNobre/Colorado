using GrudColorado.Models;
using Microsoft.EntityFrameworkCore;

namespace GrudColorado.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoTelefone> TiposTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>()
                .HasKey(t => new { t.CodigoCliente, t.NumeroTelefone });

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.CodigoCliente);

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.TipoTelefone)
                .WithMany()
                .HasForeignKey(t => t.CodigoTipoTelefone);

            base.OnModelCreating(modelBuilder);
        }
    }
}
