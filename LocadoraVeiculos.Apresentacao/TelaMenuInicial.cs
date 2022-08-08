using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.Compartilhado.ServiceLocator;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloLocacao;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloFuncionario;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloFuncionario;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao
{
    public partial class TelaMenuInicial : Form
    {
        private ControladorBase controlador;
        private ControladorLocacao controladorLocacao;
        private IServiceLocator serviceLocator;
        bool gerente = false;
        string login;
        string senha;
        Funcionario funcionarioLogado;

        public TelaMenuInicial(IServiceLocator serviceLocator)
        {
            InitializeComponent();
            this.serviceLocator = serviceLocator;
            Instancia = this;
            txtLogin.Text = "admin";
            txtSenha.Text = "admin";
        }
        public static TelaMenuInicial Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            status.Text = mensagem;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;
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
            controlador = serviceLocator.Get<ControladorCliente>();
            btnDevolucao.Visible = false;

            ConfigurarTelaPrincipal(controlador);
        }        

        private void btnAgrupamento_Click_1(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorAgrupamento>();
            btnDevolucao.Visible = false;

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnCondutor_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorCondutor>();
            btnDevolucao.Visible = false;
            
            ConfigurarTelaPrincipal(controlador);
        }

        private void btnPlano_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorPlanoDeCobranca>();
            btnDevolucao.Visible = false;

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnTaxa_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorTaxa>();
            btnDevolucao.Visible = false;

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorVeiculo>();
            btnDevolucao.Visible = false;

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnLocacao_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorLocacao>();
            btnDevolucao.Visible = true;
            ConfigurarTelaPrincipal(controlador);
            
        }

        private void btnFuncionario_Click_1(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorFuncionario>();
            btnDevolucao.Visible = false;

            if (gerente == true)
                ConfigurarTelaPrincipal(controlador);

            if (gerente == false)
            {
                MessageBox.Show("Você não tem permissão para acessar essa tabela",
                "Tela Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void BtnCadastrar_Click_1(object sender, EventArgs e)
        {
            
            if (controlador != null && funcionarioLogado != null)
                controlador.Inserir(funcionarioLogado);
            else
            {
                MessageBox.Show("Realize o login para fazer um Cadastro",
                "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            if (controlador != null && funcionarioLogado != null)
                controlador.Editar(funcionarioLogado);
            else
            {
                MessageBox.Show("Realize o login para fazer uma Edição",
               "Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void BtnExcluir_Click_1(object sender, EventArgs e)
        {
            if (controlador != null && funcionarioLogado != null)
                controlador.Excluir(funcionarioLogado);
            else
            {
                MessageBox.Show("Realize o login para fazer uma Exclusão",
               "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            if (controlador != null && funcionarioLogado != null)
            {
                controladorLocacao = (ControladorLocacao)controlador;
                controladorLocacao.Devolucao(funcionarioLogado);
            }
            else
            {
                MessageBox.Show("Realize o login para fazer uma Devolução",
               "Devolução", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            login = txtLogin.Text;
            senha = txtSenha.Text;
            bool statusLogin = false;

            //isto aqui serve apenas como controle de danos, cso de problemas na seleção dos Funcionarios, no momento do login.
            //RepositorioFuncionarioEmBancoDados rep = new RepositorioFuncionarioEmBancoDados();
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("ConfiguracaoAplicacaoORM.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            var contextoDadosOrm = new LocadoraVeiculoDbContext(connectionString);

            RepositorioFuncionarioORM rep = new RepositorioFuncionarioORM(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(rep,contextoDadosOrm);
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
                funcionarioLogado = null;
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
                return;
            }

            if (login.ToLower() == "admin" && senha.ToLower() == "admin")
            {
                funcionarioLogado = new Funcionario("ADMIN","admin","admin","10", DateTime.Today, true);

                gerente = funcionarioLogado.Gerente;
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
                        funcionarioLogado = f;
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
