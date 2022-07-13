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

        private RepositorioPlanoCobrancaEmBancoDados repositorioPlano;
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;
        private PlanoCobranca planoCobranca;
        private Agrupamento agrupamento;

        public RepositorioPlanoEmBancoDadosTests()
        {
            repositorioPlano = new RepositorioPlanoCobrancaEmBancoDados();
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
            repositorioPlano.Inserir(planoCobranca);

            //assert
            var planoEncontrado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_Plano()
        {
            //arrange
            repositorioPlano.Inserir(planoCobranca);

            //action
            planoCobranca.NomePlano = "99 Basico";
            planoCobranca.TipoPlano = EnunPlano.Controlado;
            planoCobranca.SetValorDiario("99");
            planoCobranca.SetValorPorKm("5");
            planoCobranca.SetLimiteQuilometragem("8");
            repositorioPlano.Editar(planoCobranca);

            //assert
            var planoEncontrado = repositorioPlano.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_plano()
        {
            //arrange
            var novoPlano = new PlanoCobranca(agrupamento, "teste de Plano", EnunPlano.Livre, 25, 0, 0);
            repositorioPlano.Inserir(novoPlano);

            //action           
            repositorioPlano.Excluir(novoPlano);

            //assert
            var medicamentoEncontrado = repositorioPlano.SelecionarPorId(novoPlano.Id);
            Assert.IsNull(medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_Plano()
        {
            //arrange
            var novoPlano = new PlanoCobranca(agrupamento, "teste de Plano", EnunPlano.Livre, 25, 0, 0);
            repositorioPlano.Inserir(novoPlano);


            //action
            var planoEncontrado = repositorioPlano.SelecionarPorId(novoPlano.Id);

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

            repositorioPlano.Inserir(novoPlano);
            repositorioPlano.Inserir(novoPlano2);
            repositorioPlano.Inserir(novoPlano3);
            // action
            var planoEncontrado = repositorioPlano.SelecionarTodos();

            // assert
            Assert.AreEqual(3, planoEncontrado.Count);

            Assert.AreEqual(novoPlano, planoEncontrado[0]);
            Assert.AreEqual(novoPlano2, planoEncontrado[1]);
            Assert.AreEqual(novoPlano3, planoEncontrado[2]);
        }

    }
    }
