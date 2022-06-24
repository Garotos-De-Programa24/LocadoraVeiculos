using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private readonly Cliente cliente;
        private readonly ValidaCliente validador;

        public ValidadorClienteTest()
        {
            cliente = new()
            {
                Nome = "Pedro",
                Cpf = "100.000.000-00",
                Endereco = "Lages",
                CnhCondutor = "1231545215",
                ValidadeCnh = DateTime.Today,
                Email = "pedro@email.com",
                Telefone = "(49) 99999-9999"
            };

            validador = new ValidaCliente();
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            cliente.Nome = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Cpf_Cnpj_Deve_Ser_Obrigatorio()
        {
            //arrange
            cliente.Cpf = null;

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Cpf);
        }

        [TestMethod]
        public void Endereco_Deve_Ser_Obrigatorio()
        {
            //arrange
            cliente.Endereco = null;

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Endereco);
        }

        [TestMethod]
        public void CNH_Condutor_Deve_Ser_Obrigatorio()
        {
            //arrange
            cliente.CnhCondutor = null;

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.CnhCondutor);
        }

        [TestMethod]
        public void Validade_CNH_Deve_Ser_Maior_Que_Data_Atual()
        {
            //arrange
            cliente.ValidadeCnh = DateTime.MinValue;

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.ValidadeCnh);
        }

        [TestMethod]
        public void Email_Deve_Ser_Valido()
        {
            //arrange
            cliente.Email = "dsadasdasad321321";

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Email);
        }
        public void Telefone_Deve_Ser_Valido()
        {
            //arrange
            cliente.Telefone = null;

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Telefone);
        }
    }
}
