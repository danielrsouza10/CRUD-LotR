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
            dataInicialTimePicker = new DateTimePicker();
            vivoPersonagemCheckBox = new CheckBox();
            buttonReset = new Button();
            tabControl = new TabControl();
            tabPersonagens = new TabPage();
            labelRacas = new Label();
            labelProfissao = new Label();
            labelFiltros = new Label();
            mortoPersonagemCheckBox = new CheckBox();
            boxFiltroProfissao = new ComboBox();
            personagemBindingSource1 = new BindingSource(components);
            filtroRacaBox = new ComboBox();
            racaBindingSource = new BindingSource(components);
            labelDataFinal = new Label();
            labelDataInicial = new Label();
            dataFinalTimePicker = new DateTimePicker();
            gridPersonagens = new DataGridView();
            tabRacas = new TabPage();
            gridRacas = new DataGridView();
            barraDePesquisaDeRaca = new TextBox();
            idRacaRadioButton = new RadioButton();
            nomeRacaRadioButton = new RadioButton();
            racaExtintaCheckBox = new CheckBox();
            personagemBindingSource = new BindingSource(components);
            tabControl.SuspendLayout();
            tabPersonagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridPersonagens).BeginInit();
            tabRacas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRacas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
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
            button2.Click += AoClicarNoBotaoEditarDeveAbrirJanelaDeEdicao;
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
            barraDePesquisaDePersonagem.Size = new Size(650, 29);
            barraDePesquisaDePersonagem.TabIndex = 4;
            barraDePesquisaDePersonagem.TextChanged += AoDigitarNaBarraDePesquisaDePersonagemDeveListarNoDataGrid;
            // 
            // dataInicialTimePicker
            // 
            dataInicialTimePicker.Location = new Point(755, 4);
            dataInicialTimePicker.Margin = new Padding(3, 4, 3, 4);
            dataInicialTimePicker.Name = "dataInicialTimePicker";
            dataInicialTimePicker.Size = new Size(291, 27);
            dataInicialTimePicker.TabIndex = 7;
            dataInicialTimePicker.ValueChanged += dataInicialTimePicker_ValueChanged;
            // 
            // vivoPersonagemCheckBox
            // 
            vivoPersonagemCheckBox.AutoSize = true;
            vivoPersonagemCheckBox.Location = new Point(64, 43);
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
            buttonReset.Click += AoClicarNoBotaoResetLimparFiltroEDefinirOGrid;
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
            tabPersonagens.Controls.Add(labelRacas);
            tabPersonagens.Controls.Add(labelProfissao);
            tabPersonagens.Controls.Add(labelFiltros);
            tabPersonagens.Controls.Add(mortoPersonagemCheckBox);
            tabPersonagens.Controls.Add(boxFiltroProfissao);
            tabPersonagens.Controls.Add(filtroRacaBox);
            tabPersonagens.Controls.Add(labelDataFinal);
            tabPersonagens.Controls.Add(labelDataInicial);
            tabPersonagens.Controls.Add(dataFinalTimePicker);
            tabPersonagens.Controls.Add(gridPersonagens);
            tabPersonagens.Controls.Add(barraDePesquisaDePersonagem);
            tabPersonagens.Controls.Add(dataInicialTimePicker);
            tabPersonagens.Controls.Add(vivoPersonagemCheckBox);
            tabPersonagens.Location = new Point(4, 29);
            tabPersonagens.Name = "tabPersonagens";
            tabPersonagens.Padding = new Padding(3);
            tabPersonagens.Size = new Size(1052, 512);
            tabPersonagens.TabIndex = 0;
            tabPersonagens.Text = "Personagens";
            tabPersonagens.UseVisualStyleBackColor = true;
            // 
            // labelRacas
            // 
            labelRacas.AutoSize = true;
            labelRacas.Location = new Point(208, 44);
            labelRacas.Name = "labelRacas";
            labelRacas.Size = new Size(50, 20);
            labelRacas.TabIndex = 18;
            labelRacas.Text = "Raças:";
            // 
            // labelProfissao
            // 
            labelProfissao.AutoSize = true;
            labelProfissao.Location = new Point(427, 44);
            labelProfissao.Name = "labelProfissao";
            labelProfissao.Size = new Size(72, 20);
            labelProfissao.TabIndex = 17;
            labelProfissao.Text = "Profissão:";
            // 
            // labelFiltros
            // 
            labelFiltros.AutoSize = true;
            labelFiltros.Location = new Point(6, 44);
            labelFiltros.Name = "labelFiltros";
            labelFiltros.Size = new Size(52, 20);
            labelFiltros.TabIndex = 16;
            labelFiltros.Text = "Filtros:";
            // 
            // mortoPersonagemCheckBox
            // 
            mortoPersonagemCheckBox.AutoSize = true;
            mortoPersonagemCheckBox.Location = new Point(130, 43);
            mortoPersonagemCheckBox.Name = "mortoPersonagemCheckBox";
            mortoPersonagemCheckBox.Size = new Size(72, 24);
            mortoPersonagemCheckBox.TabIndex = 15;
            mortoPersonagemCheckBox.Text = "Morto";
            mortoPersonagemCheckBox.UseVisualStyleBackColor = true;
            mortoPersonagemCheckBox.CheckedChanged += AoDarCheckNoBoxMortoDeveFiltarAListaDePersonagens;
            // 
            // boxFiltroProfissao
            // 
            boxFiltroProfissao.DataSource = personagemBindingSource1;
            boxFiltroProfissao.DropDownStyle = ComboBoxStyle.DropDownList;
            boxFiltroProfissao.FormattingEnabled = true;
            boxFiltroProfissao.Location = new Point(505, 38);
            boxFiltroProfissao.Name = "boxFiltroProfissao";
            boxFiltroProfissao.Size = new Size(151, 28);
            boxFiltroProfissao.TabIndex = 14;
            boxFiltroProfissao.SelectedIndexChanged += boxFiltroProfissao_SelectedIndexChanged;
            // 
            // personagemBindingSource1
            // 
            personagemBindingSource1.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // filtroRacaBox
            // 
            filtroRacaBox.DataSource = racaBindingSource;
            filtroRacaBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filtroRacaBox.FormattingEnabled = true;
            filtroRacaBox.Location = new Point(266, 38);
            filtroRacaBox.Name = "filtroRacaBox";
            filtroRacaBox.Size = new Size(151, 28);
            filtroRacaBox.TabIndex = 13;
            filtroRacaBox.SelectedIndexChanged += AoAlterarASelecaoDoComboboxDeRacasDeveFiltrar;
            // 
            // racaBindingSource
            // 
            racaBindingSource.DataSource = typeof(Dominio.Modelos.Raca);
            // 
            // labelDataFinal
            // 
            labelDataFinal.AutoSize = true;
            labelDataFinal.Location = new Point(662, 44);
            labelDataFinal.Name = "labelDataFinal";
            labelDataFinal.Size = new Size(76, 20);
            labelDataFinal.TabIndex = 12;
            labelDataFinal.Text = "Data Final";
            // 
            // labelDataInicial
            // 
            labelDataInicial.AutoSize = true;
            labelDataInicial.Location = new Point(662, 8);
            labelDataInicial.Name = "labelDataInicial";
            labelDataInicial.Size = new Size(84, 20);
            labelDataInicial.TabIndex = 11;
            labelDataInicial.Text = "Data Inicial";
            // 
            // dataFinalTimePicker
            // 
            dataFinalTimePicker.Location = new Point(755, 39);
            dataFinalTimePicker.Name = "dataFinalTimePicker";
            dataFinalTimePicker.Size = new Size(291, 27);
            dataFinalTimePicker.TabIndex = 10;
            dataFinalTimePicker.ValueChanged += dataFinalTimePicker_ValueChanged;
            // 
            // gridPersonagens
            // 
            gridPersonagens.AllowUserToAddRows = false;
            gridPersonagens.AllowUserToDeleteRows = false;
            gridPersonagens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPersonagens.BackgroundColor = SystemColors.Window;
            gridPersonagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPersonagens.Location = new Point(6, 75);
            gridPersonagens.Name = "gridPersonagens";
            gridPersonagens.ReadOnly = true;
            gridPersonagens.RowHeadersWidth = 51;
            gridPersonagens.RowTemplate.Height = 29;
            gridPersonagens.Size = new Size(1040, 437);
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
            nomeRacaRadioButton.Location = new Point(0, 0);
            nomeRacaRadioButton.Name = "nomeRacaRadioButton";
            nomeRacaRadioButton.Size = new Size(104, 24);
            nomeRacaRadioButton.TabIndex = 12;
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
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridPersonagens).EndInit();
            tabRacas.ResumeLayout(false);
            tabRacas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRacas).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonAdicionar;
        private Button button2;
        private Button button3;
        private TextBox barraDePesquisaDePersonagem;
        private DateTimePicker dataInicialTimePicker;
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
        private Label labelDataFinal;
        private Label labelDataInicial;
        private DateTimePicker dataFinalTimePicker;
        private ComboBox filtroRacaBox;
        private ComboBox boxFiltroProfissao;
        private BindingSource personagemBindingSource1;
        private CheckBox mortoPersonagemCheckBox;
        private Label labelFiltros;
        private Label labelRacas;
        private Label labelProfissao;
    }
}
