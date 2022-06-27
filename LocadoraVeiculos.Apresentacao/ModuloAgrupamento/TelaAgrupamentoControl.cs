using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloAgrupamento
{
    public partial class TelaAgrupamentoControl : UserControl
    {
        public TelaAgrupamentoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Agrupamento", HeaderText = "Agrupamento"},                
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Agrupamento> agrupamentos)
        {
            grid.Rows.Clear();

            foreach (var agrupamento in agrupamentos)
            {
                grid.Rows.Add(agrupamento.Id, agrupamento.Nome);
            }
        }

        public int ObtemNumeroAgrupamentoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
