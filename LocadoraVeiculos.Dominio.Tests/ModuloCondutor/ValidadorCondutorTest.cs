using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private readonly Condutor condutor;
        private readonly ValidaCondutor validador;
        private RepositorioClienteEmBancoDados repositorioCliente;
        private Cliente cliente;
        public ValidadorCondutorTest()
        {
            repositorioCliente = new RepositorioClienteEmBancoDados();

            cliente = new Cliente();
            cliente.Nome = "Pedro";
            cliente.CpfCnpj = "100.000.000-00";
            cliente.Endereco = "Lages";
            cliente.Email = "pedro@email.com";
            cliente.Telefone = "(49)99999-9999";
            repositorioCliente.Inserir(cliente);

            condutor = new()
            {
                Nome = "João",
                Cpf = "111.111.111.11",
                Endereco = "Lages",
                CnhCondutor = "32131232111",
                ValidadeCnh = DateTime.Today,
                Email = "condutor@gmail.com",
                Telefone = "(049)99999-9999",
                Cliente = cliente,
            };

            validador = new ValidaCondutor();
        }

        [TestMethod]
        public void Cliente_Nao_Pode_Ser_Nulo()
        {
            // arrange
            condutor.Cliente = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cliente);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            condutor.Nome = null;

            // action
            var resultado = validador.TestValidate(condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Cpf_Deve_Ser_Obrigatorio()
        {
            //arrange
            condutor.Cpf = null;

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Cpf);
        }

        [TestMethod]
        public void Endereco_Deve_Ser_Obrigatorio()
        {
            //arrange
            condutor.Endereco = null;

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Endereco);
        }

        [TestMethod]
        public void Email_Deve_Ser_Valido()
        {
            //arrange
            condutor.Email = "dsadasdasad321321";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [TestMethod]
        public void Telefone_Deve_Ser_Valido()
        {
            //arrange
            condutor.Telefone = null;

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Telefone);
        }

        [TestMethod]
        public void CNH_Condutor_Eh_Obrigatorio()
        {
            //arrange
            condutor.CnhCondutor = null;

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.CnhCondutor);
        }
        [TestMethod]
        public void Validade_CNH_Deve_Ser_Maior_DataAtual()
        {
            //arrange
            condutor.ValidadeCnh = DateTime.Today.AddDays(-1);

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.ValidadeCnh);
        }
    }
}