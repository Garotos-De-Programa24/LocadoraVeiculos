﻿using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        
        private TelaFuncionarioControl telaFuncionarioControl;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir(Funcionario funcionario)
        {
            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();
            tela.Funcionario = new Funcionario();
            tela.GravarRegistro = servicoFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar(Funcionario funcionario)
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir(Funcionario funcionario)
        {

            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Exclusão de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Funcionario?",
                "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
        }


        public override UserControl ObtemListagem()
        {
            if (telaFuncionarioControl == null)
                telaFuncionarioControl = new TelaFuncionarioControl();

            CarregarFuncionarios();

            return telaFuncionarioControl;
        }
        private Funcionario ObtemFuncionarioSelecionado()
        {
            var id = telaFuncionarioControl.ObtemNumeroFuncionarioSelecionado();
            var resultado = servicoFuncionario.SelecionarPorId(id);
            Funcionario funcionario = null;
            if (resultado.IsSuccess)
            {
                funcionario = resultado.Value;
                
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar todos os Funcionarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return funcionario;
        }
        private void CarregarFuncionarios()
        {
            var resultado = servicoFuncionario.SelecionarTodos();
            if (resultado.IsSuccess) {
                List<Funcionario> funcionarios = resultado.Value;

            telaFuncionarioControl.AtualizarRegistros(funcionarios);
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar todos os Funcionarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
