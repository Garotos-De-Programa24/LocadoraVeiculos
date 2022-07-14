using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.Tests.ModuloPlano
{
    [TestClass]
    public class RepositorioPlanoEmBancoDadosTests : BaseIntegrationTest
    {  

        private RepositorioPlanoCobrancaEmBancoDados repositorio = new RepositorioPlanoCobrancaEmBancoDados();
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;
        private PlanoCobranca planoCobranca;
        private Agrupamento agrupamento;

        public RepositorioPlanoEmBancoDadosTests()
        {
            repositorio = new RepositorioPlanoCobrancaEmBancoDados();
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();

            agrupamento = new Agrupamento();
            agrupamento.Nome = "UBER";
            repositorioAgrupamento.Inserir(agrupamento);

            planoCobranca = new PlanoCobranca();
            planoCobranca.GrupoVeiculos = agrupamento;
            planoCobranca.NomePlano = "Uber Basico";
            planoCobranca.TipoPlano = EnunPlano.Diario;
            planoCobranca.SetValorDiario("45");
            planoCobranca.SetValorPorKm("52");
            planoCobranca.SetLimiteQuilometragem("80");
        }


        [TestMethod]
        public void Deve_inserir_novo_plano()
        {
            //action            
            repositorio.Inserir(planoCobranca);

            //assert
            var planoEncontrado = repositorio.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_Plano()
        {
            //arrange
            repositorio.Inserir(planoCobranca);

            //action
            planoCobranca.NomePlano = "99 Basico";
            planoCobranca.TipoPlano = EnunPlano.Controlado;
            planoCobranca.SetValorDiario("99");
            planoCobranca.SetValorPorKm("5");
            planoCobranca.SetLimiteQuilometragem("8");
            repositorio.Editar(planoCobranca);

            //assert
            var planoEncontrado = repositorio.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_plano()
        {
            //arrange
            var novoPlano = new PlanoCobranca(agrupamento, "teste de Plano", EnunPlano.Livre, 25, 0, 0);
            repositorio.Inserir(novoPlano);

            //action           
            repositorio.Excluir(novoPlano);

            //assert
            var medicamentoEncontrado = repositorio.SelecionarPorId(novoPlano.Id);
            Assert.IsNull(medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_Plano()
        {
            //arrange
            var novoPlano = new PlanoCobranca(agrupamento, "teste de Plano", EnunPlano.Livre, 25, 0, 0);
            repositorio.Inserir(novoPlano);


            //action
            var planoEncontrado = repositorio.SelecionarPorId(novoPlano.Id);

            //assert
            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoEncontrado, planoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_Planos()
        {
            //arrange
            var novoPlano = new PlanoCobranca(agrupamento, "Uber Basico", EnunPlano.Livre, 25, 0, 0); 

            var novoPlano2 = new PlanoCobranca(agrupamento, "99 Sem Fronteiras", EnunPlano.Controlado, 25, 8, 56);

            var novoPlano3 = new PlanoCobranca(agrupamento, "Para Quem é muito Rico!", EnunPlano.Controlado, 10000, 250, 60000);

            repositorio.Inserir(novoPlano);
            repositorio.Inserir(novoPlano2);
            repositorio.Inserir(novoPlano3);
            // action
            var planoEncontrado = repositorio.SelecionarTodos();

            // assert
            Assert.AreEqual(3, planoEncontrado.Count);

            Assert.AreEqual(novoPlano, planoEncontrado[0]);
            Assert.AreEqual(novoPlano2, planoEncontrado[1]);
            Assert.AreEqual(novoPlano3, planoEncontrado[2]);
        }

    }
    }
