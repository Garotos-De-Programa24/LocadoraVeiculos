using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
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

        private ServicoCondutor servicoCondutor;
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

            servicoCondutor = new ServicoCondutor();
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

        private void cboxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cboxCliente.SelectedItem;

            var resultado = servicoCondutor.SelecionarPorClienteId(cliente.Id);

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                AtualizarCondutores(condutores);
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de Locação",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AtualizarCondutores(List<Condutor> condutores)
        {
            cboxCondutor.Items.Clear();

            foreach(Condutor c in condutores)
            cboxCondutor.Items.Add(c);
        }
    }
}