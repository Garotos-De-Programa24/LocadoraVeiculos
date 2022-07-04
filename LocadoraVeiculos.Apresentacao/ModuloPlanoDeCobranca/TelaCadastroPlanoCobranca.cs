
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobrança
{
    public partial class TelaCadastroPlanoCobranca : Form
    {
        private PlanoCobranca planoCobranca;
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;

        public TelaCadastroPlanoCobranca()
        {
            InitializeComponent();
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();
            List<Agrupamento> grupo = repositorioAgrupamento.SelecionarTodos();
            foreach (Agrupamento g in grupo)
            {
                cmbAgrupamento.Items.Add(g);
            }
        }
        public Func<PlanoCobranca, ValidationResult> GravarRegistro { get; set; }

        public PlanoCobranca PlanoCobranca
        {
            get
            {
                return planoCobranca;
            }
            set
            {
                planoCobranca = value;
                txtNome.Text = planoCobranca.NomePlano;
                cmbAgrupamento.Text = planoCobranca.GrupoVeiculos.Nome;
                if(planoCobranca.ValorPorKm != 0)
                maskedValorDiario.Text = Convert.ToString(planoCobranca.ValorPorKm);
                if(planoCobranca.ValorDiario != 0)
                maskedValorPorKm.Text = Convert.ToString(planoCobranca.ValorDiario);
                if(planoCobranca.LimiteQuilometragem != 0)
                txtLimitQuilometragem.Text = Convert.ToString(planoCobranca.LimiteQuilometragem);
                PreencherTipoPlano();
            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            planoCobranca.NomePlano = txtNome.Text;
            planoCobranca.GrupoVeiculos = (Agrupamento)cmbAgrupamento.SelectedItem;
            planoCobranca.ValorDiario = Convert.ToDecimal(RemoverEspaços(maskedValorDiario.Text.Split(" ")));
            planoCobranca.ValorPorKm = Convert.ToDecimal(RemoverEspaços(maskedValorPorKm.Text.Split(" ")));
            planoCobranca.LimiteQuilometragem = Convert.ToDecimal(RemoverEspaços(txtLimitQuilometragem.Text.Split(" ")));
            planoCobranca.TipoPlano = ObterTipoPlano();

            var resultadoValidacao = GravarRegistro(planoCobranca);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Cadastro de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }

        private EnunPlano ObterTipoPlano()
        {
            EnunPlano tipoPlano = EnunPlano.Livre;

            if(rdbtnPlanoLivre.Checked)
            {
                tipoPlano = EnunPlano.Livre;
            }
            else if (rdbtnPlanoDiario.Checked)
            {
                tipoPlano = EnunPlano.Diario;
            }
            else if (rdbtnPlanoControlado.Checked)
            {
                tipoPlano = EnunPlano.Controlado;
            }
            return tipoPlano;

        }

        private void PreencherTipoPlano()
        {
            if(planoCobranca.TipoPlano == EnunPlano.Livre)
            {
                rdbtnPlanoLivre.Checked = true;
                DesabilitarMaskedValorPorKm();
                DesabilitartxtLimiteQui();
                EnabledMaskedValorDiario();
            }
            else if (planoCobranca.TipoPlano == EnunPlano.Diario)
            {
                rdbtnPlanoDiario.Checked = true;
                DesabilitartxtLimiteQui();
                EnabledMaskedValorDiario();
                EnabledMaskedValorPorKm();

            }
            else if(planoCobranca.TipoPlano == EnunPlano.Controlado)
            {
                rdbtnPlanoControlado.Checked = true;
                EnabledMaskedValorDiario();
                EnabledMaskedValorPorKm();
                EnabledtxtLimiteQuilometragem();
            }
           
        }

        private void EnabledtxtLimiteQuilometragem()
        {
            txtLimitQuilometragem.Enabled = true;
        }

        private void EnabledMaskedValorPorKm()
        {
            maskedValorPorKm.Enabled = true;
        }
        private void EnabledMaskedValorDiario()
        {
            maskedValorDiario.Enabled = true;
        }
        private void DesabilitarMaskedValorPorKm()
        {
            maskedValorPorKm.Enabled = false;
        }
        private void DesabilitartxtLimiteQui()
        {
            txtLimitQuilometragem.Enabled = false;
        }

        private void rdbtnPlanos_CheckedChanged(object sender, EventArgs e)
        {
            AtivarTextMask();
        }

        private void AtivarTextMask()
        {
            if(rdbtnPlanoLivre.Checked == true)
            {
                DesabilitarMaskedValorPorKm();
                DesabilitartxtLimiteQui();
                EnabledMaskedValorDiario();
            }
            else if(rdbtnPlanoDiario.Checked == true)
            {
                DesabilitartxtLimiteQui();
                EnabledMaskedValorDiario();
                EnabledMaskedValorPorKm();
            }
            else if(rdbtnPlanoControlado.Checked == true)
            {
                EnabledMaskedValorDiario();
                EnabledMaskedValorPorKm();
                EnabledtxtLimiteQuilometragem();
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
