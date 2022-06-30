using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCondutor;
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
        bool gerente = false;
        string login;
        string senha;

        public TelaMenuInicial()
        {
            InitializeComponent();
            Instancia = this;
            InicializarControladores();
            btnCadastrar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
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
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            var repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDados();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoGrupoVeiculo = new ServicoAgrupamento(repositorioAgrupamento);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Clientes", new ControladorCliente(repositorioCliente, servicoCliente));
            controladores.Add("Agrupamentos", new ControladorAgrupamento(repositorioAgrupamento, servicoGrupoVeiculo));
            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa, servicoTaxa));
            controladores.Add("Condutores", new ControladorCondutor(repositorioCondutor, servicoCondutor));
            controladores.Add("Funcionarios", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
        }
        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            if(gerente == true)
            ConfigurarTelaPrincipal("Funcionarios");

            if (gerente == false)
            {
                MessageBox.Show("Você não tem permissão para acessar essa tabela",
                "Tela Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Clientes");
        }

        private void btnAgrupamento_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Agrupamentos");
        }

        private void btnTaxas_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Taxas");
        }

        private void btnCondutores_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Condutores");
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
            if(controlador != null)
                controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (controlador != null)
                controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (controlador != null)
                controlador.Excluir();
        }

        

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            login = txtLogin.Text;
            senha = txtSenha.Text;
            bool statusLogin = false;

            RepositorioFuncionarioEmBancoDados rep = new RepositorioFuncionarioEmBancoDados();

            List<Funcionario> funcionarios = rep.SelecionarTodos();

            //abertura do programa sem senha!
            if (btnEntrar.Text == "Deslogar")
            {
                gerente = false;
                lStatus.Text = "DESLOGADO";
                lStatus.ForeColor = System.Drawing.Color.Red;
                statusLogin = false;
                txtLogin.Enabled = true;
                txtLogin.Text = "";
                txtSenha.Enabled = true;
                txtSenha.Text = "";
                btnCadastrar.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnEntrar.Text = "Entrar";
                ConfigurarTelaPrincipal("Clientes");
                return;
            }

            if (login.ToLower() == "admin" && senha.ToLower() == "admin")
            {
                gerente = true;
                lStatus.Text = "LOGADO";
                lStatus.ForeColor = System.Drawing.Color.Green;
                statusLogin = true;
                txtLogin.Enabled = false;
                txtSenha.Enabled = false;
                btnCadastrar.Enabled = true;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnEntrar.Text = "Deslogar";
                return;
            }

            foreach (Funcionario f in funcionarios)
            {
                if (f.Login.ToLower() == login.ToLower())
                {
                    if (f.Senha == senha)
                    {
                        if (f.Gerente == true)
                            gerente = true;

                        lStatus.Text = "LOGADO";
                        lStatus.ForeColor = System.Drawing.Color.Green;
                        statusLogin = true;
                        txtLogin.Enabled = false;
                        txtSenha.Enabled = false;
                        btnCadastrar.Enabled = true;
                        btnEditar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnEntrar.Text = "Deslogar";
                        break;
                    }
                    else
                        break;
                }
                else
                {
                    lStatus.Text = "LOGIN OU SENHA INCORRETOS";                    
                }
            }
        }

        
    }
}
