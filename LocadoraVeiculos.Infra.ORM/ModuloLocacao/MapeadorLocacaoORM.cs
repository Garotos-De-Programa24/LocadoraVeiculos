using LocadoraVeiculos.Dominio.ModuloLocação;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.ModuloLocacao
{
    public class MapeadorLocacaoORM : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TbLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Funcionario);
            builder.Property(x => x.Plano);
            builder.Property(x => x.Taxa);
            builder.Property(x => x.Veiculo);
            builder.Property(x => x.Agrupamento);
            builder.Property(x => x.Condutor);
            builder.Property(x => x.Cliente);
            builder.Property(x => x.DataLocacao).IsRequired(); 
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.ValorInicio).HasColumnType("double").IsRequired(); 
            builder.Property(x => x.ValorFinal).HasColumnType("double").IsRequired();

        }
    }
}
