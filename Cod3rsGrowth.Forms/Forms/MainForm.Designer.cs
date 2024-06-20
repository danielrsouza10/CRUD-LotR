namespace Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonAdicionar = new Button();
            button2 = new Button();
            button3 = new Button();
            barraDePesquisaDePersonagem = new TextBox();
            nomePersonagemRadioButton = new RadioButton();
            idPersonagemRadioButton = new RadioButton();
            dateTimePicker = new DateTimePicker();
            vivoPersonagemCheckBox = new CheckBox();
            buttonReset = new Button();
            tabControl = new TabControl();
            tabPersonagens = new TabPage();
            gridPersonagens = new DataGridView();
            tabRacas = new TabPage();
            gridRacas = new DataGridView();
            barraDePesquisaDeRaca = new TextBox();
            idRacaRadioButton = new RadioButton();
            nomeRacaRadioButton = new RadioButton();
            racaExtintaCheckBox = new CheckBox();
            personagemBindingSource = new BindingSource(components);
            racaBindingSource = new BindingSource(components);
            tabControl.SuspendLayout();
            tabPersonagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPersonagens).BeginInit();
            tabRacas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRacas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonAdicionar
            // 
            buttonAdicionar.Location = new Point(802, 556);
            buttonAdicionar.Margin = new Padding(3, 4, 3, 4);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(86, 31);
            buttonAdicionar.TabIndex = 1;
            buttonAdicionar.Text = "Adicionar";
            buttonAdicionar.UseVisualStyleBackColor = true;
            buttonAdicionar.Click += AoClicarNoBotaoAdicionarDeveAbrirAJanelaDeCriacao;
            // 
            // button2
            // 
            button2.Location = new Point(894, 556);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 2;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(986, 556);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 3;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            button3.Click += AoClicarNoBotaoRemoverDeveVerificarTabAtivaERemoverDeAcordo;
            // 
            // barraDePesquisaDePersonagem
            // 
            barraDePesquisaDePersonagem.Location = new Point(6, 4);
            barraDePesquisaDePersonagem.Margin = new Padding(3, 4, 3, 4);
            barraDePesquisaDePersonagem.Multiline = true;
            barraDePesquisaDePersonagem.Name = "barraDePesquisaDePersonagem";
            barraDePesquisaDePersonagem.PlaceholderText = "Pesquise o personagem...";
            barraDePesquisaDePersonagem.Size = new Size(555, 29);
            barraDePesquisaDePersonagem.TabIndex = 4;
            barraDePesquisaDePersonagem.TextChanged += AoDigitarNaBarraDePesquisaDePersonagemDeveListarNoDataGrid;
            // 
            // nomePersonagemRadioButton
            // 
            nomePersonagemRadioButton.AutoSize = true;
            nomePersonagemRadioButton.Checked = true;
            nomePersonagemRadioButton.Location = new Point(567, 9);
            nomePersonagemRadioButton.Margin = new Padding(3, 4, 3, 4);
            nomePersonagemRadioButton.Name = "nomePersonagemRadioButton";
            nomePersonagemRadioButton.Size = new Size(71, 24);
            nomePersonagemRadioButton.TabIndex = 5;
            nomePersonagemRadioButton.TabStop = true;
            nomePersonagemRadioButton.Text = "Nome";
            nomePersonagemRadioButton.UseVisualStyleBackColor = true;
            nomePersonagemRadioButton.CheckedChanged += AoAlterarASelecaoDoImputRadioDeNomePersonagemDeveAtualizarAListaPersonagem;
            // 
            // idPersonagemRadioButton
            // 
            idPersonagemRadioButton.AutoSize = true;
            idPersonagemRadioButton.Location = new Point(644, 8);
            idPersonagemRadioButton.Margin = new Padding(3, 4, 3, 4);
            idPersonagemRadioButton.Name = "idPersonagemRadioButton";
            idPersonagemRadioButton.Size = new Size(43, 24);
            idPersonagemRadioButton.TabIndex = 6;
            idPersonagemRadioButton.TabStop = true;
            idPersonagemRadioButton.Text = "Id";
            idPersonagemRadioButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(755, 7);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(291, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // vivoPersonagemCheckBox
            // 
            vivoPersonagemCheckBox.AutoSize = true;
            vivoPersonagemCheckBox.Location = new Point(691, 9);
            vivoPersonagemCheckBox.Margin = new Padding(3, 4, 3, 4);
            vivoPersonagemCheckBox.Name = "vivoPersonagemCheckBox";
            vivoPersonagemCheckBox.Size = new Size(60, 24);
            vivoPersonagemCheckBox.TabIndex = 8;
            vivoPersonagemCheckBox.Text = "Vivo";
            vivoPersonagemCheckBox.UseVisualStyleBackColor = true;
            vivoPersonagemCheckBox.CheckedChanged += AoDarCheckNoBoxVivoDeveFiltarAListaDePersonagens;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(12, 556);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(94, 29);
            buttonReset.TabIndex = 9;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += AoClicarNoBotaoResetDeveCarregarAsListasSemFiltrosAplicados;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPersonagens);
            tabControl.Controls.Add(tabRacas);
            tabControl.Location = new Point(12, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1060, 545);
            tabControl.TabIndex = 10;
            // 
            // tabPersonagens
            // 
            tabPersonagens.Controls.Add(gridPersonagens);
            tabPersonagens.Controls.Add(barraDePesquisaDePersonagem);
            tabPersonagens.Controls.Add(dateTimePicker);
            tabPersonagens.Controls.Add(idPersonagemRadioButton);
            tabPersonagens.Controls.Add(nomePersonagemRadioButton);
            tabPersonagens.Controls.Add(vivoPersonagemCheckBox);
            tabPersonagens.Location = new Point(4, 29);
            tabPersonagens.Name = "tabPersonagens";
            tabPersonagens.Padding = new Padding(3);
            tabPersonagens.Size = new Size(1052, 512);
            tabPersonagens.TabIndex = 0;
            tabPersonagens.Text = "Personagens";
            tabPersonagens.UseVisualStyleBackColor = true;
            // 
            // gridPersonagens
            // 
            gridPersonagens.AllowUserToAddRows = false;
            gridPersonagens.AllowUserToDeleteRows = false;
            gridPersonagens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPersonagens.BackgroundColor = SystemColors.Control;
            gridPersonagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPersonagens.Location = new Point(6, 39);
            gridPersonagens.Name = "gridPersonagens";
            gridPersonagens.ReadOnly = true;
            gridPersonagens.RowHeadersWidth = 51;
            gridPersonagens.RowTemplate.Height = 29;
            gridPersonagens.Size = new Size(1040, 469);
            gridPersonagens.TabIndex = 9;
            // 
            // tabRacas
            // 
            tabRacas.Controls.Add(gridRacas);
            tabRacas.Controls.Add(barraDePesquisaDeRaca);
            tabRacas.Controls.Add(idRacaRadioButton);
            tabRacas.Controls.Add(nomeRacaRadioButton);
            tabRacas.Controls.Add(racaExtintaCheckBox);
            tabRacas.Location = new Point(4, 29);
            tabRacas.Name = "tabRacas";
            tabRacas.Padding = new Padding(3);
            tabRacas.Size = new Size(1052, 512);
            tabRacas.TabIndex = 1;
            tabRacas.Text = "Raças";
            tabRacas.UseVisualStyleBackColor = true;
            // 
            // gridRacas
            // 
            gridRacas.AllowUserToAddRows = false;
            gridRacas.AllowUserToDeleteRows = false;
            gridRacas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRacas.BackgroundColor = SystemColors.Control;
            gridRacas.ColumnHeadersHeight = 29;
            gridRacas.Location = new Point(6, 39);
            gridRacas.Name = "gridRacas";
            gridRacas.ReadOnly = true;
            gridRacas.RowHeadersWidth = 51;
            gridRacas.Size = new Size(1040, 470);
            gridRacas.TabIndex = 0;
            // 
            // barraDePesquisaDeRaca
            // 
            barraDePesquisaDeRaca.Location = new Point(6, 4);
            barraDePesquisaDeRaca.Margin = new Padding(3, 4, 3, 4);
            barraDePesquisaDeRaca.Multiline = true;
            barraDePesquisaDeRaca.Name = "barraDePesquisaDeRaca";
            barraDePesquisaDeRaca.PlaceholderText = "Pesquise a raça...";
            barraDePesquisaDeRaca.Size = new Size(555, 29);
            barraDePesquisaDeRaca.TabIndex = 9;
            barraDePesquisaDeRaca.TextChanged += AoDigitarNaBarraDePesquisaDeRacaDeveListarNoDataGrid;
            // 
            // idRacaRadioButton
            // 
            idRacaRadioButton.AutoSize = true;
            idRacaRadioButton.Location = new Point(644, 8);
            idRacaRadioButton.Margin = new Padding(3, 4, 3, 4);
            idRacaRadioButton.Name = "idRacaRadioButton";
            idRacaRadioButton.Size = new Size(43, 24);
            idRacaRadioButton.TabIndex = 11;
            idRacaRadioButton.TabStop = true;
            idRacaRadioButton.Text = "Id";
            idRacaRadioButton.UseVisualStyleBackColor = true;
            // 
            // nomeRacaRadioButton
            // 
            nomeRacaRadioButton.AutoSize = true;
            nomeRacaRadioButton.Checked = true;
            nomeRacaRadioButton.Location = new Point(567, 9);
            nomeRacaRadioButton.Margin = new Padding(3, 4, 3, 4);
            nomeRacaRadioButton.Name = "nomeRacaRadioButton";
            nomeRacaRadioButton.Size = new Size(71, 24);
            nomeRacaRadioButton.TabIndex = 10;
            nomeRacaRadioButton.TabStop = true;
            nomeRacaRadioButton.Text = "Nome";
            nomeRacaRadioButton.UseVisualStyleBackColor = true;
            nomeRacaRadioButton.CheckedChanged += AoAlterarASelecaoDoImputRadioDeNomeRacaDeveAtualizarAListaRaca;
            // 
            // racaExtintaCheckBox
            // 
            racaExtintaCheckBox.AutoSize = true;
            racaExtintaCheckBox.Location = new Point(691, 9);
            racaExtintaCheckBox.Margin = new Padding(3, 4, 3, 4);
            racaExtintaCheckBox.Name = "racaExtintaCheckBox";
            racaExtintaCheckBox.Size = new Size(76, 24);
            racaExtintaCheckBox.TabIndex = 12;
            racaExtintaCheckBox.Text = "Extinta";
            racaExtintaCheckBox.UseVisualStyleBackColor = true;
            racaExtintaCheckBox.CheckedChanged += AoDarCheckNoBoxExtintaDeveFiltarAListaDeRacas;
            // 
            // personagemBindingSource
            // 
            personagemBindingSource.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // racaBindingSource
            // 
            racaBindingSource.DataSource = typeof(Dominio.Modelos.Raca);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1084, 600);
            Controls.Add(tabControl);
            Controls.Add(buttonReset);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(buttonAdicionar);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "O Senhor dos Anéis DB";
            Load += IniciarFormPrincipal;
            tabControl.ResumeLayout(false);
            tabPersonagens.ResumeLayout(false);
            tabPersonagens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridPersonagens).EndInit();
            tabRacas.ResumeLayout(false);
            tabRacas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRacas).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonAdicionar;
        private Button button2;
        private Button button3;
        private TextBox barraDePesquisaDePersonagem;
        private RadioButton nomePersonagemRadioButton;
        private RadioButton idPersonagemRadioButton;
        private DateTimePicker dateTimePicker;
        private CheckBox vivoPersonagemCheckBox;
        private Button buttonReset;
        private TabControl tabControl;
        private TabPage tabPersonagens;
        private TabPage tabRacas;
        private DataGridView gridPersonagens;
        private TextBox barraDePesquisaDeRaca;
        private RadioButton idRacaRadioButton;
        private RadioButton nomeRacaRadioButton;
        private CheckBox racaExtintaCheckBox;
        private DataGridView gridRacas;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn localizacaoGeograficaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn habilidadeRacialDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estaExtintaDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idRacaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profissaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estaVivoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataDoCadastroDataGridViewTextBoxColumn;
        private BindingSource personagemBindingSource;
        private BindingSource racaBindingSource;
    }
}
