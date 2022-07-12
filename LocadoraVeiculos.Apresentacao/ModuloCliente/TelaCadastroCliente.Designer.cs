namespace LocadoraVeiculos.Apresentacao.ModuloCliente
{
    partial class TelaCadastroCliente
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
            this.lTitulo = new System.Windows.Forms.Label();
            this.lNome = new System.Windows.Forms.Label();
            this.lCPF = new System.Windows.Forms.Label();
            this.lEndereco = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lTelefone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lEmail = new System.Windows.Forms.Label();
            this.txtMaskCPFCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxCNPJ = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 53);
            this.panel2.TabIndex = 1;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(213, 25);
            this.lTitulo.TabIndex = 0;
            this.lTitulo.Text = "Cadastro de Clientes";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lNome.Location = new System.Drawing.Point(47, 76);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(44, 16);
            this.lNome.TabIndex = 1;
            this.lNome.Text = "Nome";
            // 
            // lCPF
            // 
            this.lCPF.AutoSize = true;
            this.lCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCPF.Location = new System.Drawing.Point(15, 109);
            this.lCPF.Name = "lCPF";
            this.lCPF.Size = new System.Drawing.Size(72, 16);
            this.lCPF.TabIndex = 2;
            this.lCPF.Text = "CPF/CNPJ";
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEndereco.Location = new System.Drawing.Point(24, 142);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(66, 16);
            this.lEndereco.TabIndex = 3;
            this.lEndereco.Text = "Endereço";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(96, 74);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(269, 23);
            this.txtNome.TabIndex = 8;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(96, 140);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(269, 23);
            this.txtEndereco.TabIndex = 10;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(302, 326);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(87, 23);
            this.btnCadastrar.TabIndex = 15;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(395, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(-1, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 16);
            this.panel1.TabIndex = 0;
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTelefone.Location = new System.Drawing.Point(30, 175);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(61, 16);
            this.lTelefone.TabIndex = 6;
            this.lTelefone.Text = "Telefone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 206);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(269, 23);
            this.txtEmail.TabIndex = 14;
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEmail.Location = new System.Drawing.Point(40, 208);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(45, 16);
            this.lEmail.TabIndex = 7;
            this.lEmail.Text = "E-mail";
            // 
            // txtMaskCPFCNPJ
            // 
            this.txtMaskCPFCNPJ.Location = new System.Drawing.Point(96, 107);
            this.txtMaskCPFCNPJ.Mask = "000.000.000-00";
            this.txtMaskCPFCNPJ.Name = "txtMaskCPFCNPJ";
            this.txtMaskCPFCNPJ.Size = new System.Drawing.Size(108, 23);
            this.txtMaskCPFCNPJ.TabIndex = 9;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(96, 173);
            this.txtTelefone.Mask = "(000)00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(108, 23);
            this.txtTelefone.TabIndex = 13;
            // 
            // checkBoxCNPJ
            // 
            this.checkBoxCNPJ.AutoSize = true;
            this.checkBoxCNPJ.Location = new System.Drawing.Point(210, 109);
            this.checkBoxCNPJ.Name = "checkBoxCNPJ";
            this.checkBoxCNPJ.Size = new System.Drawing.Size(106, 19);
            this.checkBoxCNPJ.TabIndex = 18;
            this.checkBoxCNPJ.Text = "Cadastrar CNPJ";
            this.checkBoxCNPJ.UseVisualStyleBackColor = true;
            this.checkBoxCNPJ.CheckedChanged += new System.EventHandler(this.checkBoxCNPJ_CheckedChanged);
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 361);
            this.Controls.Add(this.checkBoxCNPJ);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtMaskCPFCNPJ);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lCPF);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Label lCPF;
        private System.Windows.Forms.Label lEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.MaskedTextBox txtMaskCPFCNPJ;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.CheckBox checkBoxCNPJ;
    }
}