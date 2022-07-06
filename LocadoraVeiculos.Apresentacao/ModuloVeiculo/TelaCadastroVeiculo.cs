using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();

            List<Agrupamento> grupos = repositorioAgrupamento.SelecionarTodos();
            foreach (Agrupamento c in grupos)
            {
                cBoxAgrupamento.Items.Add(c);
            }
        }

        private Veiculo veiculo;
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
                cBoxAgrupamento.Text = veiculo.Agrupamento.Nome;
                cBoxCombustivel.Text = veiculo.Combustivel;
                txtCor.Text = veiculo.Cor;
                txtPlaca.Text = veiculo.Placa;
                txtMarca.Text = veiculo.Marca;
                txtAno.Text = veiculo.Ano;
                txtCapacidadeTanque.Text = veiculo.CapacidadeTanque;
                txtKmPercorridos.Text = veiculo.KmPercorridos;
                

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            veiculo.Agrupamento = (Agrupamento)cBoxAgrupamento.SelectedItem;
            veiculo.Combustivel = cBoxCombustivel.Text;
            veiculo.Placa = txtPlaca.Text;
            veiculo.Marca = txtMarca.Text;
            veiculo.Ano = txtAno.Text;
            veiculo.Cor = txtCor.Text;
            veiculo.CapacidadeTanque = txtCapacidadeTanque.Text;
            veiculo.KmPercorridos = txtKmPercorridos.Text;

        }

    }
}
