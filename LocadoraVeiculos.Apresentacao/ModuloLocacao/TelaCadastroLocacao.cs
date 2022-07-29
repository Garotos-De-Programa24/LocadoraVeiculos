using FluentResults;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloLocação;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCondutor;
using LocadoraVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloTaxa;
using LocadoraVeiculos.Infra.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.Modulolocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        //repositorios
        private RepositorioClienteEmBancoDados repositorioCliente;
        private RepositorioCondutorEmBancoDados repositorioCondutor;
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;
        private RepositorioVeiculoEmBancoDados repositorioVeiculo;
        private RepositorioPlanoCobrancaEmBancoDados repositorioPlano;
        private RepositorioTaxaEmBancoDados repositorioTaxa;
        public TelaCadastroLocacao()
        {
            InitializeComponent();
            //gerar repositorios
            repositorioCliente = new RepositorioClienteEmBancoDados();
            repositorioCondutor = new RepositorioCondutorEmBancoDados();
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();
            repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            repositorioPlano = new RepositorioPlanoCobrancaEmBancoDados();
            repositorioTaxa = new RepositorioTaxaEmBancoDados();

            //configurar combo box iniciais

            List<Cliente> clientes = repositorioCliente.SelecionarTodos();
            foreach (Cliente c in clientes)            
                cboxCliente.Items.Add(c);

            List<Agrupamento> agrupamentos = repositorioAgrupamento.SelecionarTodos();
            foreach (Agrupamento a in agrupamentos)            
                cboxCliente.Items.Add(a);

            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();
            foreach (Taxa t in taxas)
                cboxCliente.Items.Add(t);
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao locacao { get; set; }

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;

            }
        }

       
    }
}