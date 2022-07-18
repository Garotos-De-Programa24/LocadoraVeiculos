using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FluentResults;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ModuloAgrupamento;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;
        private Veiculo veiculo;


        public TelaCadastroVeiculo()
        {
            InitializeComponent();
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();

            List<Agrupamento> grupos = repositorioAgrupamento.SelecionarTodos();
            foreach (Agrupamento c in grupos)
            {
                cBoxAgrupamento.Items.Add(c);
            }

            cBoxCombustivel.Items.Add("Gasolina");
            cBoxCombustivel.Items.Add("Alcool");
            cBoxCombustivel.Items.Add("Diesel");
            cBoxCombustivel.Items.Add("Alcool/Gasolina");
            cBoxCombustivel.Items.Add("GNV - Gás");
        }

        
        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;
                txtVeiculo.Text = veiculo.VeiculoNome;
                txtAno.Text = veiculo.Ano;
                txtMarca.Text = veiculo.Marca;
                txtPlaca.Text = veiculo.Placa;
                txtCapacidadeTanque.Text = veiculo.CapacidadeTanque;
                txtKmPercorridos.Text = veiculo.KmPercorridos;
                cBoxCombustivel.Text = veiculo.Combustivel;
                txtCor.Text = veiculo.Cor;
                cBoxAgrupamento.Text = veiculo.Agrupamento.Nome;
                
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            veiculo.VeiculoNome = txtVeiculo.Text;
            veiculo.Ano = txtAno.Text;
            veiculo.Marca = txtMarca.Text;
            veiculo.Placa = txtPlaca.Text;
            veiculo.CapacidadeTanque = txtCapacidadeTanque.Text;
            veiculo.KmPercorridos = txtKmPercorridos.Text;
            veiculo.Combustivel = cBoxCombustivel.Text;
            veiculo.Cor = txtCor.Text;
            veiculo.Agrupamento = (Agrupamento)cBoxAgrupamento.SelectedItem;

            var resultadoValidacao = GravarRegistro(veiculo);
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Cadastro de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }

        }

    }
}
