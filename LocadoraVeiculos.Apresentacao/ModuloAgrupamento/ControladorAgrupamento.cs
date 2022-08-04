using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloAgrupamento
{
    public class ControladorAgrupamento : ControladorBase
    {        
        private TelaAgrupamentoControl telaAgrupamentoControl;
        private readonly ServicoAgrupamento servicoAgrupamento;

        public ControladorAgrupamento(ServicoAgrupamento servicoAgrupamento)
        {            
            this.servicoAgrupamento = servicoAgrupamento;
        }

        public override void Inserir(Funcionario funcionario)
        {
            
            TelaCadastroAgrupamento tela = new TelaCadastroAgrupamento();
            tela.Agrupamento = new Agrupamento();
            tela.GravarRegistro = servicoAgrupamento.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarAgrupamentos();
        }

        public override void Editar(Funcionario funcionario)
        {
            Agrupamento agrupamentoSelecionado = null;

            var resultado = ObtemAgrupamentoSelecionado();
            if (resultado.IsSuccess)
            {
                agrupamentoSelecionado = resultado.Value;

                TelaCadastroAgrupamento tela = new TelaCadastroAgrupamento();

                tela.Agrupamento = agrupamentoSelecionado;

                tela.GravarRegistro = servicoAgrupamento.Editar;

                DialogResult result = tela.ShowDialog();

                if (result == DialogResult.OK)
                    CarregarAgrupamentos();
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de agrupamentos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Excluir(Funcionario funcionario)
        {
            Agrupamento agrupamentoSelecionado = null;

            var resultadoSelecao = ObtemAgrupamentoSelecionado();
            if (resultadoSelecao.IsSuccess)
            {
                agrupamentoSelecionado = resultadoSelecao.Value;

                DialogResult result = MessageBox.Show("Deseja realmente excluir o Agrupamento?",
                "Exclusão de Agrupamentos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    var resultadoExclusao = servicoAgrupamento.Excluir(agrupamentoSelecionado);
                    if (resultadoExclusao.IsSuccess)
                    {
                        CarregarAgrupamentos();
                    }
                    else
                    {
                        MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Grupo de Veículos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Tela de agrupamentos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var resultado = servicoAgrupamento.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Agrupamento> clientes = resultado.Value;

                telaAgrupamentoControl.AtualizarRegistros(clientes);
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de agrupamentos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Result<Agrupamento> ObtemAgrupamentoSelecionado()
        {
            var id = telaAgrupamentoControl.ObtemNumeroAgrupamentoSelecionado();

            return servicoAgrupamento.SelecionarPorId(id);
        }
    }
}
