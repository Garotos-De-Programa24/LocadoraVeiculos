using FluentResults;
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
        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }

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
            funcionario.Salario = maskedSalario.Text;
            funcionario.DataAdmissao = dateAdmissao.Value;

            funcionario.Gerente = checkBoxAdmin.Checked;

            var resultadoValidacao = GravarRegistro(funcionario);
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                    MessageBox.Show(erro, "Cadastro de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    TelaMenuInicial.Instancia.AtualizarRodape(erro);
                    DialogResult = DialogResult.None;
                }                
            }
        }
    }
}
