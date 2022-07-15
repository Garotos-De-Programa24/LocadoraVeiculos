using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobrança;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private TelaPlanoCobrancaControl telaPlanoCobrancaControl;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;

        public ControladorPlanoDeCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, ServicoPlanoCobranca servicoPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
        }
        public override void Inserir()
        {
            TelaCadastroPlanoCobranca tela = new TelaCadastroPlanoCobranca();
            tela.PlanoCobranca = new PlanoCobranca();
            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarPlanosDeCobranca();
        }
        public override void Editar()
        {
            PlanoCobranca planoSelecionado = ObtemPlanoSelecionado();
            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione uma Plano de Cobrança primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCadastroPlanoCobranca tela = new TelaCadastroPlanoCobranca();
            tela.PlanoCobranca = planoSelecionado;
            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }
        }
        public override void Excluir()
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
                repositorioPlanoCobranca.Excluir(planoSelecioando);
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

            return repositorioPlanoCobranca.SelecionarPorId(id);
        }
    }
}
