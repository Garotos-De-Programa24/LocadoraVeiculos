using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloFuncionario
{
    public class MapeadorFuncionarioORM : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Salario).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.DataAdmissao).IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Gerente);
        }
    }
}
