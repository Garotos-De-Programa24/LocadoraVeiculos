using FluentResults;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloLocação;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.Modulolocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        
        private List<PlanoCobranca> planos;
        private List<Veiculo> veiculos;
        private List<Funcionario> funcionarios;
        private List<Condutor> condutores;
        private Funcionario funcionario;
        private int diasDeLocacao;
        private decimal valorTaxaAcumulada;
        private decimal valorPlano;
        private decimal valorFinal;

        public TelaCadastroLocacao(List<Agrupamento> _agrupamentos, List<Cliente> _clientes, List<Taxa> _taxas,
                                    List<PlanoCobranca> _planos, List<Veiculo> _veiculos, List<Condutor> _condutores, List<Funcionario> _funcionarios,Funcionario funcionario)
        {
            InitializeComponent();

            //configurar combo box iniciais
            this.funcionario = funcionario;
            

            List<Cliente> clientes = _clientes;
            foreach (Cliente c in clientes)
                cboxCliente.Items.Add(c);

            List<Agrupamento> agrupamentos = _agrupamentos;
            foreach (Agrupamento a in agrupamentos)
                cboxAgrupamento.Items.Add(a);

            List<Taxa> taxas = _taxas;
            foreach (Taxa t in taxas)
                cboxTaxa.Items.Add(t);

            planos = _planos;
            veiculos = _veiculos;
            condutores = _condutores;
            this.funcionarios = _funcionarios;
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao locacao { get; set; }

        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;
                txtFuncionario.Text = funcionario.Nome;
                cboxCliente.SelectedItem = locacao.Cliente;
                cboxCondutor.SelectedItem = locacao.Condutor;
                cboxAgrupamento.SelectedItem = locacao.Agrupamento;
                cboxVeiculo.SelectedItem = locacao.Veiculo;
                cboxPlano.SelectedItem = locacao.Plano;
                listEquipamentos.SelectedItem = locacao.Taxas;

            }
        }

        private void cboxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cboxCliente.SelectedItem;
            AtualizarResumo();
            cboxCondutor.Items.Clear();

            foreach (Condutor condutor in condutores)
            {
                if (condutor.Cliente.Id == cliente.Id)
                    cboxCondutor.Items.Add(condutor);
            }

        }

        private void AtualizarResumo()
        {
            if (cboxCliente.SelectedItem != null)
            {
                lDadosCliente.Text = cboxCliente.SelectedItem.ToString();
            }
            if (cboxCondutor.SelectedItem != null)
            {
                lDadosCliente.Text += cboxCondutor.SelectedItem.ToString();

            }
            if (cboxVeiculo.SelectedItem != null)
            {
                lDadosVeiculo.Text = cboxAgrupamento.SelectedItem.ToString();
                lDadosVeiculo.Text = cboxVeiculo.SelectedItem.ToString();
                Veiculo veiculo = new Veiculo();
                veiculo = (Veiculo)cboxVeiculo.SelectedItem;
                using (var img = new MemoryStream(veiculo.Foto))
                {
                    pictureCarro.Image = Image.FromStream(img);
                }

            }
            if (diasDeLocacao != 0 && Locacao.Taxas.Count != 0)
            {

                AtualizandoResumoTaxas();
                valorTaxaAcumulada = 0;

                foreach (var taxa in Locacao.Taxas)
                {
                    if (taxa.TaxaDiaria == true)
                    {
                        valorTaxaAcumulada += (taxa.QuantidadePorLocacao * Convert.ToInt32(taxa.Valor)) * diasDeLocacao;
                        continue;
                    }
                    valorTaxaAcumulada += taxa.QuantidadePorLocacao * Convert.ToInt32(taxa.Valor);
                }
                

                lDadosTaxa.Text += "Valor Total das Taxas: R$" + valorTaxaAcumulada;
            }
            if (cboxPlano.SelectedItem != null)
            {
                var plano = (PlanoCobranca)cboxPlano.SelectedItem;
                valorPlano = plano.ValorDiario;
                lDadosLocacao.Text = cboxPlano.SelectedItem.ToString();
                Locacao.DataLocacao = dataLocacaoBox.Value;
                Locacao.DataDevolucao = dataTempoLocacaoBox.Value;

                if (Locacao.DataDevolucao.DayOfYear - Locacao.DataLocacao.DayOfYear >= 1)
                {
                    lDadosLocacao.Text += "Data Locação: " + Locacao.DataLocacao.ToShortDateString() + "\nData Devolução: " + Locacao.DataDevolucao.ToShortDateString();
                    diasDeLocacao = Locacao.DataDevolucao.DayOfYear - Locacao.DataLocacao.DayOfYear;
                    lDadosLocacao.Text += "\nDias de Locação: " + diasDeLocacao;
                }
            }
            if(valorPlano != 0 && diasDeLocacao != 0)
            {
                AtualizandoResumoTaxas();
                valorFinal = valorTaxaAcumulada + (valorPlano * diasDeLocacao);
                lValor.Text = Convert.ToString(valorFinal);
            }
           
        }

        private void cboxAgrupamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Agrupamento agrupamento = (Agrupamento)cboxAgrupamento.SelectedItem;

            cboxVeiculo.Items.Clear();

            foreach (Veiculo veiculo in veiculos)
            {
                if (veiculo.Agrupamento.Id == agrupamento.Id && veiculo.Disponivel == true)
                    cboxVeiculo.Items.Add(veiculo);
            }

            cboxPlano.Items.Clear();

            foreach (PlanoCobranca plano in planos)
            {
                if (plano.GrupoVeiculos.Id == agrupamento.Id)
                    cboxPlano.Items.Add(plano);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            listEquipamentos.Items.Add(cboxTaxa.SelectedItem);
            if (Locacao.Taxas.Count == 0)
                Locacao.Taxas.Add((Taxa)cboxTaxa.SelectedItem);
            int n = 0;
            foreach (var taxa in Locacao.Taxas)
            {
                if (taxa != cboxTaxa.SelectedItem)
                    n++;


                if (taxa == cboxTaxa.SelectedItem)
                {
                    taxa.QuantidadePorLocacao++;
                    break;
                }
            }
            if (n == Locacao.Taxas.Count)
            {

                Locacao.Taxas.Add((Taxa)cboxTaxa.SelectedItem);
                foreach (var taxa in Locacao.Taxas)
                {

                    if (taxa == cboxTaxa.SelectedItem)
                    {
                        taxa.QuantidadePorLocacao++;
                        break;
                    }
                }

            }

            AtualizandoResumoTaxas();
        }

        private void AtualizandoResumoTaxas()
        {

            lDadosTaxa.Text = "";
            valorTaxaAcumulada = 0;
            foreach (var item in Locacao.Taxas)
            {
                lDadosTaxa.Text += item.QuantidadePorLocacao + " " + item.ToString();

                if (item.TaxaDiaria)
                {
                    valorTaxaAcumulada += item.QuantidadePorLocacao * (Convert.ToDecimal(item.Valor) * diasDeLocacao);
                }
                else
                {
                    valorTaxaAcumulada += Convert.ToDecimal(item.Valor) * item.QuantidadePorLocacao;
                }; 
            }
            lDadosTaxa.Text += "Valor Total Acumulado: R$" + valorTaxaAcumulada;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            foreach (var taxa in Locacao.Taxas)
            {

                if (taxa == listEquipamentos.SelectedItem)
                {
                    taxa.QuantidadePorLocacao--;
                    if (taxa.QuantidadePorLocacao == 0)
                    {
                        Locacao.Taxas.Remove((Taxa)listEquipamentos.SelectedItem);
                        break;
                    }
                    break;
                }
            }
            listEquipamentos.Items.Remove(listEquipamentos.SelectedItem);
            lDadosTaxa.Text = "";
            if (Locacao.Taxas.Count == 0)
                lDadosTaxa.Text = "[Taxas não Selecionadas]";
            foreach (var item in Locacao.Taxas)
            {
                lDadosTaxa.Text += item.QuantidadePorLocacao + " " + item.ToString();
            }
        }

        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            locacao.Cliente = (Cliente)cboxCliente.SelectedItem;
            locacao.Condutor = (Condutor)cboxCondutor.SelectedItem;
            locacao.Agrupamento = (Agrupamento)cboxAgrupamento.SelectedItem;
            locacao.Plano = (PlanoCobranca)cboxPlano.SelectedItem;
            locacao.Veiculo = (Veiculo)cboxVeiculo.SelectedItem;
            locacao.Veiculo.Disponivel = false;
            locacao.ValorInicio = valorFinal;
            locacao.DataLocacao = dataLocacaoBox.Value;

            locacao.DataDevolucao = dataTempoLocacaoBox.Value;

            locacao.Funcionario = funcionarios.Find(x => x.Nome == txtFuncionario.Text);
            

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Cadastro de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    TelaMenuInicial.Instancia.AtualizarRodape(erro);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void cboxPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarResumo();
        }

        private void dataTempoLocacao_ValueChanged(object sender, EventArgs e)
        {
            AtualizarResumo();
        }
        private void cboxCondutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarResumo();
        }

        private void cboxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarResumo();
        }
    }
}