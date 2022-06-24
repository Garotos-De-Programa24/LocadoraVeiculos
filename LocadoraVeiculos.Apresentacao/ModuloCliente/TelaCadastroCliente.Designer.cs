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
            this.lCPFCNPJ = new System.Windows.Forms.Label();
            this.lEndereco = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCPFCNPJ = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCNHCondutor = new System.Windows.Forms.TextBox();
            this.lCNHCondutor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lValidadeCNH = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.lTelefone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lEmail = new System.Windows.Forms.Label();
            this.dateValidade = new System.Windows.Forms.DateTimePicker();
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
            this.lTitulo.Font = new System.Drawing.Font("Geometr415 Blk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTitulo.ForeColor = System.Drawing.Color.White;
            this.lTitulo.Location = new System.Drawing.Point(13, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(208, 25);
            this.lTitulo.TabIndex = 2;
            this.lTitulo.Text = "Cadastro de Clientes";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lNome.Location = new System.Drawing.Point(19, 84);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(43, 16);
            this.lNome.TabIndex = 2;
            this.lNome.Text = "Nome";
            // 
            // lCPFCNPJ
            // 
            this.lCPFCNPJ.AutoSize = true;
            this.lCPFCNPJ.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCPFCNPJ.Location = new System.Drawing.Point(19, 119);
            this.lCPFCNPJ.Name = "lCPFCNPJ";
            this.lCPFCNPJ.Size = new System.Drawing.Size(75, 16);
            this.lCPFCNPJ.TabIndex = 3;
            this.lCPFCNPJ.Text = "CPF/CNPJ";
            // 
            // lEndereco
            // 
            this.lEndereco.AutoSize = true;
            this.lEndereco.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEndereco.Location = new System.Drawing.Point(19, 152);
            this.lEndereco.Name = "lEndereco";
            this.lEndereco.Size = new System.Drawing.Size(66, 16);
            this.lEndereco.TabIndex = 4;
            this.lEndereco.Text = "Endereço";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(68, 82);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(454, 23);
            this.txtNome.TabIndex = 9;
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.Location = new System.Drawing.Point(100, 117);
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(422, 23);
            this.txtCPFCNPJ.TabIndex = 10;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(91, 150);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(431, 23);
            this.txtEndereco.TabIndex = 11;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(342, 326);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(87, 23);
            this.btnCadastrar.TabIndex = 16;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(435, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtCNHCondutor
            // 
            this.txtCNHCondutor.Location = new System.Drawing.Point(141, 183);
            this.txtCNHCondutor.Name = "txtCNHCondutor";
            this.txtCNHCondutor.Size = new System.Drawing.Size(381, 23);
            this.txtCNHCondutor.TabIndex = 24;
            // 
            // lCNHCondutor
            // 
            this.lCNHCondutor.AutoSize = true;
            this.lCNHCondutor.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCNHCondutor.Location = new System.Drawing.Point(19, 185);
            this.lCNHCondutor.Name = "lCNHCondutor";
            this.lCNHCondutor.Size = new System.Drawing.Size(116, 16);
            this.lCNHCondutor.TabIndex = 23;
            this.lCNHCondutor.Text = "CNH do Condutor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(-1, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 16);
            this.panel1.TabIndex = 0;
            // 
            // lValidadeCNH
            // 
            this.lValidadeCNH.AutoSize = true;
            this.lValidadeCNH.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lValidadeCNH.Location = new System.Drawing.Point(19, 219);
            this.lValidadeCNH.Name = "lValidadeCNH";
            this.lValidadeCNH.Size = new System.Drawing.Size(118, 16);
            this.lValidadeCNH.TabIndex = 25;
            this.lValidadeCNH.Text = "Validade da CNH";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(85, 251);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(437, 23);
            this.txtTelefone.TabIndex = 28;
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTelefone.Location = new System.Drawing.Point(19, 253);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(60, 16);
            this.lTelefone.TabIndex = 27;
            this.lTelefone.Text = "Telefone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(70, 285);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(452, 23);
            this.txtEmail.TabIndex = 30;
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lEmail.Location = new System.Drawing.Point(19, 287);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(45, 16);
            this.lEmail.TabIndex = 29;
            this.lEmail.Text = "Email";
            // 
            // dateValidade
            // 
            this.dateValidade.Location = new System.Drawing.Point(143, 214);
            this.dateValidade.Name = "dateValidade";
            this.dateValidade.Size = new System.Drawing.Size(235, 23);
            this.dateValidade.TabIndex = 31;
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.dateValidade);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.lValidadeCNH);
            this.Controls.Add(this.txtCNHCondutor);
            this.Controls.Add(this.lCNHCondutor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtCPFCNPJ);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lEndereco);
            this.Controls.Add(this.lCPFCNPJ);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "TelaCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroCliente";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Label lCPFCNPJ;
        private System.Windows.Forms.Label lEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPFCNPJ;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtCNHCondutor;
        private System.Windows.Forms.Label lCNHCondutor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lValidadeCNH;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.DateTimePicker dateValidade;
    }
}