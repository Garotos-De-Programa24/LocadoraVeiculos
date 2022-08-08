using LocadoraVeiculos.Dominio.ModuloLocação;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace LocadoraVeiculos.Infra.ORM.ModuloTaxa
{
    public class RepositorioTaxaORM : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Equipamento).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("varchar(40)").IsRequired();
            builder.Property(x => x.TaxaDiaria).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.QuantidadePorLocacao).HasColumnType("int");
            builder.HasMany(x => x.Locacoes)
                .WithMany(l => l.Taxas)
                .UsingEntity<Dictionary<string, object>>(
                "LocacaoTaxa",
                x => x.HasOne<Locacao>().WithMany().OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne<Taxa>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );

        }
    }
}
