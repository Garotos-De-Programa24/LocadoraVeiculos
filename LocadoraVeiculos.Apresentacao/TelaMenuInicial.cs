using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Clientes", new ControladorCliente(repositorioCliente));
            controladores.Add("Agrupamentos", new ControladorAgrupamento(repositorioAgrupamento));
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Clientes");
        }

        private void btnAgrupamento_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Agrupamentos");
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

        
    }
}
