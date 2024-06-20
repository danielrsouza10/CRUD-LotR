namespace Forms.Forms
{
    partial class CriacaoRacaForm
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
            labelNome = new Label();
            textBoxNome = new TextBox();
            labelHabilidadeRacial = new Label();
            labelLocalizacaoGeografica = new Label();
            textBoxHabilidadeRacial = new TextBox();
            textBoxLocalizacaoGeografica = new TextBox();
            labelEstaExtinta = new Label();
            simRadioButton = new RadioButton();
            naoRadioButton = new RadioButton();
            criarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(12, 19);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(50, 20);
            labelNome.TabIndex = 3;
            labelNome.Text = "Nome";
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(65, 15);
            textBoxNome.Margin = new Padding(3, 4, 3, 4);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(271, 27);
            textBoxNome.TabIndex = 2;
            // 
            // labelHabilidadeRacial
            // 
            labelHabilidadeRacial.AutoSize = true;
            labelHabilidadeRacial.Location = new Point(12, 68);
            labelHabilidadeRacial.Name = "labelHabilidadeRacial";
            labelHabilidadeRacial.Size = new Size(127, 20);
            labelHabilidadeRacial.TabIndex = 4;
            labelHabilidadeRacial.Text = "Habilidade Racial";
            // 
            // labelLocalizacaoGeografica
            // 
            labelLocalizacaoGeografica.AutoSize = true;
            labelLocalizacaoGeografica.Location = new Point(12, 117);
            labelLocalizacaoGeografica.Name = "labelLocalizacaoGeografica";
            labelLocalizacaoGeografica.Size = new Size(164, 20);
            labelLocalizacaoGeografica.TabIndex = 5;
            labelLocalizacaoGeografica.Text = "Localicação Geográfica";
            // 
            // textBoxHabilidadeRacial
            // 
            textBoxHabilidadeRacial.Location = new Point(145, 65);
            textBoxHabilidadeRacial.Name = "textBoxHabilidadeRacial";
            textBoxHabilidadeRacial.Size = new Size(191, 27);
            textBoxHabilidadeRacial.TabIndex = 6;
            // 
            // textBoxLocalizacaoGeografica
            // 
            textBoxLocalizacaoGeografica.Location = new Point(182, 114);
            textBoxLocalizacaoGeografica.Name = "textBoxLocalizacaoGeografica";
            textBoxLocalizacaoGeografica.Size = new Size(154, 27);
            textBoxLocalizacaoGeografica.TabIndex = 7;
            // 
            // labelEstaExtinta
            // 
            labelEstaExtinta.AutoSize = true;
            labelEstaExtinta.Location = new Point(12, 171);
            labelEstaExtinta.Name = "labelEstaExtinta";
            labelEstaExtinta.Size = new Size(92, 20);
            labelEstaExtinta.TabIndex = 8;
            labelEstaExtinta.Text = "Esta extinta?";
            // 
            // simRadioButton
            // 
            simRadioButton.AutoSize = true;
            simRadioButton.Location = new Point(217, 169);
            simRadioButton.Name = "simRadioButton";
            simRadioButton.Size = new Size(55, 24);
            simRadioButton.TabIndex = 9;
            simRadioButton.TabStop = true;
            simRadioButton.Text = "Sim";
            simRadioButton.UseVisualStyleBackColor = true;
            // 
            // naoRadioButton
            // 
            naoRadioButton.AutoSize = true;
            naoRadioButton.Location = new Point(278, 169);
            naoRadioButton.Name = "naoRadioButton";
            naoRadioButton.Size = new Size(58, 24);
            naoRadioButton.TabIndex = 10;
            naoRadioButton.TabStop = true;
            naoRadioButton.Text = "Não";
            naoRadioButton.UseVisualStyleBackColor = true;
            // 
            // criarButton
            // 
            criarButton.Location = new Point(142, 224);
            criarButton.Name = "criarButton";
            criarButton.Size = new Size(94, 29);
            criarButton.TabIndex = 11;
            criarButton.Text = "Criar";
            criarButton.UseVisualStyleBackColor = true;
            criarButton.Click += AoClicarNoBotaoCriarDeveCriarUmaRacaOuDispararUmaExcecao;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(242, 224);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 12;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += AoClicarNoBotaoCancelarDeveFecharACaixaDeDialogo;
            // 
            // CriacaoRacaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 265);
            Controls.Add(cancelarButton);
            Controls.Add(criarButton);
            Controls.Add(naoRadioButton);
            Controls.Add(simRadioButton);
            Controls.Add(labelEstaExtinta);
            Controls.Add(textBoxLocalizacaoGeografica);
            Controls.Add(textBoxHabilidadeRacial);
            Controls.Add(labelLocalizacaoGeografica);
            Controls.Add(labelHabilidadeRacial);
            Controls.Add(labelNome);
            Controls.Add(textBoxNome);
            MaximizeBox = false;
            Name = "CriacaoRacaForm";
            Text = "Criar Raça";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNome;
        private TextBox textBoxNome;
        private Label labelHabilidadeRacial;
        private Label labelLocalizacaoGeografica;
        private TextBox textBoxHabilidadeRacial;
        private TextBox textBoxLocalizacaoGeografica;
        private Label labelEstaExtinta;
        private RadioButton simRadioButton;
        private RadioButton naoRadioButton;
        private Button criarButton;
        private Button cancelarButton;
    }
}