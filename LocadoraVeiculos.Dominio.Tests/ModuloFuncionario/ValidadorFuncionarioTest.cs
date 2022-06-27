using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private readonly Funcionario funcionario;
        private readonly ValidaFuncionario validador;

        public ValidadorFuncionarioTest()
        {
            funcionario = new()
            {
                Nome = "Junin da Van",
                Login = "juninDaVan@Funcionario.com",
                Senha = "junin123*",
                Salario = "1250",
                DataAdmissao = DateTime.Today,
                Gerente = false
            };
            validador = new ValidaFuncionario();
        }
        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            funcionario.Nome = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }
        [TestMethod]
        public void Nome_Deve_Ser_Maior_que_3_Caracteres()
        {
            // arrange
            funcionario.Nome = "An";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Nao_deve_ser_vazio()
        {
            // arrange
            funcionario.Nome = "";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }
        [TestMethod]
        public void Login_Deve_Ser_Valido()
        {
            // arrange
            funcionario.Login = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Senha_Deve_Ser_Obrigatorio()
        {
            // arrange
            funcionario.Senha = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Senha_Deve_Ser_Maior_que_3_Caracteres()
        {
            // arrange
            funcionario.Senha = "An";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }
        [TestMethod]
        public void Senha_Nao_deve_ser_vazio()
        {
            // arrange
            funcionario.Senha = "";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }
        [TestMethod]
        public void Salario_Deve_Ser_Obrigatorio()
        {
            // arrange
            funcionario.Salario = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Salario);
        }

        [TestMethod]
        public void Data_De_Admissao_deve_ser_Maior_Que_Data_Atual()
        {
            //arrange
            funcionario.DataAdmissao = DateTime.MinValue;

            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(c => c.DataAdmissao);
        }
    }
}
