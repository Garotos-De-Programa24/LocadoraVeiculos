using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloFuncionario;
using LocadoraVeiculos.Infra.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace LocadoraVeiculos.Infra.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest : BaseIntegrationTest
    {

        private Funcionario funcionario;
        private RepositorioFuncionarioEmBancoDados repositorio;

        public RepositorioFuncionarioEmBancoDadosTest()
        {           
            funcionario = new Funcionario();
            funcionario.Nome = "Alberto Roberto";
            funcionario.Login = "albertoroberto@gmail.com";
            funcionario.Senha = "321";
            funcionario.Salario = "2000";
            funcionario.DataAdmissao = new DateTime(2021,02,02);
            funcionario.Gerente = true;
            repositorio = new RepositorioFuncionarioEmBancoDados();
        }


        [TestMethod]
        public void Deve_inserir_novo_funcionario()
        {
            //action
            repositorio.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_funcionario()
        {
            //arrange                      
            repositorio.Inserir(funcionario);

            //action
            funcionario.Nome = "Pedro Augusto";
            funcionario.Login = "pedro.augusto@funcionario.com";
            funcionario.Senha = "654";

            repositorio.Editar(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange           
            repositorio.Inserir(funcionario);

            //action           
            repositorio.Excluir(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);
            Assert.IsNull(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_funcionario()
        {
            //arrange          
            repositorio.Inserir(funcionario);

            //action
            var funcionarioEncontrado = repositorio.SelecionarPorId(funcionario.Id);

            //assert
            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var funcionario1 = new Funcionario("Joaninha","joaninha@funcionario.com","joaninha123","2000",new DateTime(2022,01,03,01,01,01),false);
            var funcionario2 = new Funcionario("Camila da Silva", "camila.silva@Funcionario.com","camilinha321", "3000", new DateTime(2022, 01, 03, 01, 01, 01), true);
            var funcionario3 = new Funcionario("Joana de Souza", "joana.souza@funcionario.com","Joanona", "2700",new DateTime(2022,01,01,01,01,01),false);

            var repositorio = new RepositorioFuncionarioEmBancoDados();
            repositorio.Inserir(funcionario1);
            repositorio.Inserir(funcionario2);
            repositorio.Inserir(funcionario3);

            //action
            var funcionarios = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, funcionarios.Count);

            Assert.AreEqual(funcionario1.Nome, funcionarios[0].Nome);
            Assert.AreEqual(funcionario2.Nome, funcionarios[1].Nome);
            Assert.AreEqual(funcionario3.Nome, funcionarios[2].Nome);

        }
    }
}
