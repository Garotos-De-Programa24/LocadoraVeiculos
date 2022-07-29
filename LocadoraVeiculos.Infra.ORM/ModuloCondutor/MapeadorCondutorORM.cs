using LocadoraVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.ModuloCondutor
{
    public class MapeadorCondutorORM : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Cliente);
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(40)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.CnhCondutor).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ValidadeCnh).HasColumnType("date").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(20)").IsRequired();



        }
    }
}
