
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo.ModuloAgrupamento
{
    public partial class TelaCadastroAgrupamentoCarros : Form
    {
        private Agrupamento agrupamento;
        public TelaCadastroAgrupamentoCarros()
        {
            InitializeComponent();
        }
        public Func<Agrupamento, ValidationResult> GravarRegistro { get; set; }
        public Agrupamento Agrupamento
        {
            get
            {
                return agrupamento;
            }
            set
            {
                agrupamento = value;
                txtNomeGrupoVeiculo.Text = agrupamento.NomeAgrupamento;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            agrupamento.NomeAgrupamento = txtNomeGrupoVeiculo.Text;
            var resultadoValidacao = GravarRegistro(agrupamento);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                DialogResult = DialogResult.None;
            }
        }
    }
}
