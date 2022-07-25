using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloAgrupamento
{
    public partial class TelaCadastroAgrupamento : Form
    {
        public TelaCadastroAgrupamento()
        {
            InitializeComponent();
        }
        private Agrupamento agrupamento;
        public Func<Agrupamento, Result<Agrupamento>> GravarRegistro { get; set; }

        public Agrupamento Agrupamento
        {
            get
            {
                return agrupamento;
            }
            set
            {
                agrupamento = value;
                txtNome.Text = agrupamento.Nome;
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            agrupamento.Nome = txtNome.Text;

            var resultadoValidacao = GravarRegistro(agrupamento);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Cadastro de Grupo de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    TelaMenuInicial.Instancia.AtualizarRodape(erro);
                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
