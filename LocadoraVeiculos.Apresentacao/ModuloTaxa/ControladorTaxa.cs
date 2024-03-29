﻿using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloTaxa
{
    internal class ControladorTaxa : ControladorBase
    {
        private TelaTaxaControl telaTaxaControl;
        private readonly ServicoTaxa servicoTaxa;


        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir(Funcionario funcionario)
        {
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = new Taxa();
            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarTaxa();
        }

        public override void Editar(Funcionario funcionario)
        {
            Taxa clienteSelecionado = ObtemTaxaSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxa tela = new TelaCadastroTaxa();

            tela.Taxa = clienteSelecionado;

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxa();

        }

        public override void Excluir(Funcionario funcionario)
        {
            Taxa clienteSelecionado = ObtemTaxaSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoTaxa.Excluir(clienteSelecionado);
                CarregarTaxa();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (telaTaxaControl == null)
                telaTaxaControl = new TelaTaxaControl();

            CarregarTaxa();

            return telaTaxaControl;
        }

        private void CarregarTaxa()
        {
            var resultado = servicoTaxa.SelecionarTodos();
            if (resultado.IsSuccess)
            {
                List<Taxa> funcionarios = resultado.Value;

                telaTaxaControl.AtualizarRegistros(funcionarios);
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar todas as Taxas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Taxa ObtemTaxaSelecionado()
        {
            var id = telaTaxaControl.ObtemNumeroTaxaSelecionado();
            var resultado = servicoTaxa.SelecionarPorId(id);
            Taxa taxaSeleciondo = null;
            if (resultado.IsSuccess)
            {
                taxaSeleciondo = resultado.Value;

            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar a Taxa Selecionada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return taxaSeleciondo;
        }
      
    }

}
