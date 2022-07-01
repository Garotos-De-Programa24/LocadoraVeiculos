using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        private Cliente cliente;
        private RepositorioClienteEmBancoDados repositorio;

        public RepositorioClienteEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBCONDUTOR; DBCC CHECKIDENT (TBCONDUTOR, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            cliente = new Cliente();
            cliente.Nome = "Pedro";
            cliente.CpfCnpj = "100.000.000-00";
            cliente.Endereco = "Lages";
            cliente.Email = "pedro@email.com";
            cliente.Telefone = "(49) 99999-9999";

            repositorio = new RepositorioClienteEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_cliente()
        {
            //arrange                      
            repositorio.Inserir(cliente);

            //action
            cliente.Nome = "Joao";
            cliente.CpfCnpj = "100.000.000-10";
            cliente.Endereco = "Lages-Sc";
            cliente.Email = "joao@email.com";
            cliente.Telefone = "(49) 00000-0000";

            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange           
            repositorio.Inserir(cliente);

            //action           
            repositorio.Excluir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);
            Assert.IsNull(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_clientes()
        {
            //arrange          
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var c0 = new Cliente("lucas", "000.000.000-00", "Lages", "lucas@gmail.com",  "(049) 99999-9999");
            var c1 = new Cliente("tiago", "111.111.111-11", "Lages", "tiago@gmail.com", "(049) 88888-8888");
            var c2 = new Cliente("luiza", "222.222.222-22", "Lages", "riomed@gmail.com", "(049) 77777-7777");

            var repositorio = new RepositorioClienteEmBancoDados();
            repositorio.Inserir(c0);
            repositorio.Inserir(c1);
            repositorio.Inserir(c2);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, clientes.Count);

            Assert.AreEqual(c0.Nome, clientes[0].Nome);
            Assert.AreEqual(c1.Nome, clientes[1].Nome);
            Assert.AreEqual(c2.Nome, clientes[2].Nome);
        }
    }
}
