using Microsoft.EntityFrameworkCore;
using xp_project.Models;

namespace app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ControleInvestimento> ControleInvestimentos { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutoFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ControleInvestimento>()
                .ToTable("controle_investimentos")
                .HasKey(ci => ci.Id);

            modelBuilder.Entity<ControleInvestimento>()
                .HasOne(ci => ci.Usuario)
                .WithMany()
                .HasForeignKey(ci => ci.IdUsuario);

            modelBuilder.Entity<ControleInvestimento>()
                .HasOne(ci => ci.ProdutoFinanceiro)
                .WithMany()
                .HasForeignKey(ci => ci.IdProdutoFinanceiro);

            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<ProdutoFinanceiro>().ToTable("produtos_financeiros");
        }
    }
}