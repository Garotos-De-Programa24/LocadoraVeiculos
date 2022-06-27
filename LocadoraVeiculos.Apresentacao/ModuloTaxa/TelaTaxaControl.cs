using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloTaxa
{
    public partial class TelaTaxaControl : UserControl
    {
        public TelaTaxaControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Equipamento", HeaderText = "Equipamento"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descricao"},
            
            };
            return colunas;
        }

        public void AtualizarRegistros(List<Taxa> taxa)
        {
            grid.Rows.Clear();

            foreach (var t in taxa)
            {
                grid.Rows.Add(t.Equipamento, t.Valor, t.Descricao);

            }
        }

        public int ObtemNumeroTaxaSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
