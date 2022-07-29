using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocação;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloLocacao
{
    public partial class TelaLocacaoControl : UserControl
    {
        public TelaLocacaoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Grupo de Veículo", HeaderText = "Grupo de Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Plano de Cobrança", HeaderText = "Plano de Cobrança"},                
                new DataGridViewTextBoxColumn { DataPropertyName = "Data da Locação", HeaderText = "Data da Locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data da Devolução", HeaderText = "Data da Devolução"},
            };
            return colunas;
        }
        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (var locacao in locacoes)
            {
                grid.Rows.Add(locacao.Id, locacao.Funcionario.Nome, locacao.Cliente.Nome, locacao.Condutor.Nome,
                     locacao.Agrupamento.Nome, locacao.Plano.NomePlano,
                     locacao.DataLocacao.ToString("dd/MM/yyyy"), locacao.DataDevolucao.ToString("dd/MM/yyyy"));
            }
        }

        public Guid ObtemNumeroLocacaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
