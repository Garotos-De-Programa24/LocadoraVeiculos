using Autofac;
using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ORM.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ORM.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.ModuloCondutor;
using LocadoraVeiculos.Infra.ORM.ModuloFuncionario;
using LocadoraVeiculos.Infra.ORM.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ORM.ModuloVeiculo;

namespace LocadoraVeiculos.Apresentacao.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutoFac : IServiceLocator
    {
        private readonly IContainer container;
       
        public ServiceLocatorComAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioClienteORM>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioAgrupamentoORM>().As<IRepositorioAgrupamento>();
            builder.RegisterType<ServicoAgrupamento>().AsSelf();
            builder.RegisterType<ControladorAgrupamento>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioORM>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorORM>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxaORM>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioPlanoDeCobrancaORM>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();

            builder.RegisterType<RepositorioVeiculoORM>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            container = builder.Build();
        }
        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
