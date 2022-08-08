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
                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Grupo de Veículo", HeaderText = "Grupo de Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Veículo", HeaderText = "Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Plano de Cobrança", HeaderText = "Plano de Cobrança"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data da Locação", HeaderText = "Data da Locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor de Contrato", HeaderText = "Valor de Contrato"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data da Devolução", HeaderText = "Data da Devolução"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data Real da Entrega", HeaderText = "Data Real da Entrega"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor Final", HeaderText = "Valor Final"},
            };
            return colunas;
        }
        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (var locacao in locacoes)
            {
                if (VerificarStatus(locacao.DataEntrega) == false){
                    grid.Rows.Add(locacao.Id, "Aberto", locacao.Funcionario.Nome, locacao.Cliente.Nome, locacao.Condutor.Nome,
                     locacao.Agrupamento.Nome, locacao.Veiculo.VeiculoNome, locacao.Plano.NomePlano,
                     locacao.DataLocacao.ToString("dd/MM/yyyy"), locacao.ValorInicio, locacao.DataDevolucao.ToString("dd/MM/yyyy"), 
                     "EM ABERTO","ABERTO");
                }
                else
                {
                    grid.Rows.Add(locacao.Id, "Fechado", locacao.Funcionario.Nome, locacao.Cliente.Nome, locacao.Condutor.Nome,
                     locacao.Agrupamento.Nome, locacao.Veiculo.VeiculoNome, locacao.Plano.NomePlano,
                     locacao.DataLocacao.ToString("dd/MM/yyyy"), locacao.ValorInicio, locacao.DataDevolucao.ToString("dd/MM/yyyy"),
                     locacao.DataEntrega?.ToString("dd/MM/yyyy"), locacao.ValorFinal);
                }
                
            }
        }
  
        public bool VerificarStatus(DateTime? dataEntrega)
        {
            bool resultado = true;
            if (dataEntrega == null)
            {
                resultado = false;
            }
            return resultado;
        }
        public Guid ObtemNumeroLocacaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
