namespace LocadoraVeiculos.Apresentacao.ModuloDevolucao
{
    partial class TelaCadastroDevolucao
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.btnDevolucao = new System.Windows.Forms.Button();
            this.lValorContrato = new System.Windows.Forms.Label();
            this.lTituloDadosLocador = new System.Windows.Forms.Label();
            this.lDadosCliente = new System.Windows.Forms.Label();
            this.lTituloDadosVeiculo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lDadosVeiculo = new System.Windows.Forms.Label();
            this.lDadosLocacao = new System.Windows.Forms.Label();
            this.lSubTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lOservacoes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lValorFinal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureCarro = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCarro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(-3, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 65);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(3, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1207, 13);
            this.panel1.TabIndex = 10;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(232, 25);
            this.lTitulo.TabIndex = 9;
            this.lTitulo.Text = "Devolução de Veículos";
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDevolucao.Location = new System.Drawing.Point(1046, 553);
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Size = new System.Drawing.Size(148, 38);
            this.btnDevolucao.TabIndex = 37;
            this.btnDevolucao.Text = "Executar Devolução";
            this.btnDevolucao.UseVisualStyleBackColor = true;
            this.btnDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click);
            // 
            // lValorContrato
            // 
            this.lValorContrato.AutoSize = true;
            this.lValorContrato.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lValorContrato.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lValorContrato.Location = new System.Drawing.Point(186, 574);
            this.lValorContrato.Name = "lValorContrato";
            this.lValorContrato.Size = new System.Drawing.Size(100, 17);
            this.lValorContrato.TabIndex = 42;
            this.lValorContrato.Text = "[ValorContrato]";
            // 
            // lTituloDadosLocador
            // 
            this.lTituloDadosLocador.AutoSize = true;
            this.lTituloDadosLocador.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lTituloDadosLocador.Location = new System.Drawing.Point(10, 76);
            this.lTituloDadosLocador.Name = "lTituloDadosLocador";
            this.lTituloDadosLocador.Size = new System.Drawing.Size(130, 18);
            this.lTituloDadosLocador.TabIndex = 47;
            this.lTituloDadosLocador.Text = "Dados do Cliente";
            // 
            // lDadosCliente
            // 
            this.lDadosCliente.AutoSize = true;
            this.lDadosCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosCliente.Location = new System.Drawing.Point(10, 106);
            this.lDadosCliente.Name = "lDadosCliente";
            this.lDadosCliente.Size = new System.Drawing.Size(160, 17);
            this.lDadosCliente.TabIndex = 48;
            this.lDadosCliente.Text = "[Cliente não Selecionado]";
            // 
            // lTituloDadosVeiculo
            // 
            this.lTituloDadosVeiculo.AutoSize = true;
            this.lTituloDadosVeiculo.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lTituloDadosVeiculo.Location = new System.Drawing.Point(333, 76);
            this.lTituloDadosVeiculo.Name = "lTituloDadosVeiculo";
            this.lTituloDadosVeiculo.Size = new System.Drawing.Size(130, 18);
            this.lTituloDadosVeiculo.TabIndex = 49;
            this.lTituloDadosVeiculo.Text = "Dados do Veículo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(635, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 18);
            this.label4.TabIndex = 50;
            this.label4.Text = "Dados do Locação";
            // 
            // lDadosVeiculo
            // 
            this.lDadosVeiculo.AutoSize = true;
            this.lDadosVeiculo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosVeiculo.Location = new System.Drawing.Point(333, 106);
            this.lDadosVeiculo.Name = "lDadosVeiculo";
            this.lDadosVeiculo.Size = new System.Drawing.Size(173, 17);
            this.lDadosVeiculo.TabIndex = 51;
            this.lDadosVeiculo.Text = "[Veiculos não Selecionados]";
            // 
            // lDadosLocacao
            // 
            this.lDadosLocacao.AutoSize = true;
            this.lDadosLocacao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lDadosLocacao.Location = new System.Drawing.Point(638, 106);
            this.lDadosLocacao.Name = "lDadosLocacao";
            this.lDadosLocacao.Size = new System.Drawing.Size(189, 17);
            this.lDadosLocacao.TabIndex = 52;
            this.lDadosLocacao.Text = "[Locação ainda não concluida]";
            // 
            // lSubTotal
            // 
            this.lSubTotal.AutoSize = true;
            this.lSubTotal.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lSubTotal.Location = new System.Drawing.Point(12, 574);
            this.lSubTotal.Name = "lSubTotal";
            this.lSubTotal.Size = new System.Drawing.Size(168, 18);
            this.lSubTotal.TabIndex = 53;
            this.lSubTotal.Text = "Sub-Total da Locação: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(911, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = "Observações";
            // 
            // lOservacoes
            // 
            this.lOservacoes.AutoSize = true;
            this.lOservacoes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lOservacoes.ForeColor = System.Drawing.Color.DarkOrange;
            this.lOservacoes.Location = new System.Drawing.Point(913, 106);
            this.lOservacoes.Name = "lOservacoes";
            this.lOservacoes.Size = new System.Drawing.Size(94, 17);
            this.lOservacoes.TabIndex = 55;
            this.lOservacoes.Text = "[Observações]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(321, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 18);
            this.label2.TabIndex = 56;
            this.label2.Text = "Valor Final da Locaação:";
            // 
            // lValorFinal
            // 
            this.lValorFinal.AutoSize = true;
            this.lValorFinal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lValorFinal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lValorFinal.Location = new System.Drawing.Point(495, 575);
            this.lValorFinal.Name = "lValorFinal";
            this.lValorFinal.Size = new System.Drawing.Size(74, 17);
            this.lValorFinal.TabIndex = 57;
            this.lValorFinal.Text = "[ValorFinal]";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(1046, 597);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(148, 38);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "Cancelar Locação";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(12, 522);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1180, 10);
            this.panel4.TabIndex = 59;
            // 
            // pictureCarro
            // 
            this.pictureCarro.Location = new System.Drawing.Point(333, 272);
            this.pictureCarro.Name = "pictureCarro";
            this.pictureCarro.Size = new System.Drawing.Size(92, 60);
            this.pictureCarro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCarro.TabIndex = 60;
            this.pictureCarro.TabStop = false;
            // 
            // TelaCadastroDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 641);
            this.Controls.Add(this.pictureCarro);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lValorFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lOservacoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lSubTotal);
            this.Controls.Add(this.lDadosLocacao);
            this.Controls.Add(this.lDadosVeiculo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lTituloDadosVeiculo);
            this.Controls.Add(this.lDadosCliente);
            this.Controls.Add(this.lTituloDadosLocador);
            this.Controls.Add(this.lValorContrato);
            this.Controls.Add(this.btnDevolucao);
            this.Controls.Add(this.panel2);
            this.Name = "TelaCadastroDevolucao";
            this.Text = "TelaCadastroDevolucao";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCarro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDevolucao;
        private System.Windows.Forms.Label lValorContrato;
        private System.Windows.Forms.Label lTituloDadosLocador;
        private System.Windows.Forms.Label lDadosCliente;
        private System.Windows.Forms.Label lTituloDadosVeiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lDadosVeiculo;
        private System.Windows.Forms.Label lDadosLocacao;
        private System.Windows.Forms.Label lSubTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lOservacoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lValorFinal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureCarro;
    }
}