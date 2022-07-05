
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
                maskedLimitQuilometragem.Text = Convert.ToString(planoCobranca.LimiteQuilometragem);
                
                PreencherTipoPlano();
            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            planoCobranca.NomePlano = txtNome.Text;
            planoCobranca.GrupoVeiculos = (Agrupamento)cmbAgrupamento.SelectedItem;
            planoCobranca.SetValorDiario(maskedValorDiario.Text);
            planoCobranca.SetValorPorKm(maskedValorPorKm.Text);
            planoCobranca.SetLimiteQuilometragem(maskedLimitQuilometragem.Text);
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
                AtivarTextMask();
            }
            else if (planoCobranca.TipoPlano == EnunPlano.Diario)
            {
                rdbtnPlanoDiario.Checked = true;
                AtivarTextMask();

            }
            else if(planoCobranca.TipoPlano == EnunPlano.Controlado)
            {
                rdbtnPlanoControlado.Checked = true;
                AtivarTextMask();
            }
           
        }
        #region Metodos para habilitar e desablitar os textBox
        private void EnabledtxtLimiteQuilometragem()
        {
            maskedLimitQuilometragem.Enabled = true;
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
            maskedLimitQuilometragem.Enabled = false;
        }

        private void rdbtnPlanos_CheckedChanged(object sender, EventArgs e)
        {
            AtivarTextMask();
        }
        #endregion
        private void AtivarTextMask()
        {
            if(rdbtnPlanoLivre.Checked == true)
            {
                maskedValorPorKm.Clear();
                DesabilitarMaskedValorPorKm();
                maskedLimitQuilometragem.Clear();
                DesabilitartxtLimiteQui();
                EnabledMaskedValorDiario();
            }
            else if(rdbtnPlanoDiario.Checked == true)
            {
                maskedLimitQuilometragem.Clear();
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
    }
}
