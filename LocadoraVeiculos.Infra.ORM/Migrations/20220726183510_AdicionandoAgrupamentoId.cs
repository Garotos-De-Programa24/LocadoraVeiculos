using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoAgrupamentoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVeiculo_Agrupamento_AgrupamentoId",
                table: "TBVeiculo");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgrupamentoId",
                table: "TBVeiculo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBVeiculo_Agrupamento_AgrupamentoId",
                table: "TBVeiculo",
                column: "AgrupamentoId",
                principalTable: "Agrupamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVeiculo_Agrupamento_AgrupamentoId",
                table: "TBVeiculo");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgrupamentoId",
                table: "TBVeiculo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVeiculo_Agrupamento_AgrupamentoId",
                table: "TBVeiculo",
                column: "AgrupamentoId",
                principalTable: "Agrupamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
