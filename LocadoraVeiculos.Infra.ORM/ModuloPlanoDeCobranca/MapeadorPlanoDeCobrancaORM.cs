using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobrancaORM : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlano");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.NomePlano).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.TipoPlano).HasColumnType("int").IsRequired();

            builder.Property(x => x.ValorPorKm).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.ValorDiario).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.LimiteQuilometragem).HasColumnType("varchar(20)").IsRequired();

            builder.HasOne(x => x.GrupoVeiculos);
        }
    }
}
