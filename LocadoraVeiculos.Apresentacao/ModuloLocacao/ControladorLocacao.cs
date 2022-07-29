using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.Modulolocacao;
using LocadoraVeiculos.Dominio.ModuloLocação;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TelaLocacaoControl telaLocacaoControl;
        private readonly ServicoLocacao servicoLocacao;

        public ControladorLocacao(ServicoLocacao servicoLocacao)
        {
            this.servicoLocacao = servicoLocacao;
        }
        public override void Inserir()
        {
            TelaCadastroLocacao tela = new TelaCadastroLocacao();
            tela.Locacao = new Locacao();
            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarLocacao();
        }
        public override void Editar()
        {
            Locacao locacaoSelecionada = ObtemLocacaoSelecionada();
            if (locacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCadastroLocacao tela = new TelaCadastroLocacao();
            tela.Locacao = locacaoSelecionada;
            tela.GravarRegistro = servicoLocacao.Editar;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarLocacao();
            }
        }
        public override void Excluir()
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

        public override UserControl ObtemListagem()
        {
            if (telaLocacaoControl == null)
                telaLocacaoControl = new TelaLocacaoControl();

            CarregarLocacao();

            return telaLocacaoControl;
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
    }
}
