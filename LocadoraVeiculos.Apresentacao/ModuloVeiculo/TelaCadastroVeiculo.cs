using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FluentResults;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ModuloAgrupamento;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        private Veiculo veiculo;
        private List<Agrupamento> grupoDeVeiculos;
        public string caminhoFoto = "";


        public TelaCadastroVeiculo(List<Agrupamento> grupoDeVeiculos)
        {
            InitializeComponent();
            this.grupoDeVeiculos = grupoDeVeiculos;

            CarregarAgrupamentos();

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
                if(veiculo.Agrupamento != null) //Para evitar de da erro na hora de intancir o novo veiculo, ele nao tera um agrupamento
                cBoxAgrupamento.Text = veiculo.Agrupamento.Nome;
                if(veiculo.Foto != null)
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
            //Colocar a disponibilidade em true na inserção, pois está disponível
            veiculo.Disponivel = true;
            veiculo.SalvarFoto(Veiculo);

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
                    TelaMenuInicial.Instancia.AtualizarRodape(erro);
                    DialogResult = DialogResult.None;
                }
            }

        }
        private void CarregarAgrupamentos()
        {
            if (grupoDeVeiculos.Count > 0)
            {
                foreach (Agrupamento c in grupoDeVeiculos)
                {
                    cBoxAgrupamento.Items.Add(c);
                }
            }
        }
        public void ExibirImagem()
        {            
            using (var img = new MemoryStream(veiculo.Foto))
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
