﻿using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCliente
{
    public partial class TelaCadastroCliente : Form
    {
        public TelaCadastroCliente()
        {
            InitializeComponent();
        }
        private Cliente cliente;
        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                txtNome.Text = cliente.Nome;
                txtCPFCNPJ.Text = cliente.CpfCnpj;
                txtEndereco.Text = cliente.Endereco;
                txtCNHCondutor.Text = cliente.CnhCondutor;
                dateValidade.Value = cliente.ValidadeCnh;
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
            }
        }        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.CpfCnpj = txtCPFCNPJ.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.CnhCondutor = txtCNHCondutor.Text;
            cliente.ValidadeCnh = dateValidade.Value;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;

            var resultadoValidacao = GravarRegistro(cliente);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                DialogResult = DialogResult.None;
            }
        }
    }
}