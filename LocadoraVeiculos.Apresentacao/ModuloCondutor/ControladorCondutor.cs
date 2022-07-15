using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        
        private TelaCondutorControl telaCondutorControl;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor)
        {
            this.servicoCondutor = servicoCondutor;            
        }

        public override void Inserir()
        {
            TelaCadastroCondutor tela = new TelaCadastroCondutor();
            tela.Condutor = new Condutor();
            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Editar()
        {
            Condutor condutorSelecionado = null;

            var resultado = ObtemCondutorSelecionado();
            if (resultado.IsSuccess)
            {
                condutorSelecionado = resultado.Value;

                TelaCadastroCondutor tela = new TelaCadastroCondutor();

                tela.Condutor = condutorSelecionado;

                tela.GravarRegistro = servicoCondutor.Editar;

                DialogResult result = tela.ShowDialog();

                if (result == DialogResult.OK)
                    CarregarCondutores();
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de condutores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void Excluir()
        {
            Condutor condutorSelecionado = null;

            var resultadoSelecao = ObtemCondutorSelecionado();
            if (resultadoSelecao.IsSuccess)
            {
                condutorSelecionado = resultadoSelecao.Value;

                DialogResult result = MessageBox.Show("Deseja realmente excluir o Condutor?",
                "Exclusão de condutores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    var resultadoExclusao = servicoCondutor.Excluir(condutorSelecionado);
                    if (resultadoExclusao.IsSuccess)
                    {
                        CarregarCondutores();
                    }
                    else
                    {
                        MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Condutores",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Tela de condutores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //comit
        public override UserControl ObtemListagem()
        {
            if (telaCondutorControl == null)
                telaCondutorControl = new TelaCondutorControl();

            CarregarCondutores();

            return telaCondutorControl;
        }

        private void CarregarCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> clientes = resultado.Value;

                telaCondutorControl.AtualizarRegistros(clientes);
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de condutores",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Result<Condutor> ObtemCondutorSelecionado()
        {
            var id = telaCondutorControl.ObtemNumeroCondutorSelecionado();

            return servicoCondutor.SelecionarPorId(id);
        }
    }
}
