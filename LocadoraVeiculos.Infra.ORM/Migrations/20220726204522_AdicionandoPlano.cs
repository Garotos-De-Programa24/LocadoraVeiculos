using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoPlano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePlano = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
                    ValorDiario = table.Column<string>(type: "varchar(20)", nullable: false),
                    ValorPorKm = table.Column<string>(type: "varchar(20)", nullable: false),
                    LimiteQuilometragem = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlano_TBAgrupamento_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBAgrupamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlano_GrupoVeiculosId",
                table: "TBPlano",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlano");
        }
    }
}
