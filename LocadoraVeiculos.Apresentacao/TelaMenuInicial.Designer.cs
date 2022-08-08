namespace LocadoraVeiculos.Apresentacao
{
    partial class TelaMenuInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMenuInicial));
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.RodaPé = new System.Windows.Forms.StatusStrip();
            this.lValid = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolControl = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnCadastrar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnDevolucao = new System.Windows.Forms.ToolStripButton();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnAgrupamento = new System.Windows.Forms.Button();
            this.btnCondutor = new System.Windows.Forms.Button();
            this.btnPlano = new System.Windows.Forms.Button();
            this.btnTaxa = new System.Windows.Forms.Button();
            this.btnVeiculo = new System.Windows.Forms.Button();
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lStatus = new System.Windows.Forms.Label();
            this.lTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnLocacao = new System.Windows.Forms.Button();
            this.RodaPé.SuspendLayout();
            this.toolControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRegistros
            // 
            this.panelRegistros.BackColor = System.Drawing.Color.White;
            this.panelRegistros.Location = new System.Drawing.Point(151, 114);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(1119, 515);
            this.panelRegistros.TabIndex = 0;
            // 
            // RodaPé
            // 
            this.RodaPé.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lValid,
            this.status});
            this.RodaPé.Location = new System.Drawing.Point(0, 619);
            this.RodaPé.Name = "RodaPé";
            this.RodaPé.Size = new System.Drawing.Size(1270, 22);
            this.RodaPé.TabIndex = 0;
            this.RodaPé.Text = "Rodapé";
            // 
            // lValid
            // 
            this.lValid.Name = "lValid";
            this.lValid.Size = new System.Drawing.Size(0, 17);
            // 
            // status
            // 
            this.status.ActiveLinkColor = System.Drawing.Color.Black;
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(47, 17);
            this.status.Text = "Rodapé";
            // 
            // toolControl
            // 
            this.toolControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnCadastrar,
            this.btnEditar,
            this.btnExcluir,
            this.btnDevolucao});
            this.toolControl.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolControl.Location = new System.Drawing.Point(0, 77);
            this.toolControl.Name = "toolControl";
            this.toolControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolControl.Size = new System.Drawing.Size(1270, 39);
            this.toolControl.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(154, 36);
            this.toolStripLabel1.Text = "                                                 ";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz24__1_;
            this.btnCadastrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCadastrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Padding = new System.Windows.Forms.Padding(4);
            this.btnCadastrar.Size = new System.Drawing.Size(92, 36);
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.Click += new System.EventHandler(this.BtnCadastrar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.Icone_Editar;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(4);
            this.btnEditar.Size = new System.Drawing.Size(73, 36);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click_1);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExcluir.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.Icone_Deletar;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Size = new System.Drawing.Size(78, 36);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click_1);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDevolucao.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz24__1_;
            this.btnDevolucao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolucao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Padding = new System.Windows.Forms.Padding(4);
            this.btnDevolucao.Size = new System.Drawing.Size(100, 36);
            this.btnDevolucao.Text = "Devolucao";
            this.btnDevolucao.Visible = false;
            this.btnDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClientes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClientes.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.avaliacao_do_cliente;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 114);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(151, 34);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click_1);
            // 
            // btnAgrupamento
            // 
            this.btnAgrupamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgrupamento.FlatAppearance.BorderSize = 0;
            this.btnAgrupamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAgrupamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgrupamento.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgrupamento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgrupamento.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.pasta;
            this.btnAgrupamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgrupamento.Location = new System.Drawing.Point(0, 148);
            this.btnAgrupamento.Name = "btnAgrupamento";
            this.btnAgrupamento.Size = new System.Drawing.Size(151, 34);
            this.btnAgrupamento.TabIndex = 2;
            this.btnAgrupamento.Text = "Grupo de Veículos";
            this.btnAgrupamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgrupamento.UseVisualStyleBackColor = false;
            this.btnAgrupamento.Click += new System.EventHandler(this.btnAgrupamento_Click_1);
            // 
            // btnCondutor
            // 
            this.btnCondutor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCondutor.FlatAppearance.BorderSize = 0;
            this.btnCondutor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCondutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCondutor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCondutor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCondutor.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.volante;
            this.btnCondutor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCondutor.Location = new System.Drawing.Point(0, 182);
            this.btnCondutor.Name = "btnCondutor";
            this.btnCondutor.Size = new System.Drawing.Size(151, 34);
            this.btnCondutor.TabIndex = 3;
            this.btnCondutor.Text = "Condutores";
            this.btnCondutor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCondutor.UseVisualStyleBackColor = false;
            this.btnCondutor.Click += new System.EventHandler(this.btnCondutor_Click);
            // 
            // btnPlano
            // 
            this.btnPlano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPlano.FlatAppearance.BorderSize = 0;
            this.btnPlano.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlano.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlano.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlano.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.cobrança;
            this.btnPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlano.Location = new System.Drawing.Point(0, 216);
            this.btnPlano.Name = "btnPlano";
            this.btnPlano.Size = new System.Drawing.Size(151, 34);
            this.btnPlano.TabIndex = 4;
            this.btnPlano.Text = "Planos de Cobrança";
            this.btnPlano.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlano.UseVisualStyleBackColor = false;
            this.btnPlano.Click += new System.EventHandler(this.btnPlano_Click);
            // 
            // btnTaxa
            // 
            this.btnTaxa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTaxa.FlatAppearance.BorderSize = 0;
            this.btnTaxa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnTaxa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaxa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTaxa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTaxa.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.fatura;
            this.btnTaxa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaxa.Location = new System.Drawing.Point(0, 250);
            this.btnTaxa.Name = "btnTaxa";
            this.btnTaxa.Size = new System.Drawing.Size(151, 34);
            this.btnTaxa.TabIndex = 3;
            this.btnTaxa.Text = "Taxas";
            this.btnTaxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaxa.UseVisualStyleBackColor = false;
            this.btnTaxa.Click += new System.EventHandler(this.btnTaxa_Click);
            // 
            // btnVeiculo
            // 
            this.btnVeiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVeiculo.FlatAppearance.BorderSize = 0;
            this.btnVeiculo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVeiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeiculo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVeiculo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVeiculo.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.carro_esporte;
            this.btnVeiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeiculo.Location = new System.Drawing.Point(0, 284);
            this.btnVeiculo.Name = "btnVeiculo";
            this.btnVeiculo.Size = new System.Drawing.Size(151, 34);
            this.btnVeiculo.TabIndex = 4;
            this.btnVeiculo.Text = "Veículos";
            this.btnVeiculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVeiculo.UseVisualStyleBackColor = false;
            this.btnVeiculo.Click += new System.EventHandler(this.btnVeiculo_Click);
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFuncionario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFuncionario.FlatAppearance.BorderSize = 0;
            this.btnFuncionario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuncionario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFuncionario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFuncionario.Image = global::LocadoraVeiculos.Apresentacao.Properties.Resources.carteira_de_identidade;
            this.btnFuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuncionario.Location = new System.Drawing.Point(0, 318);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(151, 34);
            this.btnFuncionario.TabIndex = 4;
            this.btnFuncionario.Text = "Funcionários";
            this.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFuncionario.UseVisualStyleBackColor = false;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lStatus);
            this.panel1.Controls.Add(this.lTitulo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnEntrar);
            this.panel1.Controls.Add(this.lSenha);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.lLogin);
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.toolControl);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 116);
            this.panel1.TabIndex = 5;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lStatus.ForeColor = System.Drawing.Color.Red;
            this.lStatus.Location = new System.Drawing.Point(213, 13);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(82, 15);
            this.lStatus.TabIndex = 12;
            this.lStatus.Text = "Desconectado";
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(970, 22);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(291, 39);
            this.lTitulo.TabIndex = 11;
            this.lTitulo.Text = "Rech\'s Locadora";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1270, 10);
            this.panel2.TabIndex = 10;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEntrar.Location = new System.Drawing.Point(213, 38);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(83, 23);
            this.btnEntrar.TabIndex = 9;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lSenha
            // 
            this.lSenha.AutoSize = true;
            this.lSenha.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lSenha.ForeColor = System.Drawing.Color.White;
            this.lSenha.Location = new System.Drawing.Point(8, 41);
            this.lSenha.Name = "lSenha";
            this.lSenha.Size = new System.Drawing.Size(48, 16);
            this.lSenha.TabIndex = 8;
            this.lSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(57, 38);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(150, 23);
            this.txtSenha.TabIndex = 7;
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lLogin.ForeColor = System.Drawing.Color.White;
            this.lLogin.Location = new System.Drawing.Point(12, 12);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(43, 16);
            this.lLogin.TabIndex = 6;
            this.lLogin.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(57, 9);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(150, 23);
            this.txtLogin.TabIndex = 5;
            // 
            // btnLocacao
            // 
            this.btnLocacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLocacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLocacao.FlatAppearance.BorderSize = 0;
            this.btnLocacao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLocacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocacao.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLocacao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLocacao.Image = ((System.Drawing.Image)(resources.GetObject("btnLocacao.Image")));
            this.btnLocacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocacao.Location = new System.Drawing.Point(0, 352);
            this.btnLocacao.Name = "btnLocacao";
            this.btnLocacao.Size = new System.Drawing.Size(151, 34);
            this.btnLocacao.TabIndex = 6;
            this.btnLocacao.Text = "Locação";
            this.btnLocacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocacao.UseVisualStyleBackColor = false;
            this.btnLocacao.Click += new System.EventHandler(this.btnLocacao_Click);
            // 
            // TelaMenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1270, 641);
            this.Controls.Add(this.btnLocacao);
            this.Controls.Add(this.RodaPé);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnAgrupamento);
            this.Controls.Add(this.btnCondutor);
            this.Controls.Add(this.btnPlano);
            this.Controls.Add(this.btnFuncionario);
            this.Controls.Add(this.btnTaxa);
            this.Controls.Add(this.btnVeiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaMenuInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaMenuInicial";
            this.RodaPé.ResumeLayout(false);
            this.RodaPé.PerformLayout();
            this.toolControl.ResumeLayout(false);
            this.toolControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStrip toolControl;
        private System.Windows.Forms.ToolStripButton btnCadastrar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnAgrupamento;
        private System.Windows.Forms.Button btnCondutor;
        private System.Windows.Forms.Button btnPlano;
        private System.Windows.Forms.Button btnTaxa;
        private System.Windows.Forms.Button btnVeiculo;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.StatusStrip RodaPé;
        private System.Windows.Forms.ToolStripStatusLabel lValid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button btnLocacao;
        private System.Windows.Forms.ToolStripButton btnDevolucao;
    }
}