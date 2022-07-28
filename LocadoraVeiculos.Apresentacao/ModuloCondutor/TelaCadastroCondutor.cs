using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCondutor
{
    public partial class TelaCadastroCondutor : Form
    {
        //acho que da pra conseguir usar o serviçopra selecionar os Clientes
        private List<Cliente> clientes;

        public TelaCadastroCondutor(List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
            //servicoCliente = new RepositorioClienteEmBancoDados();
            CarregarClientes();
            //List<Cliente> clientes = servicoCliente.SelecionarTodos();
            
        }
        
        private Condutor condutor;
        
        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;
                comboCliente.Text = condutor.Cliente.Nome;
                txtNome.Text = condutor.Nome;
                txtCPF.Text = condutor.Cpf;
                txtEndereco.Text = condutor.Endereco;
                MaskedCNHCondutor.Text = condutor.CnhCondutor;
                if (condutor.ValidadeCnh != DateTime.MinValue)
                {
                    dataValidade.Value = condutor.ValidadeCnh;
                }                
                txtEmail.Text = condutor.Email;
                txtTelefone.Text = condutor.Telefone;
            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            condutor.Cliente = (Cliente)comboCliente.SelectedItem;
            condutor.Nome = txtNome.Text;
            condutor.Cpf = RemoverEspaços(txtCPF.Text.Split(" "));
            condutor.Endereco = txtEndereco.Text;
            condutor.CnhCondutor = MaskedCNHCondutor.Text;
            condutor.ValidadeCnh = dataValidade.Value;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = RemoverEspaços(txtTelefone.Text.Split(" "));

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Cadastro de condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    TelaMenuInicial.Instancia.AtualizarRodape(erro);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private string RemoverEspaços(string[] valid)
        {
            string resultado = "";

            for (int i = 0; i < valid.Length; i++)
            {
                if (valid[i] != "")
                {
                    resultado = valid[i];
                }
            }
            return resultado;
        }

        private void CarregarClientes()
        {
            if (clientes.Count > 0)
            {
                foreach (Cliente c in clientes)
                {
                    comboCliente.Items.Add(c);
                }
            }
        }
        private void checkClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)comboCliente.SelectedItem;

            txtNome.Text = cliente.Nome;
            if(cliente.CpfCnpj.Length == 14)
            txtCPF.Text = cliente.CpfCnpj;
            txtEndereco.Text = cliente.Endereco;
            txtTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;
        }
    }
}
