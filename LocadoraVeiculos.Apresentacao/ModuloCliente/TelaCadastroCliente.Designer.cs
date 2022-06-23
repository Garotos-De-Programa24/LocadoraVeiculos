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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.lVeiculo = new System.Windows.Forms.Label();
            this.lMarca = new System.Windows.Forms.Label();
            this.lPlaca = new System.Windows.Forms.Label();
            this.lTipoCombustivel = new System.Windows.Forms.Label();
            this.lCor = new System.Windows.Forms.Label();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cBoxCombustivel = new System.Windows.Forms.ComboBox();
            this.cBoxCor = new System.Windows.Forms.ComboBox();
            this.lAddCor = new System.Windows.Forms.Label();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.btnAddCor = new System.Windows.Forms.Button();
            this.txtCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.lCapacidadeTanque = new System.Windows.Forms.Label();
            this.lAno = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.lKmPercorrida = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(-1, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 16);
            this.panel1.TabIndex = 0;
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
            this.lTitulo.Size = new System.Drawing.Size(210, 25);
            this.lTitulo.TabIndex = 2;
            this.lTitulo.Text = "Cadastro de Veículos";
            // 
            // lVeiculo
            // 
            this.lVeiculo.AutoSize = true;
            this.lVeiculo.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lVeiculo.Location = new System.Drawing.Point(19, 84);
            this.lVeiculo.Name = "lVeiculo";
            this.lVeiculo.Size = new System.Drawing.Size(54, 16);
            this.lVeiculo.TabIndex = 2;
            this.lVeiculo.Text = "Veículo";
            // 
            // lMarca
            // 
            this.lMarca.AutoSize = true;
            this.lMarca.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lMarca.Location = new System.Drawing.Point(19, 119);
            this.lMarca.Name = "lMarca";
            this.lMarca.Size = new System.Drawing.Size(48, 16);
            this.lMarca.TabIndex = 3;
            this.lMarca.Text = "Marca";
            // 
            // lPlaca
            // 
            this.lPlaca.AutoSize = true;
            this.lPlaca.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lPlaca.Location = new System.Drawing.Point(19, 152);
            this.lPlaca.Name = "lPlaca";
            this.lPlaca.Size = new System.Drawing.Size(44, 16);
            this.lPlaca.TabIndex = 4;
            this.lPlaca.Text = "Placa";
            // 
            // lTipoCombustivel
            // 
            this.lTipoCombustivel.AutoSize = true;
            this.lTipoCombustivel.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTipoCombustivel.Location = new System.Drawing.Point(19, 248);
            this.lTipoCombustivel.Name = "lTipoCombustivel";
            this.lTipoCombustivel.Size = new System.Drawing.Size(133, 16);
            this.lTipoCombustivel.TabIndex = 5;
            this.lTipoCombustivel.Text = "Tipo de combustível";
            // 
            // lCor
            // 
            this.lCor.AutoSize = true;
            this.lCor.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCor.Location = new System.Drawing.Point(19, 281);
            this.lCor.Name = "lCor";
            this.lCor.Size = new System.Drawing.Size(28, 16);
            this.lCor.TabIndex = 6;
            this.lCor.Text = "Cor";
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Location = new System.Drawing.Point(79, 82);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(252, 23);
            this.txtVeiculo.TabIndex = 9;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(73, 117);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(449, 23);
            this.txtMarca.TabIndex = 10;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(69, 150);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(453, 23);
            this.txtPlaca.TabIndex = 11;
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
            // cBoxCombustivel
            // 
            this.cBoxCombustivel.FormattingEnabled = true;
            this.cBoxCombustivel.Location = new System.Drawing.Point(158, 246);
            this.cBoxCombustivel.Name = "cBoxCombustivel";
            this.cBoxCombustivel.Size = new System.Drawing.Size(173, 23);
            this.cBoxCombustivel.TabIndex = 18;
            // 
            // cBoxCor
            // 
            this.cBoxCor.FormattingEnabled = true;
            this.cBoxCor.Location = new System.Drawing.Point(53, 279);
            this.cBoxCor.Name = "cBoxCor";
            this.cBoxCor.Size = new System.Drawing.Size(169, 23);
            this.cBoxCor.TabIndex = 19;
            // 
            // lAddCor
            // 
            this.lAddCor.AutoSize = true;
            this.lAddCor.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lAddCor.Location = new System.Drawing.Point(238, 281);
            this.lAddCor.Name = "lAddCor";
            this.lAddCor.Size = new System.Drawing.Size(93, 16);
            this.lAddCor.TabIndex = 20;
            this.lAddCor.Text = "Adicionar Cor";
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(337, 279);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(116, 23);
            this.txtCor.TabIndex = 21;
            // 
            // btnAddCor
            // 
            this.btnAddCor.Location = new System.Drawing.Point(459, 279);
            this.btnAddCor.Name = "btnAddCor";
            this.btnAddCor.Size = new System.Drawing.Size(63, 23);
            this.btnAddCor.TabIndex = 22;
            this.btnAddCor.Text = "Add";
            this.btnAddCor.UseVisualStyleBackColor = true;
            // 
            // txtCapacidadeTanque
            // 
            this.txtCapacidadeTanque.Location = new System.Drawing.Point(178, 183);
            this.txtCapacidadeTanque.Name = "txtCapacidadeTanque";
            this.txtCapacidadeTanque.Size = new System.Drawing.Size(344, 23);
            this.txtCapacidadeTanque.TabIndex = 24;
            // 
            // lCapacidadeTanque
            // 
            this.lCapacidadeTanque.AutoSize = true;
            this.lCapacidadeTanque.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lCapacidadeTanque.Location = new System.Drawing.Point(19, 185);
            this.lCapacidadeTanque.Name = "lCapacidadeTanque";
            this.lCapacidadeTanque.Size = new System.Drawing.Size(153, 16);
            this.lCapacidadeTanque.TabIndex = 23;
            this.lCapacidadeTanque.Text = "Capacidade do Tanque";
            // 
            // lAno
            // 
            this.lAno.AutoSize = true;
            this.lAno.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lAno.Location = new System.Drawing.Point(368, 84);
            this.lAno.Name = "lAno";
            this.lAno.Size = new System.Drawing.Size(32, 16);
            this.lAno.TabIndex = 25;
            this.lAno.Text = "Ano";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(406, 82);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(116, 23);
            this.txtAno.TabIndex = 26;
            // 
            // lKmPercorrida
            // 
            this.lKmPercorrida.AutoSize = true;
            this.lKmPercorrida.Font = new System.Drawing.Font("Geometr212 BkCn BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lKmPercorrida.Location = new System.Drawing.Point(19, 216);
            this.lKmPercorrida.Name = "lKmPercorrida";
            this.lKmPercorrida.Size = new System.Drawing.Size(105, 16);
            this.lKmPercorrida.TabIndex = 27;
            this.lKmPercorrida.Text = "Km Percorridos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 214);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 23);
            this.textBox1.TabIndex = 28;
            // 
            // TelaCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lKmPercorrida);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.lAno);
            this.Controls.Add(this.txtCapacidadeTanque);
            this.Controls.Add(this.lCapacidadeTanque);
            this.Controls.Add(this.btnAddCor);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.lAddCor);
            this.Controls.Add(this.cBoxCor);
            this.Controls.Add(this.cBoxCombustivel);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtVeiculo);
            this.Controls.Add(this.lCor);
            this.Controls.Add(this.lTipoCombustivel);
            this.Controls.Add(this.lPlaca);
            this.Controls.Add(this.lMarca);
            this.Controls.Add(this.lVeiculo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "TelaCadastroCliente";
            this.Text = "TelaCadastroCliente";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lVeiculo;
        private System.Windows.Forms.Label lMarca;
        private System.Windows.Forms.Label lPlaca;
        private System.Windows.Forms.Label lTipoCombustivel;
        private System.Windows.Forms.Label lCor;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cBoxCombustivel;
        private System.Windows.Forms.ComboBox cBoxCor;
        private System.Windows.Forms.Label lAddCor;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Button btnAddCor;
        private System.Windows.Forms.TextBox txtCapacidadeTanque;
        private System.Windows.Forms.Label lCapacidadeTanque;
        private System.Windows.Forms.Label lAno;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label lKmPercorrida;
        private System.Windows.Forms.TextBox textBox1;
    }
}