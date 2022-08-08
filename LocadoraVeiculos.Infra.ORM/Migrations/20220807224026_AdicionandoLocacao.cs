using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlano_TBAgrupamento_GrupoVeiculosId",
                table: "TBPlano");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadePorLocacao",
                table: "TBTaxa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "GrupoVeiculosId",
                table: "TBPlano",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "TBCondutor",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    AgrupamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBAgrupamento_AgrupamentoId",
                        column: x => x.AgrupamentoId,
                        principalTable: "TBAgrupamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgrupamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorInicio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBAgrupamento_AgrupamentoId",
                        column: x => x.AgrupamentoId,
                        principalTable: "TBAgrupamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBPlano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "TBPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TbLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TbLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_AgrupamentoId",
                table: "TbLocacao",
                column: "AgrupamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_ClienteId",
                table: "TbLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_FuncionarioId",
                table: "TbLocacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_PlanoId",
                table: "TbLocacao",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_AgrupamentoId",
                table: "TBVeiculo",
                column: "AgrupamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlano_TBAgrupamento_GrupoVeiculosId",
                table: "TBPlano",
                column: "GrupoVeiculosId",
                principalTable: "TBAgrupamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlano_TBAgrupamento_GrupoVeiculosId",
                table: "TBPlano");

            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TbLocacao");

            migrationBuilder.DropTable(
                name: "TBVeiculo");

            migrationBuilder.DropColumn(
                name: "QuantidadePorLocacao",
                table: "TBTaxa");

            migrationBuilder.AlterColumn<Guid>(
                name: "GrupoVeiculosId",
                table: "TBPlano",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "TBCondutor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlano_TBAgrupamento_GrupoVeiculosId",
                table: "TBPlano",
                column: "GrupoVeiculosId",
                principalTable: "TBAgrupamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
