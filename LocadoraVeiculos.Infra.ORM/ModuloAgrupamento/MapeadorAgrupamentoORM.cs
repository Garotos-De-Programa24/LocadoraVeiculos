using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloAgrupamento
{
    public class MapeadorAgrupamento : IEntityTypeConfiguration<Agrupamento>
    {
        public void Configure(EntityTypeBuilder<Agrupamento> builder)
        {
            builder.ToTable("TBAgrupamento");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();

        }

    }
}
