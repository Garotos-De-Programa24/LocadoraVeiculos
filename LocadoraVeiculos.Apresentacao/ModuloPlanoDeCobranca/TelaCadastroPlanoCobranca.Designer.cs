namespace LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobrança
{
    partial class TelaCadastroPlanoCobranca
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
            this.lTituloPlano = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lAgrupamento = new System.Windows.Forms.Label();
            this.cmbAgrupamento = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbtnPlanoLivre = new System.Windows.Forms.RadioButton();
            this.rdbtnPlanoDiario = new System.Windows.Forms.RadioButton();
            this.rdbtnPlanoControlado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLimitQuilometragem = new System.Windows.Forms.TextBox();
            this.maskedValorDiario = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedValorPorKm = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 53);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 16);
            this.panel1.TabIndex = 4;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(289, 25);
            this.lTitulo.TabIndex = 9;
            this.lTitulo.Text = "Cadastro Plano de Cobrança";
            // 
            // lTituloPlano
            // 
            this.lTituloPlano.AutoSize = true;
            this.lTituloPlano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTituloPlano.Location = new System.Drawing.Point(4, 61);
            this.lTituloPlano.Name = "lTituloPlano";
            this.lTituloPlano.Size = new System.Drawing.Size(140, 16);
            this.lTituloPlano.TabIndex = 11;
            this.lTituloPlano.Text = "Titulo Plano Cobrança";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(150, 59);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(152, 23);
            this.txtNome.TabIndex = 12;
            // 
            // lAgrupamento
            // 
            this.lAgrupamento.AutoSize = true;
            this.lAgrupamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lAgrupamento.Location = new System.Drawing.Point(26, 90);
            this.lAgrupamento.Name = "lAgrupamento";
            this.lAgrupamento.Size = new System.Drawing.Size(118, 16);
            this.lAgrupamento.TabIndex = 13;
            this.lAgrupamento.Text = "Grupo de Veiculos";
            // 
            // cmbAgrupamento
            // 
            this.cmbAgrupamento.FormattingEnabled = true;
            this.cmbAgrupamento.Location = new System.Drawing.Point(150, 88);
            this.cmbAgrupamento.Name = "cmbAgrupamento";
            this.cmbAgrupamento.Size = new System.Drawing.Size(121, 23);
            this.cmbAgrupamento.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(6, 202);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 10);
            this.panel3.TabIndex = 5;
            // 
            // rdbtnPlanoLivre
            // 
            this.rdbtnPlanoLivre.AutoSize = true;
            this.rdbtnPlanoLivre.Location = new System.Drawing.Point(150, 127);
            this.rdbtnPlanoLivre.Name = "rdbtnPlanoLivre";
            this.rdbtnPlanoLivre.Size = new System.Drawing.Size(83, 19);
            this.rdbtnPlanoLivre.TabIndex = 15;
            this.rdbtnPlanoLivre.TabStop = true;
            this.rdbtnPlanoLivre.Text = "Plano Livre";
            this.rdbtnPlanoLivre.UseVisualStyleBackColor = true;
            this.rdbtnPlanoLivre.CheckedChanged += new System.EventHandler(this.rdbtnPlanos_CheckedChanged);
            // 
            // rdbtnPlanoDiario
            // 
            this.rdbtnPlanoDiario.AutoSize = true;
            this.rdbtnPlanoDiario.Location = new System.Drawing.Point(150, 152);
            this.rdbtnPlanoDiario.Name = "rdbtnPlanoDiario";
            this.rdbtnPlanoDiario.Size = new System.Drawing.Size(89, 19);
            this.rdbtnPlanoDiario.TabIndex = 16;
            this.rdbtnPlanoDiario.TabStop = true;
            this.rdbtnPlanoDiario.Text = "Plano Diario";
            this.rdbtnPlanoDiario.UseVisualStyleBackColor = true;
            this.rdbtnPlanoDiario.CheckedChanged += new System.EventHandler(this.rdbtnPlanos_CheckedChanged);
            // 
            // rdbtnPlanoControlado
            // 
            this.rdbtnPlanoControlado.AutoSize = true;
            this.rdbtnPlanoControlado.Location = new System.Drawing.Point(150, 177);
            this.rdbtnPlanoControlado.Name = "rdbtnPlanoControlado";
            this.rdbtnPlanoControlado.Size = new System.Drawing.Size(118, 19);
            this.rdbtnPlanoControlado.TabIndex = 17;
            this.rdbtnPlanoControlado.TabStop = true;
            this.rdbtnPlanoControlado.Text = "Plano Controlado";
            this.rdbtnPlanoControlado.UseVisualStyleBackColor = true;
            this.rdbtnPlanoControlado.CheckedChanged += new System.EventHandler(this.rdbtnPlanos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(120, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Valor Diário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(114, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Valor por Km";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(39, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Limite de Quilometragem ";
            // 
            // txtLimitQuilometragem
            // 
            this.txtLimitQuilometragem.Location = new System.Drawing.Point(204, 289);
            this.txtLimitQuilometragem.Name = "txtLimitQuilometragem";
            this.txtLimitQuilometragem.Size = new System.Drawing.Size(76, 23);
            this.txtLimitQuilometragem.TabIndex = 21;
            // 
            // maskedValorDiario
            // 
            this.maskedValorDiario.Location = new System.Drawing.Point(204, 230);
            this.maskedValorDiario.Mask = "000000";
            this.maskedValorDiario.Name = "maskedValorDiario";
            this.maskedValorDiario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedValorDiario.Size = new System.Drawing.Size(76, 23);
            this.maskedValorDiario.TabIndex = 22;
            this.maskedValorDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedValorDiario.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(213, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "R$";
            // 
            // maskedValorPorKm
            // 
            this.maskedValorPorKm.Location = new System.Drawing.Point(204, 259);
            this.maskedValorPorKm.Mask = "000000";
            this.maskedValorPorKm.Name = "maskedValorPorKm";
            this.maskedValorPorKm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedValorPorKm.Size = new System.Drawing.Size(76, 23);
            this.maskedValorPorKm.TabIndex = 39;
            this.maskedValorPorKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedValorPorKm.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(213, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "R$";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(215, 338);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(87, 23);
            this.btnCadastrar.TabIndex = 41;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(308, 338);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroPlanoCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 373);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedValorPorKm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedValorDiario);
            this.Controls.Add(this.txtLimitQuilometragem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbtnPlanoControlado);
            this.Controls.Add(this.rdbtnPlanoDiario);
            this.Controls.Add(this.rdbtnPlanoLivre);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cmbAgrupamento);
            this.Controls.Add(this.lAgrupamento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lTituloPlano);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroPlanoCobranca";
            this.ShowIcon = false;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lTituloPlano;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lAgrupamento;
        private System.Windows.Forms.ComboBox cmbAgrupamento;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbtnPlanoLivre;
        private System.Windows.Forms.RadioButton rdbtnPlanoDiario;
        private System.Windows.Forms.RadioButton rdbtnPlanoControlado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLimitQuilometragem;
        private System.Windows.Forms.MaskedTextBox maskedValorDiario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedValorPorKm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
    }
}