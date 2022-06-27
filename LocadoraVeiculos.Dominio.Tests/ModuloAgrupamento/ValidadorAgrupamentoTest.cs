using FluentValidation.TestHelper;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Tests.ModuloAgrupamento
{
    [TestClass]
    public class ValidadorAgrupamentoTest
    {
        private readonly Agrupamento agrupamento;
        private readonly ValidaAgrupamento validador;

        public ValidadorAgrupamentoTest()
        {
            agrupamento = new()
            {
                Nome = "Uber",                
            };

            validador = new ValidaAgrupamento();
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            agrupamento.Nome = null;

            // action
            var resultado = validador.TestValidate(agrupamento);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }        
    }
}
