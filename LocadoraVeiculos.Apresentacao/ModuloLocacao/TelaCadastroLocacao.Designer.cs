﻿namespace LocadoraVeiculos.Apresentacao.Modulolocacao
{
    partial class TelaCadastroLocacao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lTitulo = new System.Windows.Forms.Label();
            this.lFuncionario = new System.Windows.Forms.Label();
            this.lCliente = new System.Windows.Forms.Label();
            this.lCondutor = new System.Windows.Forms.Label();
            this.lAgrupamento = new System.Windows.Forms.Label();
            this.lVeículo = new System.Windows.Forms.Label();
            this.lPlano = new System.Windows.Forms.Label();
            this.lTaxa = new System.Windows.Forms.Label();
            this.listEquipamentos = new System.Windows.Forms.ListBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.lDataLocacao = new System.Windows.Forms.Label();
            this.lTempoLocacao = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.cboxCliente = new System.Windows.Forms.ComboBox();
            this.cboxCondutor = new System.Windows.Forms.ComboBox();
            this.cboxAgrupamento = new System.Windows.Forms.ComboBox();
            this.cboxVeiculo = new System.Windows.Forms.ComboBox();
            this.cboxPlano = new System.Windows.Forms.ComboBox();
            this.cboxTaxa = new System.Windows.Forms.ComboBox();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.dataLocacaoBox = new System.Windows.Forms.DateTimePicker();
            this.lTituloDadosLocador = new System.Windows.Forms.Label();
            this.lDadosCliente = new System.Windows.Forms.Label();
            this.lTituloDadosVeiculo = new System.Windows.Forms.Label();
            this.lDadosVeiculo = new System.Windows.Forms.Label();
            this.lDadosTaxa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lDadosLocacao = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnGerarPdf = new System.Windows.Forms.Button();
            this.lSubTotal = new System.Windows.Forms.Label();
            this.lValor = new System.Windows.Forms.Label();
            this.lCifrao = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureCarro = new System.Windows.Forms.PictureBox();
            this.dataTempoLocacaoBox = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCarro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1208, 16);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1208, 53);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(610, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Resumo de Locação";
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(212, 25);
            this.lTitulo.TabIndex = 9;
            this.lTitulo.Text = "Locação de Veículos";
            // 
            // lFuncionario
            // 
            this.lFuncionario.AutoSize = true;
            this.lFuncionario.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lFuncionario.Location = new System.Drawing.Point(73, 74);
            this.lFuncionario.Name = "lFuncionario";
            this.lFuncionario.Size = new System.Drawing.Size(79, 17);
            this.lFuncionario.TabIndex = 8;
            this.lFuncionario.Text = "Funcionário";
            // 
            // lCliente
            // 
            this.lCliente.AutoSize = true;
            this.lCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lCliente.Location = new System.Drawing.Point(103, 114);
            this.lCliente.Name = "lCliente";
            this.lCliente.Size = new System.Drawing.Size(49, 17);
            this.lCliente.TabIndex = 9;
            this.lCliente.Text = "Cliente";
            // 
            // lCondutor
            // 
            this.lCondutor.AutoSize = true;
            this.lCondutor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lCondutor.Location = new System.Drawing.Point(86, 154);
            this.lCondutor.Name = "lCondutor";
            this.lCondutor.Size = new System.Drawing.Size(66, 17);
            this.lCondutor.TabIndex = 10;
            this.lCondutor.Text = "Condutor";
            // 
            // lAgrupamento
            // 
            this.lAgrupamento.AutoSize = true;
            this.lAgrupamento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lAgrupamento.Location = new System.Drawing.Point(34, 194);
            this.lAgrupamento.Name = "lAgrupamento";
            this.lAgrupamento.Size = new System.Drawing.Size(118, 17);
            this.lAgrupamento.TabIndex = 11;
            this.lAgrupamento.Text = "Grupo De Veículos";
            // 
            // lVeículo
            // 
            this.lVeículo.AutoSize = true;
            this.lVeículo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lVeículo.Location = new System.Drawing.Point(102, 234);
            this.lVeículo.Name = "lVeículo";
            this.lVeículo.Size = new System.Drawing.Size(50, 17);
            this.lVeículo.TabIndex = 12;
            this.lVeículo.Text = "Veículo";
            // 
            // lPlano
            // 
            this.lPlano.AutoSize = true;
            this.lPlano.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lPlano.Location = new System.Drawing.Point(30, 274);
            this.lPlano.Name = "lPlano";
            this.lPlano.Size = new System.Drawing.Size(122, 17);
            this.lPlano.TabIndex = 13;
            this.lPlano.Text = "Plano de Cobrança";
            // 
            // lTaxa
            // 
            this.lTaxa.AutoSize = true;
            this.lTaxa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lTaxa.Location = new System.Drawing.Point(11, 314);
            this.lTaxa.Name = "lTaxa";
            this.lTaxa.Size = new System.Drawing.Size(141, 17);
            this.lTaxa.TabIndex = 14;
            this.lTaxa.Text = "Taxas / Equipamentos";
            // 
            // listEquipamentos
            // 
            this.listEquipamentos.DisplayMember = "Equipamento";
            this.listEquipamentos.FormattingEnabled = true;
            this.listEquipamentos.ItemHeight = 15;
            this.listEquipamentos.Location = new System.Drawing.Point(158, 357);
            this.listEquipamentos.Name = "listEquipamentos";
            this.listEquipamentos.Size = new System.Drawing.Size(332, 109);
            this.listEquipamentos.TabIndex = 15;
            this.listEquipamentos.ValueMember = "Equipamento";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(496, 357);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(95, 50);
            this.btnAdicionar.TabIndex = 16;
            this.btnAdicionar.Text = "Adicionar Equipamento";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(496, 416);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(95, 50);
            this.btnRemover.TabIndex = 17;
            this.btnRemover.Text = "Remover Equipamento";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // lDataLocacao
            // 
            this.lDataLocacao.AutoSize = true;
            this.lDataLocacao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDataLocacao.Location = new System.Drawing.Point(45, 484);
            this.lDataLocacao.Name = "lDataLocacao";
            this.lDataLocacao.Size = new System.Drawing.Size(107, 17);
            this.lDataLocacao.TabIndex = 18;
            this.lDataLocacao.Text = "Data da Locação";
            // 
            // lTempoLocacao
            // 
            this.lTempoLocacao.AutoSize = true;
            this.lTempoLocacao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lTempoLocacao.Location = new System.Drawing.Point(32, 523);
            this.lTempoLocacao.Name = "lTempoLocacao";
            this.lTempoLocacao.Size = new System.Drawing.Size(120, 17);
            this.lTempoLocacao.TabIndex = 19;
            this.lTempoLocacao.Text = "Tempo de Locação";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(444, 591);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 38);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar Locação";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(290, 591);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(148, 38);
            this.btnCadastrar.TabIndex = 21;
            this.btnCadastrar.Text = "Cadastrar Locação";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // cboxCliente
            // 
            this.cboxCliente.DisplayMember = "Nome";
            this.cboxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCliente.FormattingEnabled = true;
            this.cboxCliente.Location = new System.Drawing.Point(158, 114);
            this.cboxCliente.Name = "cboxCliente";
            this.cboxCliente.Size = new System.Drawing.Size(432, 23);
            this.cboxCliente.TabIndex = 22;
            this.cboxCliente.ValueMember = "Nome";
            this.cboxCliente.SelectedIndexChanged += new System.EventHandler(this.cboxCliente_SelectedIndexChanged);
            // 
            // cboxCondutor
            // 
            this.cboxCondutor.DisplayMember = "Nome";
            this.cboxCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCondutor.FormattingEnabled = true;
            this.cboxCondutor.Location = new System.Drawing.Point(158, 154);
            this.cboxCondutor.Name = "cboxCondutor";
            this.cboxCondutor.Size = new System.Drawing.Size(432, 23);
            this.cboxCondutor.TabIndex = 23;
            this.cboxCondutor.ValueMember = "Nome";
            this.cboxCondutor.SelectedIndexChanged += new System.EventHandler(this.cboxCondutor_SelectedIndexChanged);
            // 
            // cboxAgrupamento
            // 
            this.cboxAgrupamento.DisplayMember = "Nome";
            this.cboxAgrupamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAgrupamento.FormattingEnabled = true;
            this.cboxAgrupamento.Location = new System.Drawing.Point(158, 194);
            this.cboxAgrupamento.Name = "cboxAgrupamento";
            this.cboxAgrupamento.Size = new System.Drawing.Size(432, 23);
            this.cboxAgrupamento.TabIndex = 24;
            this.cboxAgrupamento.ValueMember = "Nome";
            this.cboxAgrupamento.SelectedIndexChanged += new System.EventHandler(this.cboxAgrupamento_SelectedIndexChanged);
            // 
            // cboxVeiculo
            // 
            this.cboxVeiculo.DisplayMember = "VeiculoNome";
            this.cboxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxVeiculo.FormattingEnabled = true;
            this.cboxVeiculo.Location = new System.Drawing.Point(158, 234);
            this.cboxVeiculo.Name = "cboxVeiculo";
            this.cboxVeiculo.Size = new System.Drawing.Size(432, 23);
            this.cboxVeiculo.TabIndex = 25;
            this.cboxVeiculo.ValueMember = "VeiculoNome";
            this.cboxVeiculo.SelectedIndexChanged += new System.EventHandler(this.cboxVeiculo_SelectedIndexChanged);
            // 
            // cboxPlano
            // 
            this.cboxPlano.DisplayMember = "NomePlano";
            this.cboxPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPlano.FormattingEnabled = true;
            this.cboxPlano.Location = new System.Drawing.Point(158, 274);
            this.cboxPlano.Name = "cboxPlano";
            this.cboxPlano.Size = new System.Drawing.Size(432, 23);
            this.cboxPlano.TabIndex = 26;
            this.cboxPlano.ValueMember = "NomePlano";
            this.cboxPlano.SelectedIndexChanged += new System.EventHandler(this.cboxPlano_SelectedIndexChanged);
            // 
            // cboxTaxa
            // 
            this.cboxTaxa.DisplayMember = "Equipamento";
            this.cboxTaxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTaxa.FormattingEnabled = true;
            this.cboxTaxa.Location = new System.Drawing.Point(158, 314);
            this.cboxTaxa.Name = "cboxTaxa";
            this.cboxTaxa.Size = new System.Drawing.Size(432, 23);
            this.cboxTaxa.TabIndex = 27;
            this.cboxTaxa.ValueMember = "Equipamento";
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Enabled = false;
            this.txtFuncionario.Location = new System.Drawing.Point(158, 74);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(432, 23);
            this.txtFuncionario.TabIndex = 28;
            // 
            // dataLocacaoBox
            // 
            this.dataLocacaoBox.Location = new System.Drawing.Point(158, 484);
            this.dataLocacaoBox.Name = "dataLocacaoBox";
            this.dataLocacaoBox.Size = new System.Drawing.Size(432, 23);
            this.dataLocacaoBox.TabIndex = 29;
            // 
            // lTituloDadosLocador
            // 
            this.lTituloDadosLocador.AutoSize = true;
            this.lTituloDadosLocador.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lTituloDadosLocador.Location = new System.Drawing.Point(621, 75);
            this.lTituloDadosLocador.Name = "lTituloDadosLocador";
            this.lTituloDadosLocador.Size = new System.Drawing.Size(130, 18);
            this.lTituloDadosLocador.TabIndex = 31;
            this.lTituloDadosLocador.Text = "Dados do Cliente";
            // 
            // lDadosCliente
            // 
            this.lDadosCliente.AutoSize = true;
            this.lDadosCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosCliente.Location = new System.Drawing.Point(621, 93);
            this.lDadosCliente.Name = "lDadosCliente";
            this.lDadosCliente.Size = new System.Drawing.Size(160, 17);
            this.lDadosCliente.TabIndex = 32;
            this.lDadosCliente.Text = "[Cliente não Selecionado]";
            // 
            // lTituloDadosVeiculo
            // 
            this.lTituloDadosVeiculo.AutoSize = true;
            this.lTituloDadosVeiculo.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lTituloDadosVeiculo.Location = new System.Drawing.Point(621, 303);
            this.lTituloDadosVeiculo.Name = "lTituloDadosVeiculo";
            this.lTituloDadosVeiculo.Size = new System.Drawing.Size(130, 18);
            this.lTituloDadosVeiculo.TabIndex = 33;
            this.lTituloDadosVeiculo.Text = "Dados do Veículo";
            // 
            // lDadosVeiculo
            // 
            this.lDadosVeiculo.AutoSize = true;
            this.lDadosVeiculo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosVeiculo.Location = new System.Drawing.Point(621, 321);
            this.lDadosVeiculo.Name = "lDadosVeiculo";
            this.lDadosVeiculo.Size = new System.Drawing.Size(173, 17);
            this.lDadosVeiculo.TabIndex = 34;
            this.lDadosVeiculo.Text = "[Veiculos não Selecionados]";
            // 
            // lDadosTaxa
            // 
            this.lDadosTaxa.AutoSize = true;
            this.lDadosTaxa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosTaxa.Location = new System.Drawing.Point(956, 93);
            this.lDadosTaxa.Name = "lDadosTaxa";
            this.lDadosTaxa.Size = new System.Drawing.Size(157, 17);
            this.lDadosTaxa.TabIndex = 36;
            this.lDadosTaxa.Text = "[Taxas não Selecionadas]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(956, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Dados de Taxas";
            // 
            // lDadosLocacao
            // 
            this.lDadosLocacao.AutoSize = true;
            this.lDadosLocacao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosLocacao.Location = new System.Drawing.Point(956, 321);
            this.lDadosLocacao.Name = "lDadosLocacao";
            this.lDadosLocacao.Size = new System.Drawing.Size(189, 17);
            this.lDadosLocacao.TabIndex = 38;
            this.lDadosLocacao.Text = "[Locação ainda não concluida]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(956, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Dados do Locação";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(610, 524);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(584, 5);
            this.panel4.TabIndex = 39;
            // 
            // btnGerarPdf
            // 
            this.btnGerarPdf.Location = new System.Drawing.Point(1046, 597);
            this.btnGerarPdf.Name = "btnGerarPdf";
            this.btnGerarPdf.Size = new System.Drawing.Size(148, 38);
            this.btnGerarPdf.TabIndex = 41;
            this.btnGerarPdf.Text = "Gerar PDF";
            this.btnGerarPdf.UseVisualStyleBackColor = true;
            // 
            // lSubTotal
            // 
            this.lSubTotal.AutoSize = true;
            this.lSubTotal.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lSubTotal.Location = new System.Drawing.Point(621, 545);
            this.lSubTotal.Name = "lSubTotal";
            this.lSubTotal.Size = new System.Drawing.Size(168, 18);
            this.lSubTotal.TabIndex = 42;
            this.lSubTotal.Text = "Sub-Total da Locação: ";
            // 
            // lValor
            // 
            this.lValor.AutoSize = true;
            this.lValor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lValor.Location = new System.Drawing.Point(825, 545);
            this.lValor.Name = "lValor";
            this.lValor.Size = new System.Drawing.Size(32, 17);
            this.lValor.TabIndex = 43;
            this.lValor.Text = "0,00";
            // 
            // lCifrao
            // 
            this.lCifrao.AutoSize = true;
            this.lCifrao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lCifrao.Location = new System.Drawing.Point(796, 545);
            this.lCifrao.Name = "lCifrao";
            this.lCifrao.Size = new System.Drawing.Size(23, 17);
            this.lCifrao.TabIndex = 44;
            this.lCifrao.Text = "R$";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(597, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 567);
            this.panel3.TabIndex = 45;
            // 
            // pictureCarro
            // 
            this.pictureCarro.Location = new System.Drawing.Point(621, 458);
            this.pictureCarro.Name = "pictureCarro";
            this.pictureCarro.Size = new System.Drawing.Size(92, 60);
            this.pictureCarro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCarro.TabIndex = 55;
            this.pictureCarro.TabStop = false;
            // 
            // dataTempoLocacaoBox
            // 
            this.dataTempoLocacaoBox.Location = new System.Drawing.Point(158, 524);
            this.dataTempoLocacaoBox.Name = "dataTempoLocacaoBox";
            this.dataTempoLocacaoBox.Size = new System.Drawing.Size(432, 23);
            this.dataTempoLocacaoBox.TabIndex = 56;
            this.dataTempoLocacaoBox.ValueChanged += new System.EventHandler(this.dataTempoLocacao_ValueChanged);
            // 
            // TelaCadastroLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 641);
            this.Controls.Add(this.dataTempoLocacaoBox);
            this.Controls.Add(this.pictureCarro);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lCifrao);
            this.Controls.Add(this.lValor);
            this.Controls.Add(this.lSubTotal);
            this.Controls.Add(this.btnGerarPdf);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lDadosLocacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lDadosTaxa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lDadosVeiculo);
            this.Controls.Add(this.lTituloDadosVeiculo);
            this.Controls.Add(this.lDadosCliente);
            this.Controls.Add(this.lTituloDadosLocador);
            this.Controls.Add(this.dataLocacaoBox);
            this.Controls.Add(this.txtFuncionario);
            this.Controls.Add(this.cboxTaxa);
            this.Controls.Add(this.cboxPlano);
            this.Controls.Add(this.cboxVeiculo);
            this.Controls.Add(this.cboxAgrupamento);
            this.Controls.Add(this.cboxCondutor);
            this.Controls.Add(this.cboxCliente);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lTempoLocacao);
            this.Controls.Add(this.lDataLocacao);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.listEquipamentos);
            this.Controls.Add(this.lTaxa);
            this.Controls.Add(this.lPlano);
            this.Controls.Add(this.lVeículo);
            this.Controls.Add(this.lAgrupamento);
            this.Controls.Add(this.lCondutor);
            this.Controls.Add(this.lCliente);
            this.Controls.Add(this.lFuncionario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCarro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lFuncionario;
        private System.Windows.Forms.Label lCliente;
        private System.Windows.Forms.Label lCondutor;
        private System.Windows.Forms.Label lAgrupamento;
        private System.Windows.Forms.Label lVeículo;
        private System.Windows.Forms.Label lPlano;
        private System.Windows.Forms.Label lTaxa;
        private System.Windows.Forms.ListBox listEquipamentos;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Label lDataLocacao;
        private System.Windows.Forms.Label lTempoLocacao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ComboBox cboxCliente;
        private System.Windows.Forms.ComboBox cboxCondutor;
        private System.Windows.Forms.ComboBox cboxAgrupamento;
        private System.Windows.Forms.ComboBox cboxVeiculo;
        private System.Windows.Forms.ComboBox cboxPlano;
        private System.Windows.Forms.ComboBox cboxTaxa;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.DateTimePicker dataLocacaoBox;
        private System.Windows.Forms.Label lTituloDadosLocador;
        private System.Windows.Forms.Label lDadosCliente;
        private System.Windows.Forms.Label lTituloDadosVeiculo;
        private System.Windows.Forms.Label lDadosVeiculo;
        private System.Windows.Forms.Label lDadosTaxa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lDadosLocacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGerarPdf;
        private System.Windows.Forms.Label lSubTotal;
        private System.Windows.Forms.Label lValor;
        private System.Windows.Forms.Label lCifrao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureCarro;
        private System.Windows.Forms.DateTimePicker dataTempoLocacaoBox;
    }
}