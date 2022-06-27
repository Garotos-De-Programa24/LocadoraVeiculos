﻿using LocadoraVeiculos.Apresentacao.Compartilhado;
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
        private RepositorioTaxaEmBancoDados repositorioTaxa;
        private TelaTaxaControl telaTaxaControl;


        public ControladorTaxa(RepositorioTaxaEmBancoDados repositorioCliente)
        {
            this.repositorioTaxa = repositorioCliente;
        }

        public override void Inserir()
        {
            TelaCadastroTaxa tela = new TelaCadastroTaxa();
            tela.Taxa = new Taxa();
            tela.GravarRegistro = repositorioTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarTaxa();
        }

        public override void Editar()
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

            tela.GravarRegistro = repositorioTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxa();

        }

        public override void Excluir()
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
                repositorioTaxa.Excluir(clienteSelecionado);
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
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();

            telaTaxaControl.AtualizarRegistros(taxas);
        }
        private Taxa ObtemTaxaSelecionado()
        {
            var id = telaTaxaControl.ObtemNumeroTaxaSelecionado();

            return repositorioTaxa.SelecionarPorId(id);
        }
      
    }

}