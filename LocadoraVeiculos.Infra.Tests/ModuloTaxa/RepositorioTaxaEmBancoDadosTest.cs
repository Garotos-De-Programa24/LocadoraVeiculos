using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloTaxa;
using LocadoraVeiculos.Infra.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Tests.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest : BaseIntegrationTest
    {

        private Taxa taxa;
        private RepositorioTaxaEmBancoDados repositorio;

        public RepositorioTaxaEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT (TBTAXA, RESEED, 0)");

            taxa = new Taxa();
            taxa.Equipamento = "Cadeira Infantil";
            taxa.Valor = "80";
            taxa.TaxaDiaria = false;
            
            repositorio = new RepositorioTaxaEmBancoDados();
        }


        [TestMethod]
        public void Deve_inserir_nova_Taxa()
        {
            //action
            repositorio.Inserir(taxa);

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {
            //arrange                      
            repositorio.Inserir(taxa);

            //action
            taxa.Equipamento = "GPS";
            taxa.Valor = "120";

            repositorio.Editar(taxa);

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange           
            repositorio.Inserir(taxa);

            //action           
            repositorio.Excluir(taxa);

            //assert
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);
            Assert.IsNull(taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange          
            repositorio.Inserir(taxa);

            //action
            var taxaEncontrada = repositorio.SelecionarPorId(taxa.Id);

            //assert
            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var funcionario1 = new Taxa("Cadeira Infantil","180", true);
            var funcionario2 = new Taxa("GPS", "120", true);
            var funcionario3 = new Taxa("Frigobar","320", true);

            var repositorio = new RepositorioTaxaEmBancoDados();
            repositorio.Inserir(funcionario1);
            repositorio.Inserir(funcionario2);
            repositorio.Inserir(funcionario3);

            //action
            var funcionarios = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, funcionarios.Count);

            Assert.AreEqual(funcionario1.Equipamento, funcionarios[0].Equipamento);
            Assert.AreEqual(funcionario2.Equipamento, funcionarios[1].Equipamento);
            Assert.AreEqual(funcionario3.Equipamento, funcionarios[2].Equipamento);

        }
    }
}
