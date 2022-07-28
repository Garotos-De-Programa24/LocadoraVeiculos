using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloVeiculo
{
    public class MapeadorVeiculoORM : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Agrupamento);
            builder.Property(x => x.VeiculoNome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ano).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.KmPercorridos).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Combustivel).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Foto).HasColumnType("varbinary(MAX)");
            builder.Property(x => x.Disponivel);
        }
    }
}
