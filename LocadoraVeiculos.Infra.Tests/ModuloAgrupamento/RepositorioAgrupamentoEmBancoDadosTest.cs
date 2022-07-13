using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.Tests.ModuloAgrupamento
{
    [TestClass]
    public class RepositorioAgrupamentoEmBancoDadosTest
    {
        private Agrupamento agrupamento;
        private RepositorioAgrupamentoEmBancoDados repositorio;

        public RepositorioAgrupamentoEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBAGRUPAMENTO; DBCC CHECKIDENT (TBAGRUPAMENTO, RESEED, 0)");

            agrupamento = new Agrupamento();
            agrupamento.Nome = "Uber";
            

            repositorio = new RepositorioAgrupamentoEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_agrupamento()
        {
            //action
            repositorio.Inserir(agrupamento);

            //assert
            var agrupamentoEncontrado = repositorio.SelecionarPorId(agrupamento.Id);

            Assert.IsNotNull(agrupamentoEncontrado);
            Assert.AreEqual(agrupamento, agrupamentoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_cliente()
        {
            //arrange                      
            repositorio.Inserir(agrupamento);

            //action
            agrupamento.Nome = "Esportivo";            

            repositorio.Editar(agrupamento);

            //assert
            var agrupamentoEncontrado = repositorio.SelecionarPorId(agrupamento.Id);

            Assert.IsNotNull(agrupamentoEncontrado);
            Assert.AreEqual(agrupamento, agrupamentoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange           
            repositorio.Inserir(agrupamento);

            //action           
            repositorio.Excluir(agrupamento);

            //assert
            var agrupamentoEncontrado = repositorio.SelecionarPorId(agrupamento.Id);
            Assert.IsNull(agrupamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_clientes()
        {
            //arrange          
            repositorio.Inserir(agrupamento);

            //action
            var agrupamentoEncontrado = repositorio.SelecionarPorId(agrupamento.Id);

            //assert
            Assert.IsNotNull(agrupamentoEncontrado);
            Assert.AreEqual(agrupamento, agrupamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var c0 = new Agrupamento("UBER");
            var c1 = new Agrupamento("SUV");
            var c2 = new Agrupamento("Esportivo");

            var repositorio = new RepositorioAgrupamentoEmBancoDados();
            repositorio.Inserir(c0);
            repositorio.Inserir(c1);
            repositorio.Inserir(c2);

            //action
            var agrupamentos = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, agrupamentos.Count);

            Assert.AreEqual(c0.Nome, agrupamentos[0].Nome);
            Assert.AreEqual(c1.Nome, agrupamentos[1].Nome);
            Assert.AreEqual(c2.Nome, agrupamentos[2].Nome);
        }
    }
}
