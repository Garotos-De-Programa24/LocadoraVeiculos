using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                txtNome.Text = cliente.Nome;
                txtCPF.Text = cliente.Cpf;
                txtEndereco.Text = cliente.Endereco;

                //if (cliente.ValidadeCnh == DateTime.MinValue)
                //{
                //    cliente.ValidadeCnh = dateValidade.Value;
                //}                
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
            }
        }        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.Cpf = RemoverEspaços(txtCPF.Text.Split(" "));
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
    }
}
