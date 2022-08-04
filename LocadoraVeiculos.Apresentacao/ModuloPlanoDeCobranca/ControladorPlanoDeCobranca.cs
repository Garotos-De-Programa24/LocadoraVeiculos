using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobrança;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private TelaPlanoCobrancaControl telaPlanoCobrancaControl;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private ServicoAgrupamento servicoAgrupamento;

        public ControladorPlanoDeCobranca(ServicoPlanoCobranca servicoPlanoCobranca, ServicoAgrupamento servicoAgrupamento)
        {
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoAgrupamento = servicoAgrupamento;
        }
        public override void Inserir(Funcionario funcionario)
        {
            List<Agrupamento> clientes = servicoAgrupamento.SelecionarTodos().Value;
            TelaCadastroPlanoCobranca tela = new TelaCadastroPlanoCobranca(clientes);
            tela.PlanoCobranca = new PlanoCobranca();
            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarPlanosDeCobranca();
        }
        public override void Editar(Funcionario funcionario)
        {
            PlanoCobranca planoSelecionado = ObtemPlanoSelecionado();
            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione uma Plano de Cobrança primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<Agrupamento> clientes = servicoAgrupamento.SelecionarTodos().Value;
            TelaCadastroPlanoCobranca tela = new TelaCadastroPlanoCobranca(clientes);
            tela.PlanoCobranca = planoSelecionado;
            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }
        }
        public override void Excluir(Funcionario funcionario)
        {
            PlanoCobranca planoSelecioando = ObtemPlanoSelecionado();

            if (planoSelecioando == null)
            {
                MessageBox.Show("Selecione um plano de Cobrança",
                "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este Plano?",
                "Exclusão de Condutores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoPlanoCobranca.Excluir(planoSelecioando);
                CarregarPlanosDeCobranca();
            }

        }

        public override UserControl ObtemListagem()
        {
            if (telaPlanoCobrancaControl == null)
                telaPlanoCobrancaControl = new TelaPlanoCobrancaControl();

            CarregarPlanosDeCobranca();

            return telaPlanoCobrancaControl;
        }
        private void CarregarPlanosDeCobranca()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();
            if (resultado.IsSuccess)
            {
                List<PlanoCobranca> funcionarios = resultado.Value;

                telaPlanoCobrancaControl.AtualizarRegistros(funcionarios);
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar todos os Funcionarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private PlanoCobranca ObtemPlanoSelecionado()
        {
            var id = telaPlanoCobrancaControl.ObtemNumeroPlanoCobrancaSelecionado();
            var resultado = servicoPlanoCobranca.SelecionarPorId(id);
            PlanoCobranca planoSelecionado = null;
            if (resultado.IsSuccess)
            {
                planoSelecionado = resultado.Value;

            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar a Taxa Selecionada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return planoSelecionado;
        }
    }
}
