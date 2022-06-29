using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Dominio.Tests.ModuloTaxa
{
    [TestClass]
    public class ValidadorTaxaTest
    {
        private readonly Taxa taxa;
        private readonly ValidaTaxa validador;

        public ValidadorTaxaTest()
        {
            taxa = new()
            {
                Equipamento = "Cadeira Infantil",                
                Valor = "80",
                TaxaDiaria = false
            };
            validador = new ValidaTaxa();
        }
        [TestMethod]
        public void Equipamento_Deve_Ser_Obrigatorio()
        {
            // arrange
            taxa.Equipamento = null;

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(t => t.Equipamento);
        }
        [TestMethod]
        public void Equipamento_Deve_Ser_Maior_que_3_Caracteres()
        {
            // arrange
            taxa.Equipamento = "A";

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(t => t.Equipamento);
        }
        [TestMethod]
        public void Equipamento_Nao_deve_ser_vazio()
        {
            // arrange
            taxa.Equipamento = "";

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(t => t.Equipamento);
        }
        [TestMethod]
        public void Valor_Deve_Ser_Obrigatorio()
        {
            // arrange
            taxa.Valor = null;

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(t => t.Valor);
        }
        [TestMethod]
        public void Valor_Nao_deve_ser_vazio()
        {
            // arrange
            taxa.Valor = "";

            // action
            var resultado = validador.TestValidate(taxa);

            // assert
            resultado.ShouldHaveValidationErrorFor(t => t.Valor);
        }
    }
}
