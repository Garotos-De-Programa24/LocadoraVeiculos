using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.Modulolocacao;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloLocação;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TelaLocacaoControl telaLocacaoControl;

        private readonly ServicoLocacao servicoLocacao;
        private ServicoAgrupamento servicoAgrupamento;
        private ServicoCondutor servicoCondutor;
        private ServicoCliente servicoCliente;
        private ServicoVeiculo servicoVeiculo;
        private ServicoTaxa servicoTaxa;
        private ServicoPlanoCobranca servicoPlano;
        private ServicoFuncionario servicoFuncionario;
        

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoAgrupamento servicoAgrupamento, ServicoCondutor servicoCondutor,
            ServicoCliente servicoCliente, ServicoVeiculo servicoVeiculo, ServicoTaxa servicoTaxa, ServicoPlanoCobranca servicoPlano)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoAgrupamento = servicoAgrupamento;
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoTaxa = servicoTaxa;
            this.servicoPlano = servicoPlano;
            this.servicoFuncionario = servicoFuncionario;
            
        }

        public override void Inserir(Funcionario funcionario)
        {
            TelaCadastroLocacao tela = new TelaCadastroLocacao(ObterAgrupamentos(), ObterClientes(), ObterTaxas(), ObterPlanos(),
                                                                ObterVeiculos(), ObterCondutores(),funcionario);
            tela.Locacao = new Locacao();
            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarLocacao();
        }

        public override void Editar(Funcionario funcionario)
        {
            Locacao locacaoSelecionada = ObtemLocacaoSelecionada();
            if (locacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCadastroLocacao tela = new TelaCadastroLocacao(ObterAgrupamentos(), ObterClientes(), ObterTaxas(), ObterPlanos(),
                                                                ObterVeiculos(), ObterCondutores(),funcionario);
            tela.Locacao = locacaoSelecionada;
            tela.GravarRegistro = servicoLocacao.Editar;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarLocacao();
            }
        }
        public override void Excluir(Funcionario funcionario)
        {
            Locacao locacaoSelecionada = ObtemLocacaoSelecionada();

            if (locacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Locação",
                "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir esta Locação?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoLocacao.Excluir(locacaoSelecionada);
                CarregarLocacao();
            }

        }
        
        private void CarregarLocacao()
        {
            var resultado = servicoLocacao.SelecionarTodos();
            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                telaLocacaoControl.AtualizarRegistros(locacoes);
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar todos as locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Locacao ObtemLocacaoSelecionada()
        {
            var id = telaLocacaoControl.ObtemNumeroLocacaoSelecionado();
            var resultado = servicoLocacao.SelecionarPorId(id);
            Locacao locacaoSelecionada = null;
            if (resultado.IsSuccess)
            {
                locacaoSelecionada = resultado.Value;

            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar a Locação",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return locacaoSelecionada;
        }
        public override UserControl ObtemListagem()
        {
            if (telaLocacaoControl == null)
                telaLocacaoControl = new TelaLocacaoControl();

            CarregarLocacao();

            return telaLocacaoControl;
        }

        //region
        #region Listas

        //private Funcionario ObterFuncionarioLogado()
        //{
            
        //    var id = telaLocacaoControl.ObtemNumeroLocacaoSelecionado();
        //    var resultado = servicoLocacao.SelecionarPorId(id);
        //    Locacao locacaoSelecionada = null;
        //    if (resultado.IsSuccess)
        //    {
        //        locacaoSelecionada = resultado.Value;

        //    }
        //    else if (resultado.IsFailed)
        //    {
        //        MessageBox.Show(resultado.Errors[0].Message, "Selecionar a Locação",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return locacaoSelecionada;

        //}
        private List<Condutor> ObterCondutores()
        {
            var resultadoDoresult = servicoCondutor.SelecionarTodos();
            List<Condutor> condutores = new List<Condutor>();

            if (resultadoDoresult.IsSuccess)
                condutores = resultadoDoresult.Value;

            return condutores;
        }

        private List<Veiculo> ObterVeiculos()
        {
            var resultadoDoresult = servicoVeiculo.SelecionarTodos();
            List<Veiculo> veiculos = new List<Veiculo>();

            if (resultadoDoresult.IsSuccess)
                veiculos = resultadoDoresult.Value;

            return veiculos;
        }

        private List<PlanoCobranca> ObterPlanos()
        {
            var resultadoDoresult = servicoPlano.SelecionarTodos();
            List<PlanoCobranca> planos = new List<PlanoCobranca>();

            if (resultadoDoresult.IsSuccess)
                planos = resultadoDoresult.Value;

            return planos;
        }

        private List<Taxa> ObterTaxas()
        {
            var resultadoDoresult = servicoTaxa.SelecionarTodos();
            List<Taxa> taxas = new List<Taxa>();

            if (resultadoDoresult.IsSuccess)
                taxas = resultadoDoresult.Value;

            return taxas;
        }

        private List<Cliente> ObterClientes()
        {
            var resultadoDoresult = servicoCliente.SelecionarTodos();
            List<Cliente> clientes = new List<Cliente>();

            if (resultadoDoresult.IsSuccess)
                clientes = resultadoDoresult.Value;

            return clientes;
        }

        private List<Agrupamento> ObterAgrupamentos()
        {
            var resultadoDoresult = servicoAgrupamento.SelecionarTodos();
            List<Agrupamento> agrupamentos = new List<Agrupamento>();

            if (resultadoDoresult.IsSuccess)
                agrupamentos = resultadoDoresult.Value;

            return agrupamentos;
        }

        #endregion
    }
}
