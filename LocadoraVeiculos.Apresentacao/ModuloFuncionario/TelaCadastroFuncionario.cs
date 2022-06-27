using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;

using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloFuncionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        private Funcionario funcionario;
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }
        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get
            {
                return funcionario;
            }
            set
            {
                funcionario = value;
                txtNome.Text = funcionario.Nome;
                //txtSalario.Text = Convert.ToString(funcionario.Salario);
                txtLogin.Text = funcionario.Login;
                txtSenha.Text = funcionario.Senha;
                maskedSalario.Text = funcionario.Salario;

                if (funcionario.DataAdmissao == DateTime.MinValue)
                {
                    funcionario.DataAdmissao = dateAdmissao.Value;
                }

                dateAdmissao.Value = funcionario.DataAdmissao;
                

            }
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            funcionario.Nome = txtNome.Text;
            funcionario.Login = txtLogin.Text;
            funcionario.Senha = txtSenha.Text;
            //funcionario.Salario = Convert.ToDecimal(txtSalario.Text);
            funcionario.Salario = maskedSalario.Text;
            funcionario.DataAdmissao = dateAdmissao.Value;

            funcionario.Gerente = checkBoxAdmin.Checked;

            var resultadoValidacao = GravarRegistro(funcionario);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                DialogResult = DialogResult.None;
            }
        }
    }
}
