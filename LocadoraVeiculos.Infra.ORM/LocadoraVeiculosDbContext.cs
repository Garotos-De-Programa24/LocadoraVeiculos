using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LocadoraVeiculos.Infra.ORM
{
    public class LocadoraVeiculosDbContext : DbContext
    {
        
        public DbSet<Agrupamento> GruposDeVeiculos { get; set; }
        private readonly string enderecoBanco;

        LocadoraVeiculosDbContext()
        {
            var configuracao = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("ConfiguracaoAplicacao.json").Build();
            enderecoBanco = configuracao.GetConnectionString("SqlServer");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(enderecoBanco);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agrupamento>(entidade =>
            {
                entidade.ToTable("TBAgrupamento");
                entidade.Property(x => x.Id).ValueGeneratedNever();
                entidade.Property(x => x.Nome).HasColumnType("varchar(100)");
            });
        }


    }
}
