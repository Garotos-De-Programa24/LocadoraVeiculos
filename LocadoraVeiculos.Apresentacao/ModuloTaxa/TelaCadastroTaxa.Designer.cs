namespace LocadoraVeiculos.Apresentacao.ModuloTaxa
{
    partial class TelaCadastroTaxa
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtEquipamento = new System.Windows.Forms.TextBox();
            this.lNome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxDiario = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.lValor = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(435, 187);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(342, 187);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(87, 23);
            this.btnCadastrar.TabIndex = 5;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_1);
            // 
            // txtEquipamento
            // 
            this.txtEquipamento.Location = new System.Drawing.Point(112, 82);
            this.txtEquipamento.Name = "txtEquipamento";
            this.txtEquipamento.Size = new System.Drawing.Size(410, 23);
            this.txtEquipamento.TabIndex = 1;
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lNome.Location = new System.Drawing.Point(19, 84);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(87, 16);
            this.lNome.TabIndex = 7;
            this.lNome.Text = "Equipamento";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 53);
            this.panel2.TabIndex = 34;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(194, 25);
            this.lTitulo.TabIndex = 10;
            this.lTitulo.Text = "Cadastro de Taxas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 16);
            this.panel1.TabIndex = 35;
            // 
            // checkBoxDiario
            // 
            this.checkBoxDiario.AutoSize = true;
            this.checkBoxDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxDiario.Location = new System.Drawing.Point(116, 144);
            this.checkBoxDiario.Name = "checkBoxDiario";
            this.checkBoxDiario.Size = new System.Drawing.Size(110, 20);
            this.checkBoxDiario.TabIndex = 4;
            this.checkBoxDiario.Text = "Calculo Diario";
            this.checkBoxDiario.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(115, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "R$";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(112, 113);
            this.txtValor.Mask = "000000";
            this.txtValor.Name = "txtValor";
            this.txtValor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValor.Size = new System.Drawing.Size(63, 23);
            this.txtValor.TabIndex = 2;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.ValidatingType = typeof(int);
            // 
            // lValor
            // 
            this.lValor.AutoSize = true;
            this.lValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lValor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lValor.Location = new System.Drawing.Point(67, 118);
            this.lValor.Name = "lValor";
            this.lValor.Size = new System.Drawing.Size(39, 16);
            this.lValor.TabIndex = 8;
            this.lValor.Text = "Valor";
            // 
            // TelaCadastroTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 222);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lValor);
            this.Controls.Add(this.checkBoxDiario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtEquipamento);
            this.Controls.Add(this.lNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroTaxa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtEquipamento;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxDiario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtValor;
        private System.Windows.Forms.Label lValor;
    }
}