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
                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Capacidade do Tanque", HeaderText = "Capacidade do Tanque"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Km Percorrido", HeaderText = "Km Percorrido"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Combustivel", HeaderText = "Combustível"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Agrupamento", HeaderText = "Agrupamento"},
            };

            return colunas;
        }
        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (var veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.VeiculoNome,veiculo.Marca, veiculo.Ano, veiculo.Placa,
                    veiculo.CapacidadeTanque, veiculo.KmPercorridos,
                     veiculo.Combustivel, veiculo.Cor, veiculo.Agrupamento.Nome);
            }
        }

        public Guid ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
