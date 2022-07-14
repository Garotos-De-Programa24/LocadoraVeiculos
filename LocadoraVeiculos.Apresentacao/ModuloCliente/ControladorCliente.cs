using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly IRepositorioCliente repositorioCliente;
        private TelaClienteControl telaClienteControl;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
            this.repositorioCliente = repositorioCliente;
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
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione uma Cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCliente tela = new TelaCadastroCliente();

            tela.Cliente = clienteSelecionado;

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();

        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCliente.Excluir(clienteSelecionado);
                CarregarClientes();
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
            List<Cliente> clientes = servicoCliente.SelecionarTodos();
            if(clientes != null)
            telaClienteControl.AtualizarRegistros(clientes);
        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = telaClienteControl.ObtemNumeroClienteSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }
    }
}
