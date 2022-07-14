using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;
        private TelaVeiculoControl telaVeiculoControl;
        private readonly ServicoVeiculo servicoVeiculo;


        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, ServicoVeiculo servicoVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo();
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregaVeiculo();
        }
        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione uma Veiculo primeiro",
                "Edição de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo();

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregaVeiculo();

        }

        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Exclusão de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Veiculo?",
                "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculo.Excluir(veiculoSelecionado);
                CarregaVeiculo();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (telaVeiculoControl == null)
                telaVeiculoControl = new TelaVeiculoControl();

            CarregaVeiculo();

            return telaVeiculoControl;
        }
        private void CarregaVeiculo()
        {
            var resultado = servicoVeiculo.SelecionarTodos();
            if (resultado.IsSuccess)
            {
                List<Veiculo> funcionarios = resultado.Value;

                telaVeiculoControl.AtualizarRegistros(funcionarios);
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar todos os Funcionarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Veiculo ObtemVeiculoSelecionado()
        {
            var id = telaVeiculoControl.ObtemNumeroVeiculoSelecionado();

            return repositorioVeiculo.SelecionarPorId(id);
        }
    }
}
