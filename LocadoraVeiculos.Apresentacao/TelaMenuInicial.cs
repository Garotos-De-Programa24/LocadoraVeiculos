using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.Compartilhado.ServiceLocator;
using LocadoraVeiculos.Apresentacao.ModuloAgrupamento;
using LocadoraVeiculos.Apresentacao.ModuloCliente;
using LocadoraVeiculos.Apresentacao.ModuloCondutor;
using LocadoraVeiculos.Apresentacao.ModuloFuncionario;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.ModuloTaxa;
using LocadoraVeiculos.Apresentacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao
{
    public partial class TelaMenuInicial : Form
    {
        private ControladorBase controlador;
        //private ServiceLocatorManual serviceLocator = new ServiceLocatorManual(); refatorar depois
        private IServiceLocator serviceLocator;
        bool gerente = false;
        string login;
        string senha;

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
            ConfigurarTelaPrincipal(controlador);
        }        

        private void btnAgrupamento_Click_1(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorAgrupamento>();

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnCondutor_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorCondutor>();

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnPlano_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorPlanoDeCobranca>();

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnTaxa_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorTaxa>();

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorVeiculo>();

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnFuncionario_Click_1(object sender, EventArgs e)
        {
            controlador = serviceLocator.Get<ControladorFuncionario>();

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
                ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
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
