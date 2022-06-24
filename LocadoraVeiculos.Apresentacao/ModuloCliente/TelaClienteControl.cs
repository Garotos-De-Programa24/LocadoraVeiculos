﻿using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCliente
{
    public partial class TelaClienteControl : UserControl
    {
        public TelaClienteControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CpfCnpj", HeaderText = "CPF/CNPJ"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CnhCondutor", HeaderText = "CNH Condutor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValidadeCnh", HeaderText = "Validade CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-Mail"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (var cliente in clientes)
            {
                grid.Rows.Add(cliente.Id, cliente.Nome, cliente.CpfCnpj, cliente.Endereco,
                    cliente.CnhCondutor, cliente.ValidadeCnh.ToString("dd/MM/yyyy"), cliente.Email, cliente.Telefone);
                
            }
        }

        public int ObtemNumeroClienteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}