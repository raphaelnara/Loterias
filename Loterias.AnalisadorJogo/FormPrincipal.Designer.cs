namespace Loterias.AnalisadorJogo
{
    partial class FormPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbUmJogo = new System.Windows.Forms.RadioButton();
            this.rbConjuntoJogos = new System.Windows.Forms.RadioButton();
            this.openFileDialogJogos = new System.Windows.Forms.OpenFileDialog();
            this.txtJogo = new System.Windows.Forms.TextBox();
            this.btnAbrirArquivoJogos = new System.Windows.Forms.Button();
            this.lblDescricaoJogo = new System.Windows.Forms.Label();
            this.btnAnalisar = new System.Windows.Forms.Button();
            this.cbTipoDeJogo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTamanhoBloco = new System.Windows.Forms.ComboBox();
            this.btnArquivoHistorico = new System.Windows.Forms.Button();
            this.txtArquivoHistorico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialogHistorico = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analisar:";
            // 
            // rbUmJogo
            // 
            this.rbUmJogo.AutoSize = true;
            this.rbUmJogo.Checked = true;
            this.rbUmJogo.Location = new System.Drawing.Point(73, 26);
            this.rbUmJogo.Name = "rbUmJogo";
            this.rbUmJogo.Size = new System.Drawing.Size(64, 17);
            this.rbUmJogo.TabIndex = 1;
            this.rbUmJogo.TabStop = true;
            this.rbUmJogo.Text = "Um jogo";
            this.rbUmJogo.UseVisualStyleBackColor = true;
            this.rbUmJogo.CheckedChanged += new System.EventHandler(this.rbUmJogo_CheckedChanged);
            // 
            // rbConjuntoJogos
            // 
            this.rbConjuntoJogos.AutoSize = true;
            this.rbConjuntoJogos.Location = new System.Drawing.Point(144, 26);
            this.rbConjuntoJogos.Name = "rbConjuntoJogos";
            this.rbConjuntoJogos.Size = new System.Drawing.Size(110, 17);
            this.rbConjuntoJogos.TabIndex = 2;
            this.rbConjuntoJogos.Text = "Conjunto de jogos";
            this.rbConjuntoJogos.UseVisualStyleBackColor = true;
            this.rbConjuntoJogos.CheckedChanged += new System.EventHandler(this.rbConjuntoJogos_CheckedChanged);
            // 
            // txtJogo
            // 
            this.txtJogo.Location = new System.Drawing.Point(23, 84);
            this.txtJogo.Name = "txtJogo";
            this.txtJogo.Size = new System.Drawing.Size(642, 20);
            this.txtJogo.TabIndex = 3;
            // 
            // btnAbrirArquivoJogos
            // 
            this.btnAbrirArquivoJogos.Location = new System.Drawing.Point(671, 81);
            this.btnAbrirArquivoJogos.Name = "btnAbrirArquivoJogos";
            this.btnAbrirArquivoJogos.Size = new System.Drawing.Size(113, 23);
            this.btnAbrirArquivoJogos.TabIndex = 4;
            this.btnAbrirArquivoJogos.Text = "Escolher arquivo...";
            this.btnAbrirArquivoJogos.UseVisualStyleBackColor = true;
            this.btnAbrirArquivoJogos.Click += new System.EventHandler(this.btnAbrirArquivoJogos_Click);
            // 
            // lblDescricaoJogo
            // 
            this.lblDescricaoJogo.AutoSize = true;
            this.lblDescricaoJogo.Location = new System.Drawing.Point(23, 68);
            this.lblDescricaoJogo.Name = "lblDescricaoJogo";
            this.lblDescricaoJogo.Size = new System.Drawing.Size(35, 13);
            this.lblDescricaoJogo.TabIndex = 5;
            this.lblDescricaoJogo.Text = "label2";
            // 
            // btnAnalisar
            // 
            this.btnAnalisar.Location = new System.Drawing.Point(647, 397);
            this.btnAnalisar.Name = "btnAnalisar";
            this.btnAnalisar.Size = new System.Drawing.Size(137, 23);
            this.btnAnalisar.TabIndex = 1;
            this.btnAnalisar.Text = "Analisar";
            this.btnAnalisar.UseVisualStyleBackColor = true;
            this.btnAnalisar.Click += new System.EventHandler(this.btnAnalisar_Click);
            // 
            // cbTipoDeJogo
            // 
            this.cbTipoDeJogo.FormattingEnabled = true;
            this.cbTipoDeJogo.Items.AddRange(new object[] {
            "Lotofácil",
            "Lotomania"});
            this.cbTipoDeJogo.Location = new System.Drawing.Point(23, 151);
            this.cbTipoDeJogo.Name = "cbTipoDeJogo";
            this.cbTipoDeJogo.Size = new System.Drawing.Size(167, 21);
            this.cbTipoDeJogo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tipo de jogo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tamanho dos blocos de análise";
            // 
            // cbTamanhoBloco
            // 
            this.cbTamanhoBloco.FormattingEnabled = true;
            this.cbTamanhoBloco.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "50"});
            this.cbTamanhoBloco.Location = new System.Drawing.Point(23, 212);
            this.cbTamanhoBloco.Name = "cbTamanhoBloco";
            this.cbTamanhoBloco.Size = new System.Drawing.Size(66, 21);
            this.cbTamanhoBloco.TabIndex = 8;
            // 
            // btnArquivoHistorico
            // 
            this.btnArquivoHistorico.Location = new System.Drawing.Point(671, 285);
            this.btnArquivoHistorico.Name = "btnArquivoHistorico";
            this.btnArquivoHistorico.Size = new System.Drawing.Size(113, 23);
            this.btnArquivoHistorico.TabIndex = 11;
            this.btnArquivoHistorico.Text = "Escolher arquivo...";
            this.btnArquivoHistorico.UseVisualStyleBackColor = true;
            this.btnArquivoHistorico.Click += new System.EventHandler(this.btnArquivoHistorico_Click);
            // 
            // txtArquivoHistorico
            // 
            this.txtArquivoHistorico.Enabled = false;
            this.txtArquivoHistorico.Location = new System.Drawing.Point(23, 288);
            this.txtArquivoHistorico.Name = "txtArquivoHistorico";
            this.txtArquivoHistorico.Size = new System.Drawing.Size(642, 20);
            this.txtArquivoHistorico.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Arquivo de histórico de resultados";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnArquivoHistorico);
            this.Controls.Add(this.txtArquivoHistorico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTamanhoBloco);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTipoDeJogo);
            this.Controls.Add(this.lblDescricaoJogo);
            this.Controls.Add(this.btnAnalisar);
            this.Controls.Add(this.btnAbrirArquivoJogos);
            this.Controls.Add(this.txtJogo);
            this.Controls.Add(this.rbUmJogo);
            this.Controls.Add(this.rbConjuntoJogos);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "Analisador de jogos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescricaoJogo;
        private System.Windows.Forms.Button btnAbrirArquivoJogos;
        private System.Windows.Forms.TextBox txtJogo;
        private System.Windows.Forms.RadioButton rbConjuntoJogos;
        private System.Windows.Forms.RadioButton rbUmJogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialogJogos;
        private System.Windows.Forms.Button btnAnalisar;
        private System.Windows.Forms.ComboBox cbTipoDeJogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTamanhoBloco;
        private System.Windows.Forms.Button btnArquivoHistorico;
        private System.Windows.Forms.TextBox txtArquivoHistorico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialogHistorico;
    }
}

