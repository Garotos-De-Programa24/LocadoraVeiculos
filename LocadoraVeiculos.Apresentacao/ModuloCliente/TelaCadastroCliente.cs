using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCliente
{
    public partial class TelaCadastroCliente : Form
    {
        public TelaCadastroCliente()
        {
            InitializeComponent();
        }
        private Cliente cliente;
        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                
                string str = "" + cliente.CpfCnpj;
                if (str.Length > 14)
                {
                    checkBoxCNPJ.Checked = true;
                }
                string[] charsToRemove = new string[] { ",", ".", "-" };
                foreach (var c in charsToRemove)
                {
                    str = str.Replace(c, string.Empty);
                }

               
                txtNome.Text = cliente.Nome;
                txtMaskCPFCNPJ.Text = str;
                txtEndereco.Text = cliente.Endereco;
                

                               
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
            }
        }        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.CpfCnpj = RemoverEspaços(txtMaskCPFCNPJ.Text.Split(" "));
            cliente.Endereco = txtEndereco.Text;            
            cliente.Email = txtEmail.Text;
            cliente.Telefone = RemoverEspaços(txtTelefone.Text.Split(" "));

            var resultadoValidacao = GravarRegistro(cliente);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro,"Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
 

        private void checkBoxCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            txtMaskCPFCNPJ.Clear();
            if (checkBoxCNPJ.Checked == true)
            {
                txtMaskCPFCNPJ.Mask = "00.000.000/0000-00";
            }
            else
            {
                txtMaskCPFCNPJ.Mask = "000.000.000-00";
            }
        }
    }
}
