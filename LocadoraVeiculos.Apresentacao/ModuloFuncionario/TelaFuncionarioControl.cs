using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloFuncionario
{
    public partial class TelaFuncionarioControl : UserControl
    {
        public TelaFuncionarioControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Admissao", HeaderText = "Data de Admissão"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Gerente", HeaderText = "Gerente"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Login, funcionario.Senha,
                    "R$ " + funcionario.Salario, funcionario.DataAdmissao.ToString("dd/MM/yyyy"), funcionario.GetGerente());

            }
        }
        public int ObtemNumeroFuncionarioSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
