using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private readonly Condutor condutor;
        private readonly ValidaCondutor validador;
        private RepositorioClienteEmBancoDados repositorioCliente;

        public ValidadorCondutorTest()
        {
            condutor = new()
            {
                Cliente = repositorioCliente.SelecionarPorId(1),
                Nome = "João",
                Cpf = "111.111.111.11",
                Endereco = "Lages",
                CnhCondutor = "32131232111",
                ValidadeCnh = DateTime.Today,
                Email = "condutor@gmail.com",
                Telefone = "(049)99999-9999"
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
    }
}