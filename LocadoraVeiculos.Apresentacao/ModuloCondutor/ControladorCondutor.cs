using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        
        private TelaCondutorControl telaCondutorControl;
        private readonly ServicoCondutor servicoCondutor;
        private ServicoCliente servicoCliente;


        public ControladorCondutor(ServicoCondutor servicoCondutor,ServicoCliente servicoCliente)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir(Funcionario funcionario)
        {

            TelaCadastroCondutor tela = new TelaCadastroCondutor(ObterClientes());
            tela.Condutor = new Condutor();
            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Editar(Funcionario funcionario)
        {
            Condutor condutorSelecionado = null;

            var resultado = ObtemCondutorSelecionado();
            if (resultado.IsSuccess)
            {
                condutorSelecionado = resultado.Value;

                TelaCadastroCondutor tela = new TelaCadastroCondutor(ObterClientes());

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

        public override void Excluir(Funcionario funcionario)
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
        private List<Cliente> ObterClientes()
        {
            var resultadoDoresult = servicoCliente.SelecionarTodos();
            List<Cliente> clientes = new List<Cliente>();

            if (resultadoDoresult.IsSuccess)
                clientes = resultadoDoresult.Value;

            return clientes;
        }

        private Result<Condutor> ObtemCondutorSelecionado()
        {
            var id = telaCondutorControl.ObtemNumeroCondutorSelecionado();

            return servicoCondutor.SelecionarPorId(id);
        }
    }
}
