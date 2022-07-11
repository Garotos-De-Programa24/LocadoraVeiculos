using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FluentValidation.Results;
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

            cBoxCor.Items.Add("Azul");
            cBoxCor.Items.Add("Vermelho");
            cBoxCor.Items.Add("Amarelo");
            cBoxCor.Items.Add("Branco");
            cBoxCor.Items.Add("Verde");
            cBoxCor.Items.Add("Cinza");
            cBoxCor.Items.Add("Prata");
            cBoxCor.Items.Add("Preto");
            cBoxCor.Items.Add("Roxo");
        }

        
        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

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
                cBoxCor.Text = veiculo.Cor;
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
            veiculo.Cor = cBoxCor.Text;
            veiculo.Agrupamento = (Agrupamento)cBoxAgrupamento.SelectedItem;

            var resultadoValidacao = GravarRegistro(veiculo);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Cadastro de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }

        }

    }
}
