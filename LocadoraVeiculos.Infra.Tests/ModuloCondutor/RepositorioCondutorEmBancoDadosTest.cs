using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace LocadoraVeiculos.Infra.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTest
    {
        private Condutor condutor;
        private RepositorioCondutorEmBancoDados repositorio;
        private RepositorioClienteEmBancoDados repositorioCliente;

        public RepositorioCondutorEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBCONDUTOR; DBCC CHECKIDENT (TBCONDUTOR, RESEED, 0)");
            
            repositorioCliente = new RepositorioClienteEmBancoDados();
            repositorio = new RepositorioCondutorEmBancoDados();

            condutor = new Condutor();            
            condutor.Cliente = repositorioCliente.SelecionarPorId(1);
            condutor.Nome = "João";
            condutor.Cpf = "111.111.111.11";
            condutor.Endereco = "Lages";
            condutor.CnhCondutor = "32131232111";
            condutor.ValidadeCnh = DateTime.Today;
            condutor.Email = "condutor@gmail.com";
            condutor.Telefone = "(049)99999-9999";
        }


        [TestMethod]
        public void Deve_inserir_novo_condutor()
        {
            //action
            repositorio.Inserir(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_condutor()
        {
            //arrange                      
            repositorio.Inserir(condutor);

            //action            
            condutor.Cliente = repositorioCliente.SelecionarPorId(2);
            condutor.Nome = "Pedro";
            condutor.Cpf = "222.222.222-22";
            condutor.Endereco = "Centro";
            condutor.CnhCondutor = "00000000000";
            condutor.ValidadeCnh = DateTime.Today;
            condutor.Email = "condutorEditado@gmail.com";
            condutor.Telefone = "(049)00000-0000";

            repositorio.Editar(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange           
            repositorio.Inserir(condutor);

            //action           
            repositorio.Excluir(condutor);

            //assert
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);
            Assert.IsNull(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_condutor()
        {
            //arrange          
            repositorio.Inserir(condutor);

            //action
            var condutorEncontrado = repositorio.SelecionarPorId(condutor.Id);

            //assert
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(condutor, condutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_condutores()
        {
            //arrange
            var condutor1 = new Condutor(repositorioCliente.SelecionarPorId(1), "Pedro", "111.111.111-11", "Rua", "00000000000", DateTime.Today, "condutor1@gmail.com", "(049)00000-0000");
            var condutor2 = new Condutor(repositorioCliente.SelecionarPorId(2), "Luiz", "222.222.222-22", "Praça", "11111111111", DateTime.Today.AddDays(3), "condutor2@gmail.com", "(049)11111-1111");
            var condutor3 = new Condutor(repositorioCliente.SelecionarPorId(3), "José", "333.333.333-33", "Centro", "22222222222", DateTime.Today.AddDays(5), "condutor3@gmail.com", "(049)22222-2222");

            var repositorio = new RepositorioCondutorEmBancoDados();
            repositorio.Inserir(condutor1);
            repositorio.Inserir(condutor2);
            repositorio.Inserir(condutor3);

            //action
            var condutores = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, condutores.Count);

            Assert.AreEqual(condutor1.Nome, condutores[0].Nome);
            Assert.AreEqual(condutor2.Nome, condutores[1].Nome);
            Assert.AreEqual(condutor3.Nome, condutores[2].Nome);

        }
    }
}
