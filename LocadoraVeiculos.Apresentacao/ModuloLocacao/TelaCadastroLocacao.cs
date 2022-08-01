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
        private ServicoCondutor servicoCondutor;

        private List<PlanoCobranca> planos;
        private List<Veiculo> veiculos;
        private List<Condutor> condutores;
        private int qtdTaxas;

        public TelaCadastroLocacao(List<Agrupamento> _agrupamentos, List<Cliente> _clientes, List<Taxa> _taxas,
                                    List<PlanoCobranca> _planos, List<Veiculo> _veiculos, List<Condutor> _condutores)
        {
            InitializeComponent();

            //configurar combo box iniciais
            

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
            if(cboxPlano.SelectedItem != null)
            {
               
                lDadosLocacao.Text = cboxPlano.SelectedItem.ToString();
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
            int n = 0;
            listEquipamentos.Items.Add(cboxTaxa.SelectedItem);
            if(Locacao.Taxas.Count == 0)
                Locacao.Taxas.Add((Taxa)cboxTaxa.SelectedItem);
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
            lDadosTaxa.Text = "";
           
            foreach (var item in Locacao.Taxas)
            {
                lDadosTaxa.Text +=item.QuantidadePorLocacao + " " + item.ToString();
            }
            
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

        private void cboxCondutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarResumo();
        }

        private void cboxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarResumo();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            locacao.Cliente = (Cliente)cboxCliente.SelectedItem;
            locacao.Condutor = (Condutor)cboxCondutor.SelectedItem;
            locacao.Agrupamento = (Agrupamento)cboxAgrupamento.SelectedItem;
            
            locacao.Veiculo = (Veiculo)cboxVeiculo.SelectedItem;
            locacao.Veiculo.Disponivel = false;

            locacao.DataLocacao = dataLocacao.Value;

            locacao.DataDevolucao = dataTempoLocacao.Value;

            

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Cadastro de condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}