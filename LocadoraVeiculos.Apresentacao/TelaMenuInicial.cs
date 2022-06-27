using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao
{
    public partial class TelaMenuInicial : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        
        public TelaMenuInicial()
        {
            InitializeComponent();
            Instancia = this;
            InicializarControladores();
        }
        public static TelaMenuInicial Instancia
        {
            get;
            private set;
        }
        private void InicializarControladores()
        {
            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            //var repositorioMateria = new RepositorioMateriaEmArquivo(dataContext);
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            //var repositorioTeste = new RepositorioTesteEmArquivo(dataContext);
            controladores = new Dictionary<string, ControladorBase>();
            controladores.Add("Clientes", new ControladorCliente(repositorioCliente));
            controladores.Add("Funcionário", new ControladorFuncionario(repositorioFuncionario));
            //controladores.Add("Matérias", new ControladorMateria(repositorioMateria, repositorioDisciplina));
            //controladores.Add("Questões", new ControladorQuestao(repositorioQuestao, repositorioDisciplina, repositorioMateria));
            //controladores.Add("Testes", new ControladorTeste(repositorioTeste, repositorioDisciplina, repositorioMateria, repositorioQuestao));
            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa));
        }
        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Funcionário");

        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Clientes");
        }
        private void ConfigurarTelaPrincipal(string tipo)
        {
            controlador = controladores[tipo];

            ConfigurarListagem();
        }
        private void ConfigurarListagem()
        {
            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        

        private void btnTaxas_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Taxas");
        }
    }
}
