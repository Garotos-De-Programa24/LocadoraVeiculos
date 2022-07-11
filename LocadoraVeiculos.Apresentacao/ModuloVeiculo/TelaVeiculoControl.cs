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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Validade da CNH", HeaderText = "Validade da CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-Mail"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},
          };

            return colunas;
        }
        public void AtualizarRegistros(List<Veiculo> condutores)
        {
            grid.Rows.Clear();

            foreach (var condutor in condutores)
            {
                grid.Rows.Add(condutor.Id, condutor.Cliente.Nome,
                    condutor.Nome, condutor.Cpf, condutor.CnhCondutor,
                    condutor.ValidadeCnh.ToShortDateString(), condutor.Endereco,
                     condutor.Email, condutor.Telefone);
            }
        }

        public int ObtemNumeroCondutorSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
