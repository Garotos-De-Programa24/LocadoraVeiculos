using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {        
        private TelaVeiculoControl telaVeiculoControl;
        private readonly ServicoVeiculo servicoVeiculo;
        private ServicoAgrupamento servicoAgrupamento;
        public ControladorVeiculo(ServicoVeiculo servicoVeiculo,ServicoAgrupamento servicoAgrupamento)
        {            
            this.servicoVeiculo = servicoVeiculo;
            this.servicoAgrupamento = servicoAgrupamento;
        }

        public override void Inserir(Funcionario funcionario)
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(ObterAgrupamentos());
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregaVeiculo();
        }

        private List<Agrupamento> ObterAgrupamentos()
        {
            var resultadoDoresult = servicoAgrupamento.SelecionarTodos();
            List<Agrupamento> agrupamentos = new List<Agrupamento>();

            if (resultadoDoresult.IsSuccess)
                agrupamentos = resultadoDoresult.Value;

            return agrupamentos;
        }

        public override void Editar(Funcionario funcionario)
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione uma Veiculo primeiro",
                "Edição de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(ObterAgrupamentos());

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregaVeiculo();

        }

        public override void Excluir(Funcionario funcionario)
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
                servicoVeiculo.Excluir(veiculoSelecionado);
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
            var resultado = servicoVeiculo.SelecionarPorId(id);
            Veiculo veiculoSelecionado = null;
            if (resultado.IsSuccess)
            {
                veiculoSelecionado = resultado.Value;
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Selecionar Veiculo Selecionada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return veiculoSelecionado;
        }
    }
}
