using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
