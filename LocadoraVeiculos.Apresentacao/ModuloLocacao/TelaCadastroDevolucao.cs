using FluentResults;
using LocadoraVeiculos.Dominio.ModuloLocação;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloDevolucao
{
    public partial class TelaCadastroDevolucao : Form
    {
        public TelaCadastroDevolucao(Locacao locacao)
        {
            this.locacao = locacao;
            InitializeComponent();
        }
        private Veiculo imagemVeiculo;
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
                lDadosCliente.Text = locacao.Cliente.ToString();
                lDadosCliente.Text += locacao.Condutor.ToString();
                lDadosVeiculo.Text = locacao.Veiculo.ToString();
                lDadosLocacao.Text = locacao.Plano.ToString();
                lOservacoes.Text = "Data de entrega: " + DateTime.Today.AddDays(10);
                lValorContrato.Text = "R$"+locacao.ValorFinal;
                
                imagemVeiculo = locacao.Veiculo;
                using (var img = new MemoryStream(imagemVeiculo.Foto))
                {
                    pictureCarro.Image = Image.FromStream(img);
                }

            }
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            locacao.DataEntrega = DateTime.Today.AddDays(10);
            locacao.ValorFinal = locacao.ValorInicio + 1000;
            

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
    }
}
