using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public string caminhoFoto = "";


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
                txtCor.Text = veiculo.Cor;
                cBoxAgrupamento.Text = veiculo.Agrupamento.Nome;
                ExibirImagem();


                
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
            veiculo.SalvarFoto(Veiculo);

            var resultadoValidacao = GravarRegistro(veiculo);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Cadastro de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }

        }

        public void ExibirImagem()
        {
            using (var img = new MemoryStream(Veiculo.Foto))
            {
                pictureCarro.Image = Image.FromStream(img);
            }
        }

        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens JPG e PNG| *.jpg; *.png";
            openFile.Multiselect = false;
            

            if (openFile.ShowDialog() == DialogResult.OK)
                Veiculo.CaminhoDaFotoNaMaquina = openFile.FileName;

            if (Veiculo.CaminhoDaFotoNaMaquina != "")
                pictureCarro.Load(Veiculo.CaminhoDaFotoNaMaquina);
            
        }
    }
}
