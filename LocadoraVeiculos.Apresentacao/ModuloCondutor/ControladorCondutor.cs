using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private TelaCondutorControl telaCondutorControl;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor)
        {
            this.servicoCondutor = servicoCondutor;
            this.repositorioCondutor = repositorioCondutor;
        }

        public override void Inserir()
        {
            TelaCadastroCondutor tela = new TelaCadastroCondutor();
            tela.Condutor = new Condutor();
            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Editar()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione uma Condutor primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutor tela = new TelaCadastroCondutor();

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();

        }

        public override void Excluir()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Condutor?",
                "Exclusão de Condutores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCondutor.Excluir(condutorSelecionado);
                CarregarCondutores();
            }
        }
        //comit
        public override UserControl ObtemListagem()
        {
            if (telaCondutorControl == null)
                telaCondutorControl = new TelaCondutorControl();

            CarregarCondutores();

            return telaCondutorControl;
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();

            telaCondutorControl.AtualizarRegistros(condutores);
        }

        private Condutor ObtemCondutorSelecionado()
        {
            var id = telaCondutorControl.ObtemNumeroCondutorSelecionado();

            return repositorioCondutor.SelecionarPorId(id);
        }
    }
}
