namespace Forms.Forms
{
    partial class CriacaoPersonagemForm
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
            components = new System.ComponentModel.Container();
            textBoxNome = new TextBox();
            labelNome = new Label();
            labelProfissao = new Label();
            labelRaca = new Label();
            labelIdade = new Label();
            boxRacas = new ComboBox();
            racaBindingSource = new BindingSource(components);
            boxProfissao = new ComboBox();
            labelAltura = new Label();
            labelEstaVivo = new Label();
            radioButtonSim = new RadioButton();
            radioButtonNao = new RadioButton();
            buttonCriar = new Button();
            buttonCancelar = new Button();
            boxIdade = new NumericUpDown();
            boxAltura = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boxIdade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boxAltura).BeginInit();
            SuspendLayout();
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(64, 21);
            textBoxNome.Margin = new Padding(3, 4, 3, 4);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(154, 27);
            textBoxNome.TabIndex = 0;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(11, 25);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(50, 20);
            labelNome.TabIndex = 1;
            labelNome.Text = "Nome";
            // 
            // labelProfissao
            // 
            labelProfissao.AutoSize = true;
            labelProfissao.Location = new Point(257, 76);
            labelProfissao.Name = "labelProfissao";
            labelProfissao.Size = new Size(50, 20);
            labelProfissao.TabIndex = 2;
            labelProfissao.Text = "Classe";
            // 
            // labelRaca
            // 
            labelRaca.AutoSize = true;
            labelRaca.Location = new Point(257, 25);
            labelRaca.Name = "labelRaca";
            labelRaca.Size = new Size(41, 20);
            labelRaca.TabIndex = 3;
            labelRaca.Text = "Raça";
            // 
            // labelIdade
            // 
            labelIdade.AutoSize = true;
            labelIdade.Location = new Point(11, 76);
            labelIdade.Name = "labelIdade";
            labelIdade.Size = new Size(47, 20);
            labelIdade.TabIndex = 4;
            labelIdade.Text = "Idade";
            // 
            // boxRacas
            // 
            boxRacas.DataSource = racaBindingSource;
            boxRacas.DropDownStyle = ComboBoxStyle.DropDownList;
            boxRacas.FormattingEnabled = true;
            boxRacas.Location = new Point(310, 21);
            boxRacas.Margin = new Padding(3, 4, 3, 4);
            boxRacas.Name = "boxRacas";
            boxRacas.Size = new Size(138, 28);
            boxRacas.TabIndex = 5;
            // 
            // racaBindingSource
            // 
            racaBindingSource.DataSource = typeof(Dominio.Modelos.Raca);
            // 
            // boxProfissao
            // 
            boxProfissao.DropDownStyle = ComboBoxStyle.DropDownList;
            boxProfissao.FormattingEnabled = true;
            boxProfissao.Location = new Point(310, 72);
            boxProfissao.Margin = new Padding(3, 4, 3, 4);
            boxProfissao.Name = "boxProfissao";
            boxProfissao.Size = new Size(138, 28);
            boxProfissao.TabIndex = 6;
            // 
            // labelAltura
            // 
            labelAltura.AutoSize = true;
            labelAltura.Location = new Point(13, 121);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(49, 20);
            labelAltura.TabIndex = 7;
            labelAltura.Text = "Altura";
            // 
            // labelEstaVivo
            // 
            labelEstaVivo.AutoSize = true;
            labelEstaVivo.Location = new Point(257, 124);
            labelEstaVivo.Name = "labelEstaVivo";
            labelEstaVivo.Size = new Size(74, 20);
            labelEstaVivo.TabIndex = 8;
            labelEstaVivo.Text = "Esta vivo?";
            // 
            // radioButtonSim
            // 
            radioButtonSim.AutoSize = true;
            radioButtonSim.Checked = true;
            radioButtonSim.Location = new Point(330, 121);
            radioButtonSim.Margin = new Padding(3, 4, 3, 4);
            radioButtonSim.Name = "radioButtonSim";
            radioButtonSim.Size = new Size(55, 24);
            radioButtonSim.TabIndex = 9;
            radioButtonSim.TabStop = true;
            radioButtonSim.Text = "Sim";
            radioButtonSim.UseVisualStyleBackColor = true;
            // 
            // radioButtonNao
            // 
            radioButtonNao.AutoSize = true;
            radioButtonNao.Location = new Point(389, 121);
            radioButtonNao.Margin = new Padding(3, 4, 3, 4);
            radioButtonNao.Name = "radioButtonNao";
            radioButtonNao.Size = new Size(58, 24);
            radioButtonNao.TabIndex = 10;
            radioButtonNao.Text = "Não";
            radioButtonNao.UseVisualStyleBackColor = true;
            // 
            // buttonCriar
            // 
            buttonCriar.Location = new Point(272, 167);
            buttonCriar.Margin = new Padding(3, 4, 3, 4);
            buttonCriar.Name = "buttonCriar";
            buttonCriar.Size = new Size(86, 31);
            buttonCriar.TabIndex = 11;
            buttonCriar.Text = "Adicionar";
            buttonCriar.UseVisualStyleBackColor = true;
            buttonCriar.Click += buttonCriar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(365, 167);
            buttonCancelar.Margin = new Padding(3, 4, 3, 4);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(86, 31);
            buttonCancelar.TabIndex = 12;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // boxIdade
            // 
            boxIdade.Location = new Point(64, 72);
            boxIdade.Margin = new Padding(3, 4, 3, 4);
            boxIdade.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            boxIdade.Name = "boxIdade";
            boxIdade.Size = new Size(154, 27);
            boxIdade.TabIndex = 13;
            // 
            // boxAltura
            // 
            boxAltura.Location = new Point(64, 119);
            boxAltura.Margin = new Padding(3, 4, 3, 4);
            boxAltura.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            boxAltura.Name = "boxAltura";
            boxAltura.Size = new Size(154, 27);
            boxAltura.TabIndex = 14;
            // 
            // CriacaoPersonagemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 211);
            Controls.Add(boxAltura);
            Controls.Add(boxIdade);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonCriar);
            Controls.Add(radioButtonNao);
            Controls.Add(radioButtonSim);
            Controls.Add(labelEstaVivo);
            Controls.Add(labelAltura);
            Controls.Add(boxProfissao);
            Controls.Add(boxRacas);
            Controls.Add(labelIdade);
            Controls.Add(labelRaca);
            Controls.Add(labelProfissao);
            Controls.Add(labelNome);
            Controls.Add(textBoxNome);
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            Name = "CriacaoPersonagemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CriacaoPersonagem";
            Load += CriacaoPersonagem_Load;
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)boxIdade).EndInit();
            ((System.ComponentModel.ISupportInitialize)boxAltura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNome;
        private Label labelNome;
        private Label labelProfissao;
        private Label labelRaca;
        private Label labelIdade;
        private ComboBox boxRacas;
        private ComboBox boxProfissao;
        private Label labelAltura;
        private Label labelEstaVivo;
        private RadioButton radioButtonSim;
        private RadioButton radioButtonNao;
        private Button buttonCriar;
        private Button buttonCancelar;
        private NumericUpDown boxIdade;
        private NumericUpDown boxAltura;
        private BindingSource racaBindingSource;
    }
}