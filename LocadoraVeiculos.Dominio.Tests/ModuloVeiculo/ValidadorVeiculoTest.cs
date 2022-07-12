using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Dominio.Tests.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTest
    {
        private readonly Veiculo veiculo;
        private readonly ValidaVeiculo validador;
        private readonly RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;

        public ValidadorVeiculoTest()
        {
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();
            veiculo = new()
            {
                VeiculoNome = "Ranger",
                Ano = "2001",
                Marca = "Ford",
                Placa = "CLB1238",
                CapacidadeTanque = "68 Litros",
                KmPercorridos = "103400",
                Combustivel = "Diesel",
                Cor = "Prata",                
            };
            veiculo.Agrupamento = repositorioAgrupamento.SelecionarPorId(1);

            validador = new ValidaVeiculo();
        }

        [TestMethod]
        public void VeiculoNome_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.VeiculoNome = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.VeiculoNome);
        }

        [TestMethod]
        public void Ano_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.Ano = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.Ano);
        }

        [TestMethod]
        public void Marca_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.Marca = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.Marca);
        }

        [TestMethod]
        public void Placa_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.Placa = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.Placa);
        }

        [TestMethod]
        public void CapacidadeDoTanque_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.CapacidadeTanque = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.CapacidadeTanque);
        }

        [TestMethod]
        public void KmPercorrido_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.KmPercorridos = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.KmPercorridos);
        }

        [TestMethod]
        public void TipoDeCombustivel_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.Combustivel = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.Combustivel);
        }

        [TestMethod]
        public void Cor_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.Cor = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.Cor);
        }

        [TestMethod]
        public void Agrupamento_Deve_Ser_Obrigatorio()
        {
            // arrange
            veiculo.Agrupamento = null;

            // action
            var resultado = validador.TestValidate(veiculo);

            // assert
            resultado.ShouldHaveValidationErrorFor(v => v.Agrupamento);
        }
    }
}
