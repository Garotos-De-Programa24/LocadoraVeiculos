using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloAgrupamento
{
    public class ControladorAgrupamento : ControladorBase
    {
        private readonly IRepositorioAgrupamento repositorioAgrupamento;
        private TelaAgrupamentoControl telaAgrupamentoControl;
        private readonly ServicoAgrupamento servicoAgrupamento;

        public ControladorAgrupamento(IRepositorioAgrupamento repositorioAgrupamento, ServicoAgrupamento servicoAgrupamento)
        {
            this.repositorioAgrupamento = repositorioAgrupamento;
            this.servicoAgrupamento = servicoAgrupamento;
        }

        public override void Inserir()
        {
            TelaCadastroAgrupamento tela = new TelaCadastroAgrupamento();
            tela.Agrupamento = new Agrupamento();
            tela.GravarRegistro = servicoAgrupamento.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarAgrupamentos();
        }

        public override void Editar()
        {
            Agrupamento agrupamentoSelecionado = ObtemAgrupamentoSelecionado();

            if (agrupamentoSelecionado == null)
            {
                MessageBox.Show("Selecione um agrupamento primeiro",
                "Edição de Agrupamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroAgrupamento tela = new TelaCadastroAgrupamento();

            tela.Agrupamento = agrupamentoSelecionado;

            tela.GravarRegistro = servicoAgrupamento.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarAgrupamentos();

        }

        public override void Excluir()
        {
            Agrupamento agrupamentoSelecionado = ObtemAgrupamentoSelecionado();

            if (agrupamentoSelecionado == null)
            {
                MessageBox.Show("Selecione um agrupamento primeiro",
                "Exclusão de Agrupamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Agrupamento?",
                "Exclusão de Agrupamentos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioAgrupamento.Excluir(agrupamentoSelecionado);
                CarregarAgrupamentos();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (telaAgrupamentoControl == null)
                telaAgrupamentoControl = new TelaAgrupamentoControl();

            CarregarAgrupamentos();

            return telaAgrupamentoControl;
        }

        private void CarregarAgrupamentos()
        {
            List<Agrupamento> clientes = repositorioAgrupamento.SelecionarTodos();

            telaAgrupamentoControl.AtualizarRegistros(clientes);
        }

        private Agrupamento ObtemAgrupamentoSelecionado()
        {
            var id = telaAgrupamentoControl.ObtemNumeroAgrupamentoSelecionado();

            return repositorioAgrupamento.SelecionarPorId(id);
        }
    }
}
