namespace LocadoraVeiculos.Apresentacao.ModuloCondutor
{
    partial class TelaCadastroCondutor
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
            this.MaskedCNHCondutor = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.dateValidade = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lEmail = new System.Windows.Forms.Label();
            this.lTelefone = new System.Windows.Forms.Label();
            this.lValidadeCNH = new System.Windows.Forms.Label();
            this.lCNHCondutor = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lEndereco = new System.Windows.Forms.Label();
            this.lCPF = new System.Windows.Forms.Label();
            this.lNome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.lCliente = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MaskedCNHCondutor
            // 
            this.MaskedCNHCondutor.Location = new System.Drawing.Point(135, 197);
            this.MaskedCNHCondutor.Mask = "00000000000";
            this.MaskedCNHCondutor.Name = "MaskedCNHCondutor";
            this.MaskedCNHCondutor.Size = new System.Drawing.Size(96, 23);
            this.MaskedCNHCondutor.TabIndex = 27;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(135, 263);
            this.txtTelefone.Mask = "(000)00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(96, 23);
            this.txtTelefone.TabIndex = 29;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(135, 131);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(96, 23);
            this.txtCPF.TabIndex = 25;
            // 
            // dateValidade
            // 
            this.dateValidade.Location = new System.Drawing.Point(135, 230);
            this.dateValidade.Name = "dateValidade";
            this.dateValidade.Size = new System.Drawing.Size(235, 23);
            this.dateValidade.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(135, 296);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(388, 23);
            this.txtEmail.TabIndex = 30;
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEmail.Location = new System.Drawing.Point(79, 298);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(50, 16);
            this.lEmail.TabIndex = 23;
            this.lEmail.Text = "E-mail";
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTelefone.Location = new System.Drawing.Point(69, 265);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(60, 16);
            this.lTelefone.TabIndex = 22;
            this.lTelefone.Text = "Telefone";
            // 
            // lValidadeCNH
            // 
            this.lValidadeCNH.AutoSize = true;
            this.lValidadeCNH.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lValidadeCNH.Location = new System.Drawing.Point(11, 235);
            this.lValidadeCNH.Name = "lValidadeCNH";
            this.lValidadeCNH.Size = new System.Drawing.Size(118, 16);
            this.lValidadeCNH.TabIndex = 21;
            this.lValidadeCNH.Text = "Validade da CNH";
            // 
            // lCNHCondutor
            // 
            this.lCNHCondutor.AutoSize = true;
            this.lCNHCondutor.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCNHCondutor.Location = new System.Drawing.Point(13, 199);
            this.lCNHCondutor.Name = "lCNHCondutor";
            this.lCNHCondutor.Size = new System.Drawing.Size(116, 16);
            this.lCNHCondutor.TabIndex = 20;
            this.lCNHCondutor.Text = "CNH do Condutor";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(436, 340);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(343, 340);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(87, 23);
            this.btnCadastrar.TabIndex = 31;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(135, 164);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(388, 23);
            this.txtEndereco.TabIndex = 26;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(135, 98);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(388, 23);
            this.txtNome.TabIndex = 24;
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEndereco.Location = new System.Drawing.Point(63, 166);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(66, 16);
            this.lEndereco.TabIndex = 19;
            this.lEndereco.Text = "Endereço";
            // 
            // lCPF
            // 
            this.lCPF.AutoSize = true;
            this.lCPF.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCPF.Location = new System.Drawing.Point(94, 133);
            this.lCPF.Name = "lCPF";
            this.lCPF.Size = new System.Drawing.Size(35, 16);
            this.lCPF.TabIndex = 18;
            this.lCPF.Text = "CPF";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lNome.Location = new System.Drawing.Point(86, 100);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(43, 16);
            this.lNome.TabIndex = 17;
            this.lNome.Text = "Nome";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 16);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(0, -5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 53);
            this.panel2.TabIndex = 34;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lTitulo.Font = new System.Drawing.Font("Geometr415 Blk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(239, 25);
            this.lTitulo.TabIndex = 2;
            this.lTitulo.Text = "Cadastro de Condutores";
            // 
            // lCliente
            // 
            this.lCliente.AutoSize = true;
            this.lCliente.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCliente.Location = new System.Drawing.Point(79, 69);
            this.lCliente.Name = "lCliente";
            this.lCliente.Size = new System.Drawing.Size(50, 16);
            this.lCliente.TabIndex = 35;
            this.lCliente.Text = "Cliente";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(135, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(235, 23);
            this.comboBox2.TabIndex = 37;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(376, 68);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(135, 19);
            this.radioButton1.TabIndex = 38;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Cliente é o Condutor";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroCondutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 375);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lCliente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MaskedCNHCondutor);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.dateValidade);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.lValidadeCNH);
            this.Controls.Add(this.lCNHCondutor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lCPF);
            this.Controls.Add(this.lNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroCondutor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox MaskedCNHCondutor;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.DateTimePicker dateValidade;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lTelefone;
        private System.Windows.Forms.Label lValidadeCNH;
        private System.Windows.Forms.Label lCNHCondutor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lEndereco;
        private System.Windows.Forms.Label lCPF;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lCliente;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}