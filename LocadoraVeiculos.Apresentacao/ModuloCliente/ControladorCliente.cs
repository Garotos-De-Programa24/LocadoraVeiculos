using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {        
        private TelaClienteControl telaClienteControl;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;            
        }

        public override void Inserir()
        {
            TelaCadastroCliente tela = new TelaCadastroCliente();
            tela.Cliente = new Cliente();
            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Editar()
        {
            Cliente clienteSelecionado = null;

            var resultado = ObtemClienteSelecionado();

            if (resultado.IsSuccess)
            {
                clienteSelecionado = resultado.Value;

                TelaCadastroCliente tela = new TelaCadastroCliente();

                tela.Cliente = clienteSelecionado;

                tela.GravarRegistro = servicoCliente.Editar;

                DialogResult result = tela.ShowDialog();

                if (result == DialogResult.OK)
                    CarregarClientes();
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = null;

            var resultadoSelecao = ObtemClienteSelecionado();
            if (resultadoSelecao.IsSuccess)
            {
                clienteSelecionado = resultadoSelecao.Value;

                DialogResult result = MessageBox.Show("Deseja realmente excluir o Agrupamento?",
                "Exclusão de Agrupamentos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    var resultadoExclusao = servicoCliente.Excluir(clienteSelecionado);
                    CarregarClientes();
                    if (resultadoExclusao.IsSuccess)
                    {
                        CarregarClientes();
                    }
                    else
                    {
                        MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Clientes",
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
        //comit
        public override UserControl ObtemListagem()
        {
            if (telaClienteControl == null)
                telaClienteControl = new TelaClienteControl();

            CarregarClientes();

            return telaClienteControl;
        }

        private void CarregarClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();            

            if (resultado.IsSuccess)
            {
                List<Cliente> clientes = resultado.Value;

                telaClienteControl.AtualizarRegistros(clientes);
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Tela de clientes",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        private Result<Cliente> ObtemClienteSelecionado()
        {
            var id = telaClienteControl.ObtemNumeroClienteSelecionado();

            return servicoCliente.SelecionarPorId(id);
        }
    }
}
