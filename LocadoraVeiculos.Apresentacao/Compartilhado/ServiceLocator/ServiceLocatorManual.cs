using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloLocacao;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCondutor;
using LocadoraVeiculos.Infra.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloTaxa;
using LocadoraVeiculos.Infra.ModuloVeiculo;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ORM.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.ModuloCondutor;
using LocadoraVeiculos.Infra.ORM.ModuloFuncionario;
using LocadoraVeiculos.Infra.ORM.ModuloLocacao;
using LocadoraVeiculos.Infra.ORM.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ORM.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Apresentacao.Compartilhado.ServiceLocator
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;        
        public ServiceLocatorManual()
        {
            InicializarControladores();
        }
        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;
            return (T)controladores[nomeControlador];
        }
        private void InicializarControladores()
        {
            var criadorContexto = new LocadoraVeiculoDbContextFactory();
            var configuracao = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("ConfiguracaoAplicacaoORM.json")
                  .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocadoraVeiculoDbContext(connectionString);
            //--------------------------------------------------------------------
            //Configuração sem ORM 
            //var repositorioCliente = new RepositorioClienteEmBancoDados();
            //var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            //var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            //var repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();
            //var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            //var repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmBancoDados();
            //var repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            //----------------------------------------------------------------------

            var repositorioFuncionario = new RepositorioFuncionarioORM(contextoDadosOrm);
            var repositorioCliente = new RepositorioClienteORM(contextoDadosOrm);
            var repositorioAgrupamento = new RepositorioAgrupamentoORM(contextoDadosOrm);
            var repositorioTaxa = new RepositorioTaxaORM(contextoDadosOrm);
            var repositorioCondutor = new RepositorioCondutorORM(contextoDadosOrm);
            var repositorioPlanoCobranca = new RepositorioPlanoDeCobrancaORM(contextoDadosOrm);
            var repositorioVeiculo = new RepositorioVeiculoORM(contextoDadosOrm);
            var repositorioLocacao = new RepositorioLocacaoORM(contextoDadosOrm);

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario,contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente,contextoDadosOrm);
            var servicoGrupoVeiculo = new ServicoAgrupamento(repositorioAgrupamento,contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa,contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor,contextoDadosOrm);
            var servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca,contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo,contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm);

            var funcionario = new Funcionario(); 
            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));
            controladores.Add("ControladorAgrupamento", new ControladorAgrupamento(servicoGrupoVeiculo));
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor,servicoCliente));
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlanoCobranca,servicoGrupoVeiculo));
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo,servicoGrupoVeiculo));
            controladores.Add("ControladorLocacao", new ControladorLocacao(servicoLocacao,servicoGrupoVeiculo,servicoCondutor,servicoCliente,servicoVeiculo,servicoTaxa,servicoPlanoCobranca));
        }
    }
}
