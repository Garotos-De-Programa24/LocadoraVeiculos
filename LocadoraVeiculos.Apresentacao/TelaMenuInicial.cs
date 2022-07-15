using LocadoraVeiculos.Aplicacao.ModuloAgrupamento;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloCliente;
using LocadoraVeiculos.Infra.ModuloCondutor;
using LocadoraVeiculos.Infra.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ModuloTaxa;
using LocadoraVeiculos.Infra.ModuloVeiculo;
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
            txtLogin.Text = "admin";
            txtSenha.Text = "admin";
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
            var repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmBancoDados();
            var repositorioVeiculo = new RepositorioVeiculoEmBancoDados();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoGrupoVeiculo = new ServicoAgrupamento(repositorioAgrupamento);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Clientes", new ControladorCliente(servicoCliente));
            controladores.Add("Agrupamentos", new ControladorAgrupamento(servicoGrupoVeiculo));
            controladores.Add("Taxas", new ControladorTaxa(servicoTaxa));
            controladores.Add("Condutores", new ControladorCondutor(servicoCondutor));
            controladores.Add("Funcionarios", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("Planos", new ControladorPlanoDeCobranca(servicoPlanoCobranca));
            controladores.Add("Veiculos", new ControladorVeiculo(repositorioVeiculo, servicoVeiculo));
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

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Clientes");
        }        

        private void btnAgrupamento_Click_1(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Agrupamentos");
        }

        private void btnCondutor_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Condutores");
        }

        private void btnPlano_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Planos");
        }

        private void btnTaxa_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Taxas");
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal("Veiculos");
        }

        private void btnFuncionario_Click_1(object sender, EventArgs e)
        {
            if (gerente == true)
                ConfigurarTelaPrincipal("Funcionarios");

            if (gerente == false)
            {
                MessageBox.Show("Você não tem permissão para acessar essa tabela",
                "Tela Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void BtnCadastrar_Click_1(object sender, EventArgs e)
        {
            if (controlador != null)
                controlador.Inserir();
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            if (controlador != null)
                controlador.Editar();
        }

        private void BtnExcluir_Click_1(object sender, EventArgs e)
        {
            if (controlador != null)
                controlador.Excluir();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            login = txtLogin.Text;
            senha = txtSenha.Text;
            bool statusLogin = false;

            //isto aqui serve apenas como controle de danos, cso de problemas na seleção dos Funcionarios, no momento do login.
            RepositorioFuncionarioEmBancoDados rep = new RepositorioFuncionarioEmBancoDados();
            var servicoFuncionario = new ServicoFuncionario(rep);
            TelaFuncionarioControl telaFuncionarioControl = new TelaFuncionarioControl();
            List<Funcionario> funcionarios = null;
            var resultado = servicoFuncionario.SelecionarTodos();
            if (resultado.IsSuccess)
            {
                funcionarios = resultado.Value;

                telaFuncionarioControl.AtualizarRegistros(funcionarios);
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show( resultado.Errors[0].Message, "Selecionar todos os Funcionarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //-----------------------------------------------------------------------------------------------------------------

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

                        lStatus.Text = "Conectado";
                        lStatus.ForeColor = System.Drawing.Color.Green;
                        statusLogin = true;
                        txtLogin.Enabled = false;
                        txtSenha.Enabled = false;                        
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
