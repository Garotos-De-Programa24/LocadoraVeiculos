using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.Dominio.Tests.ModuloPlano
{
    [TestClass]
    public class ValidadorPlanoTest
    {
        private readonly PlanoCobranca planoCobranca;
        private readonly ValidaPlanoCobranca validador;
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;
        private Agrupamento agrupamento;
        public ValidadorPlanoTest()
        {
            agrupamento.Nome = "Uber";
            repositorioAgrupamento.Inserir(agrupamento);
            planoCobranca = new()
            {
                NomePlano = "Teste Para Uber",
                TipoPlano = EnunPlano.Controlado
            };
            planoCobranca.SetLimiteQuilometragem("25");
            planoCobranca.SetValorDiario("45");
            planoCobranca.SetValorPorKm("55");
            planoCobranca.GrupoVeiculos = agrupamento;

            validador = new ValidaPlanoCobranca();
        }
        [TestMethod]
        public void Agrupamento_Não_Pode_Ser_Nulo()
        {
            //arrange
            planoCobranca.GrupoVeiculos = null;

            //action
            var resultado = validador.TestValidate(planoCobranca);

            //assert
            resultado.ShouldHaveValidationErrorFor(g => g.GrupoVeiculos);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            //arrange
            planoCobranca.NomePlano = null;

            //action
            var resultado = validador.TestValidate(planoCobranca);

            //assert
            resultado.ShouldHaveValidationErrorFor(n => n.NomePlano);

        }

        [TestMethod]
        public void Nome_Deve_Ser_Vazio()
        {
            //arrange
            planoCobranca.NomePlano = "";

            //action
            var resultado = validador.TestValidate(planoCobranca);

            //assert
            resultado.ShouldHaveValidationErrorFor(n => n.NomePlano);

        }
        [TestMethod]
        public void Nome_Deve_Ser_Menor_3Caracter()
        {
            //arrange
            planoCobranca.NomePlano = "as";

            //action
            var resultado = validador.TestValidate(planoCobranca);

            //assert
            resultado.ShouldHaveValidationErrorFor(n => n.NomePlano);

        }
    }
}
