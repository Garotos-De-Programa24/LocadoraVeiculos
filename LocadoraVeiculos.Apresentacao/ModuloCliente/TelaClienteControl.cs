﻿using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf/Cnpj", HeaderText = "CPF/CNPJ"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},
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
                     cliente.Email, cliente.Telefone);
                
            }
        }

        public Guid ObtemNumeroClienteSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
