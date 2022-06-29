using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloTaxa
{
    public partial class TelaCadastroTaxa : Form
    {
        public TelaCadastroTaxa()
        {
            InitializeComponent();
        }
        private Taxa taxa;
        public Func<Taxa, ValidationResult> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get
            {
                return taxa;
            }
            set
            {
                taxa = value;
                txtEquipamento.Text = Taxa.Equipamento;
                txtValor.Text = Taxa.Valor;
                txtDescricao.Text = Taxa.Descricao;

                

               
            }
        }



        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            taxa.Equipamento = txtEquipamento.Text;
            taxa.Valor = txtValor.Text;
            taxa.Descricao = txtDescricao.Text;

            taxa.TaxaDiaria = checkBoxDiario.Checked;

            var resultadoValidacao = GravarRegistro(Taxa);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                MessageBox.Show(erro, "Cadastro de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;
            }
        }
    }
}
