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
            textBox1 = new TextBox();
            labelNome = new Label();
            labelProfissao = new Label();
            labelRaca = new Label();
            labelIdade = new Label();
            listaRacas = new ComboBox();
            comboBox1 = new ComboBox();
            labelAltura = new Label();
            labelEstaVivo = new Label();
            radioButtonSim = new RadioButton();
            radioButtonNao = new RadioButton();
            buttonCriar = new Button();
            buttonCancelar = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(56, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 23);
            textBox1.TabIndex = 0;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(10, 19);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 1;
            labelNome.Text = "Nome";
            // 
            // labelProfissao
            // 
            labelProfissao.AutoSize = true;
            labelProfissao.Location = new Point(225, 57);
            labelProfissao.Name = "labelProfissao";
            labelProfissao.Size = new Size(40, 15);
            labelProfissao.TabIndex = 2;
            labelProfissao.Text = "Classe";
            // 
            // labelRaca
            // 
            labelRaca.AutoSize = true;
            labelRaca.Location = new Point(225, 19);
            labelRaca.Name = "labelRaca";
            labelRaca.Size = new Size(32, 15);
            labelRaca.TabIndex = 3;
            labelRaca.Text = "Raça";
            // 
            // labelIdade
            // 
            labelIdade.AutoSize = true;
            labelIdade.Location = new Point(10, 57);
            labelIdade.Name = "labelIdade";
            labelIdade.Size = new Size(36, 15);
            labelIdade.TabIndex = 4;
            labelIdade.Text = "Idade";
            // 
            // listaRacas
            // 
            listaRacas.FormattingEnabled = true;
            listaRacas.Items.AddRange(new object[] { "Humano", "Elfo", "Anão", "Hobbit", "Orc", "Uruk-hai", "Troll", "Ent", "Maiar", "Dragão" });
            listaRacas.Location = new Point(271, 16);
            listaRacas.Name = "listaRacas";
            listaRacas.Size = new Size(121, 23);
            listaRacas.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Guerreiro", "Arqueiro", "Mago", "Ladrao", "Jardineiro", "Aventureiro", "Rei", "SenhoraDeLothlorien", "SenhorDeValfenda", "Escudeira", "Capitao", "Princesa", "Ent", "Cavaleiro", "ExHobbit" });
            comboBox1.Location = new Point(271, 54);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            // 
            // labelAltura
            // 
            labelAltura.AutoSize = true;
            labelAltura.Location = new Point(11, 91);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(39, 15);
            labelAltura.TabIndex = 7;
            labelAltura.Text = "Altura";
            // 
            // labelEstaVivo
            // 
            labelEstaVivo.AutoSize = true;
            labelEstaVivo.Location = new Point(225, 91);
            labelEstaVivo.Name = "labelEstaVivo";
            labelEstaVivo.Size = new Size(58, 15);
            labelEstaVivo.TabIndex = 8;
            labelEstaVivo.Text = "Esta vivo?";
            // 
            // radioButtonSim
            // 
            radioButtonSim.AutoSize = true;
            radioButtonSim.Location = new Point(289, 91);
            radioButtonSim.Name = "radioButtonSim";
            radioButtonSim.Size = new Size(45, 19);
            radioButtonSim.TabIndex = 9;
            radioButtonSim.TabStop = true;
            radioButtonSim.Text = "Sim";
            radioButtonSim.UseVisualStyleBackColor = true;
            // 
            // radioButtonNao
            // 
            radioButtonNao.AutoSize = true;
            radioButtonNao.Location = new Point(340, 91);
            radioButtonNao.Name = "radioButtonNao";
            radioButtonNao.Size = new Size(47, 19);
            radioButtonNao.TabIndex = 10;
            radioButtonNao.TabStop = true;
            radioButtonNao.Text = "Não";
            radioButtonNao.UseVisualStyleBackColor = true;
            // 
            // buttonCriar
            // 
            buttonCriar.Location = new Point(238, 125);
            buttonCriar.Name = "buttonCriar";
            buttonCriar.Size = new Size(75, 23);
            buttonCriar.TabIndex = 11;
            buttonCriar.Text = "Adicionar";
            buttonCriar.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(319, 125);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 23);
            buttonCancelar.TabIndex = 12;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += this.buttonCancelar_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(56, 54);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(135, 23);
            numericUpDown1.TabIndex = 13;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(56, 89);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(135, 23);
            numericUpDown2.TabIndex = 14;
            // 
            // CriacaoPersonagemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 158);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonCriar);
            Controls.Add(radioButtonNao);
            Controls.Add(radioButtonSim);
            Controls.Add(labelEstaVivo);
            Controls.Add(labelAltura);
            Controls.Add(comboBox1);
            Controls.Add(listaRacas);
            Controls.Add(labelIdade);
            Controls.Add(labelRaca);
            Controls.Add(labelProfissao);
            Controls.Add(labelNome);
            Controls.Add(textBox1);
            Name = "CriacaoPersonagemForm";
            Text = "CriacaoPersonagem";
            Load += CriacaoPersonagem_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label labelNome;
        private Label labelProfissao;
        private Label labelRaca;
        private Label labelIdade;
        private ComboBox listaRacas;
        private ComboBox comboBox1;
        private Label labelAltura;
        private Label labelEstaVivo;
        private RadioButton radioButtonSim;
        private RadioButton radioButtonNao;
        private Button buttonCriar;
        private Button buttonCancelar;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
    }
}