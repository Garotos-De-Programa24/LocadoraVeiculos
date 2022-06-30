using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCondutor
{
    public partial class TelaCadastroCondutor : Form
    {
        public TelaCadastroCondutor()
        {
            InitializeComponent();
        }
        
        private Condutor condutor;
        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

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

                if (condutor.ValidadeCnh == DateTime.MinValue)
                {
                    condutor.ValidadeCnh = dateValidade.Value;
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

            if (condutor.ValidadeCnh == DateTime.MinValue)
            {
                condutor.ValidadeCnh = dateValidade.Value;
            } 

            condutor.Email = txtEmail.Text;
            condutor.Telefone = RemoverEspaços(txtTelefone.Text.Split(" "));

            var resultadoValidacao = GravarRegistro(condutor);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Cadastro de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
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
