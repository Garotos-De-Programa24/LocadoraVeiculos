using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo.ModuloAgrupamento
{
    public class ControladorAgrupamentoVeiculo : ControladorBase
    {
        private RepositorioAgrupamentoVeiculoEmBancoDados repositorioAgrupamentoVeiculo;
        
        public ControladorAgrupamentoVeiculo(RepositorioAgrupamentoVeiculoEmBancoDados repositorio)
        {
            this.repositorioAgrupamentoVeiculo = repositorio;
        }
        public override void Inserir()
        {
            TelaCadastroAgrupamentoCarros tela = new TelaCadastroAgrupamentoCarros();
            tela.Agrupamento = new Agrupamento();
            tela.GravarRegistro = repositorioAgrupamentoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarAgrupamento();
        }

       

        public override void Editar()
        {
            Agrupamento AgrupamentoSelecionado = ObtemGrupoVeiculoSelecionado();

            if (AgrupamentoSelecionado == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroAgrupamentoCarros tela = new TelaCadastroAgrupamentoCarros();

            tela.Agrupamento = AgrupamentoSelecionado;

            tela.GravarRegistro = repositorioAgrupamentoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarAgrupamento();
        }

       

        public override void Excluir()
        {
            Agrupamento agrupamentoSelecionado = ObtemGrupoVeiculoSelecionado();

            if (agrupamentoSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Exclusão de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Funcionario?",
                "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioAgrupamentoVeiculo.Excluir(agrupamentoSelecionado);
                CarregarAgrupamento();
            }
        }

        //teria que terminar e criar uma forma 
        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
        private Agrupamento ObtemGrupoVeiculoSelecionado()
        {
            throw new NotImplementedException();
        }
        private void CarregarAgrupamento()
        {
            throw new NotImplementedException();
        }

    }
}
