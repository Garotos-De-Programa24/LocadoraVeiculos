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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtEquipamento = new System.Windows.Forms.TextBox();
            this.lEndereco = new System.Windows.Forms.Label();
            this.lCPFCNPJ = new System.Windows.Forms.Label();
            this.lNome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxDiario = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(435, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(342, 326);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(87, 23);
            this.btnCadastrar.TabIndex = 32;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_1);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(95, 150);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(427, 63);
            this.txtDescricao.TabIndex = 27;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(66, 117);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(456, 23);
            this.txtValor.TabIndex = 26;
            // 
            // txtEquipamento
            // 
            this.txtEquipamento.Location = new System.Drawing.Point(116, 82);
            this.txtEquipamento.Name = "txtEquipamento";
            this.txtEquipamento.Size = new System.Drawing.Size(406, 23);
            this.txtEquipamento.TabIndex = 25;
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEndereco.Location = new System.Drawing.Point(19, 150);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(69, 16);
            this.lEndereco.TabIndex = 20;
            this.lEndereco.Text = "Descrição";
            // 
            // lCPFCNPJ
            // 
            this.lCPFCNPJ.AutoSize = true;
            this.lCPFCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCPFCNPJ.Location = new System.Drawing.Point(19, 117);
            this.lCPFCNPJ.Name = "lCPFCNPJ";
            this.lCPFCNPJ.Size = new System.Drawing.Size(39, 16);
            this.lCPFCNPJ.TabIndex = 19;
            this.lCPFCNPJ.Text = "Valor";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lNome.Location = new System.Drawing.Point(19, 84);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(87, 16);
            this.lNome.TabIndex = 18;
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
            this.lTitulo.TabIndex = 2;
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
            this.checkBoxDiario.Location = new System.Drawing.Point(19, 222);
            this.checkBoxDiario.Name = "checkBoxDiario";
            this.checkBoxDiario.Size = new System.Drawing.Size(110, 20);
            this.checkBoxDiario.TabIndex = 36;
            this.checkBoxDiario.Text = "Calculo Diario";
            this.checkBoxDiario.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.checkBoxDiario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtEquipamento);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lCPFCNPJ);
            this.Controls.Add(this.lNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaCadastroTaxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroTaxa";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtEquipamento;
        private System.Windows.Forms.Label lEndereco;
        private System.Windows.Forms.Label lCPFCNPJ;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxDiario;
    }
}