using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                CpfCnpj = "100.000.000-00",
                Endereco = "Lages",
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
            cliente.CpfCnpj = null;

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.CpfCnpj);
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
        public void Email_Deve_Ser_Valido()
        {
            //arrange
            cliente.Email = "dsadasdasad321321";

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [TestMethod]
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
