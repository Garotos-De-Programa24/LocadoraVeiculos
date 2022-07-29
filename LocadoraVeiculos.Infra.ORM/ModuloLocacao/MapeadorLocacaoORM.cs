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
            builder.HasOne(x => x.Funcionario);
            builder.HasOne(x => x.Plano);
            builder.HasOne(x => x.Taxa);
            builder.HasOne(x => x.Veiculo);
            builder.HasOne(x => x.Agrupamento);
            builder.HasOne(x => x.Condutor);
            builder.HasOne(x => x.Cliente);
            builder.Property(x => x.DataLocacao).IsRequired(); 
            builder.Property(x => x.DataDevolucao);
            builder.Property(x => x.ValorInicio).HasColumnType("decimal(18,2)"); 
            builder.Property(x => x.ValorFinal).HasColumnType("decimal(18,2)");

            
        }
    }
}
