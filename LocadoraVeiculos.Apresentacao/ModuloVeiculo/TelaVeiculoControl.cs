using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo
{
    public partial class TelaVeiculoControl : UserControl
    {
        public TelaVeiculoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
          {
                new DataGridViewTextBoxColumn { DataPropertyName = "VeiculoNome", HeaderText = "veiculoNome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "marca"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "ano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "placa"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Capacidadetanque", HeaderText = "capacidadetanque"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmPercorrido", HeaderText = "KmPercorrido"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Combustivel", HeaderText = "combustivel"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "cor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Agrupamento", HeaderText = "agrupamentoVeiculo"},
          };

            return colunas;
        }
        public void AtualizarRegistros(List<Veiculo> condutores)
        {
            grid.Rows.Clear();

            foreach (var condutor in condutores)
            {
                grid.Rows.Add(condutor.VeiculoNome, condutor.Agrupamento,
                    condutor.Marca, condutor.Ano, condutor.Placa,
                    condutor.CapacidadeTanque, condutor.KmPercorridos,
                     condutor.Combustivel, condutor.Cor);
            }
        }

        public int ObtemNumeroCondutorSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
