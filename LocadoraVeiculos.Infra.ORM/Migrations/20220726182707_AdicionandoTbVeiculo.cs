using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoTbVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(MAX)", nullable: true),
                    CaminhoDaFotoNaMaquina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeiculoNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ano = table.Column<string>(type: "varchar(20)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(20)", nullable: false),
                    CapacidadeTanque = table.Column<string>(type: "varchar(50)", nullable: false),
                    KmPercorridos = table.Column<string>(type: "varchar(50)", nullable: false),
                    Combustivel = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(50)", nullable: false),
                    AgrupamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_Agrupamento_AgrupamentoId",
                        column: x => x.AgrupamentoId,
                        principalTable: "Agrupamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_AgrupamentoId",
                table: "TBVeiculo",
                column: "AgrupamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBVeiculo");
        }
    }
}
