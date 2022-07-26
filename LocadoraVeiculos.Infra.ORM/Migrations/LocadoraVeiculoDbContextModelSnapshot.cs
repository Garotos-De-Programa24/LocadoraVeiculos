﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    [DbContext(typeof(LocadoraVeiculoDbContext))]
    partial class LocadoraVeiculoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloAgrupamento.Agrupamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agrupamento");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TBCliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CnhCondutor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("ValidadeCnh")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBCondutor");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LimiteQuilometragem")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NomePlano")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.Property<string>("ValorDiario")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ValorPorKm")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TBPlano");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgrupamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CaminhoDaFotoNaMaquina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapacidadeTanque")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Combustivel")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(MAX)");

                    b.Property<string>("KmPercorridos")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("VeiculoNome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AgrupamentoId");

                    b.ToTable("TBVeiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloAgrupamento.Agrupamento", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId");

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloAgrupamento.Agrupamento", "Agrupamento")
                        .WithMany()
                        .HasForeignKey("AgrupamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agrupamento");
                });
#pragma warning restore 612, 618
        }
    }
}