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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            racaBindingSource = new BindingSource(components);
            personagemBindingSource = new BindingSource(components);
            buttonAdicionar = new Button();
            button2 = new Button();
            button3 = new Button();
            barraDePesquisaDePersonagem = new TextBox();
            nomeRadioButton = new RadioButton();
            idRadioButton = new RadioButton();
            dateTimePicker = new DateTimePicker();
            vivoCheckBox = new CheckBox();
            buttonReset = new Button();
            tabControl = new TabControl();
            tabPersonagens = new TabPage();
            gridPersonagens = new DataGridView();
            tabRacas = new TabPage();
            gridRacas = new DataGridView();
            barraDePesquisaDeRaca = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            checkBox1 = new CheckBox();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            localizacaoGeograficaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            habilidadeRacialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estaExtintaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idRacaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profissaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estaVivoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataDoCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
            tabControl.SuspendLayout();
            tabPersonagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPersonagens).BeginInit();
            tabRacas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRacas).BeginInit();
            SuspendLayout();
            // 
            // racaBindingSource
            // 
            racaBindingSource.DataSource = typeof(Dominio.Modelos.Raca);
            // 
            // personagemBindingSource
            // 
            personagemBindingSource.DataSource = typeof(Dominio.Modelos.Personagem);
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
            button3.Click += AoClicarNoBotaoRemoverDevePedirConfirmacaoERemoverPersonagemSelecionado;
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
            barraDePesquisaDePersonagem.TextChanged += AoDigitarNaBarraDePesquisaDeveListarOsItensCorrespondentesAPesquisa;
            barraDePesquisaDePersonagem.Enter += AoEntrarNaBarraDePesquisaDeveLimparOPlaceholder;
            barraDePesquisaDePersonagem.Leave += AoSairDaBarraDePesquisaDeveAdicionarOPlaceholder;
            // 
            // nomeRadioButton
            // 
            nomeRadioButton.AutoSize = true;
            nomeRadioButton.Checked = true;
            nomeRadioButton.Location = new Point(567, 9);
            nomeRadioButton.Margin = new Padding(3, 4, 3, 4);
            nomeRadioButton.Name = "nomeRadioButton";
            nomeRadioButton.Size = new Size(71, 24);
            nomeRadioButton.TabIndex = 5;
            nomeRadioButton.TabStop = true;
            nomeRadioButton.Text = "Nome";
            nomeRadioButton.UseVisualStyleBackColor = true;
            nomeRadioButton.CheckedChanged += AoAlterarASelecaoDoImputRadioDeNomeDeveAtualizarALista;
            // 
            // idRadioButton
            // 
            idRadioButton.AutoSize = true;
            idRadioButton.Location = new Point(644, 8);
            idRadioButton.Margin = new Padding(3, 4, 3, 4);
            idRadioButton.Name = "idRadioButton";
            idRadioButton.Size = new Size(43, 24);
            idRadioButton.TabIndex = 6;
            idRadioButton.TabStop = true;
            idRadioButton.Text = "Id";
            idRadioButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(755, 7);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(291, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // vivoCheckBox
            // 
            vivoCheckBox.AutoSize = true;
            vivoCheckBox.Location = new Point(691, 9);
            vivoCheckBox.Margin = new Padding(3, 4, 3, 4);
            vivoCheckBox.Name = "vivoCheckBox";
            vivoCheckBox.Size = new Size(60, 24);
            vivoCheckBox.TabIndex = 8;
            vivoCheckBox.Text = "Vivo";
            vivoCheckBox.UseVisualStyleBackColor = true;
            vivoCheckBox.CheckedChanged += AoDarCheckNoBoxVivoDeveFiltarALista;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(12, 556);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(94, 29);
            buttonReset.TabIndex = 9;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += AoClicarNoBotaoResetDeveCarregarAListaSemFiltrosAplicados;
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
            tabPersonagens.Controls.Add(idRadioButton);
            tabPersonagens.Controls.Add(nomeRadioButton);
            tabPersonagens.Controls.Add(vivoCheckBox);
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
            gridPersonagens.AutoGenerateColumns = false;
            gridPersonagens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPersonagens.BackgroundColor = SystemColors.Control;
            gridPersonagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPersonagens.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, idRacaDataGridViewTextBoxColumn, profissaoDataGridViewTextBoxColumn, idadeDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, estaVivoDataGridViewCheckBoxColumn, dataDoCadastroDataGridViewTextBoxColumn });
            gridPersonagens.DataSource = personagemBindingSource;
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
            tabRacas.Controls.Add(radioButton1);
            tabRacas.Controls.Add(radioButton2);
            tabRacas.Controls.Add(checkBox1);
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
            gridRacas.AutoGenerateColumns = false;
            gridRacas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRacas.BackgroundColor = SystemColors.Control;
            gridRacas.ColumnHeadersHeight = 29;
            gridRacas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn1, localizacaoGeograficaDataGridViewTextBoxColumn, habilidadeRacialDataGridViewTextBoxColumn, estaExtintaDataGridViewCheckBoxColumn });
            gridRacas.DataSource = racaBindingSource;
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
            barraDePesquisaDeRaca.PlaceholderText = "Pesquise o personagem...";
            barraDePesquisaDeRaca.Size = new Size(555, 29);
            barraDePesquisaDeRaca.TabIndex = 9;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(644, 8);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(43, 24);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "Id";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(567, 9);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(71, 24);
            radioButton2.TabIndex = 10;
            radioButton2.TabStop = true;
            radioButton2.Text = "Nome";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(691, 9);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(60, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Vivo";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.FillWeight = 25F;
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.MinimumWidth = 6;
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            nomeDataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn1.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            nomeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // localizacaoGeograficaDataGridViewTextBoxColumn
            // 
            localizacaoGeograficaDataGridViewTextBoxColumn.DataPropertyName = "LocalizacaoGeografica";
            localizacaoGeograficaDataGridViewTextBoxColumn.HeaderText = "LocalizacaoGeografica";
            localizacaoGeograficaDataGridViewTextBoxColumn.MinimumWidth = 6;
            localizacaoGeograficaDataGridViewTextBoxColumn.Name = "localizacaoGeograficaDataGridViewTextBoxColumn";
            localizacaoGeograficaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // habilidadeRacialDataGridViewTextBoxColumn
            // 
            habilidadeRacialDataGridViewTextBoxColumn.DataPropertyName = "HabilidadeRacial";
            habilidadeRacialDataGridViewTextBoxColumn.HeaderText = "HabilidadeRacial";
            habilidadeRacialDataGridViewTextBoxColumn.MinimumWidth = 6;
            habilidadeRacialDataGridViewTextBoxColumn.Name = "habilidadeRacialDataGridViewTextBoxColumn";
            habilidadeRacialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estaExtintaDataGridViewCheckBoxColumn
            // 
            estaExtintaDataGridViewCheckBoxColumn.DataPropertyName = "EstaExtinta";
            estaExtintaDataGridViewCheckBoxColumn.HeaderText = "EstaExtinta";
            estaExtintaDataGridViewCheckBoxColumn.MinimumWidth = 6;
            estaExtintaDataGridViewCheckBoxColumn.Name = "estaExtintaDataGridViewCheckBoxColumn";
            estaExtintaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.FillWeight = 50F;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idRacaDataGridViewTextBoxColumn
            // 
            idRacaDataGridViewTextBoxColumn.DataPropertyName = "IdRaca";
            idRacaDataGridViewTextBoxColumn.HeaderText = "IdRaca";
            idRacaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idRacaDataGridViewTextBoxColumn.Name = "idRacaDataGridViewTextBoxColumn";
            idRacaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profissaoDataGridViewTextBoxColumn
            // 
            profissaoDataGridViewTextBoxColumn.DataPropertyName = "Profissao";
            profissaoDataGridViewTextBoxColumn.HeaderText = "Profissao";
            profissaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            profissaoDataGridViewTextBoxColumn.Name = "profissaoDataGridViewTextBoxColumn";
            profissaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idadeDataGridViewTextBoxColumn
            // 
            idadeDataGridViewTextBoxColumn.DataPropertyName = "Idade";
            idadeDataGridViewTextBoxColumn.HeaderText = "Idade";
            idadeDataGridViewTextBoxColumn.MinimumWidth = 6;
            idadeDataGridViewTextBoxColumn.Name = "idadeDataGridViewTextBoxColumn";
            idadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.MinimumWidth = 6;
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            alturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estaVivoDataGridViewCheckBoxColumn
            // 
            estaVivoDataGridViewCheckBoxColumn.DataPropertyName = "EstaVivo";
            estaVivoDataGridViewCheckBoxColumn.HeaderText = "EstaVivo";
            estaVivoDataGridViewCheckBoxColumn.MinimumWidth = 6;
            estaVivoDataGridViewCheckBoxColumn.Name = "estaVivoDataGridViewCheckBoxColumn";
            estaVivoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dataDoCadastroDataGridViewTextBoxColumn
            // 
            dataDoCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataDoCadastro";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            dataDoCadastroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            dataDoCadastroDataGridViewTextBoxColumn.HeaderText = "DataDoCadastro";
            dataDoCadastroDataGridViewTextBoxColumn.MinimumWidth = 6;
            dataDoCadastroDataGridViewTextBoxColumn.Name = "dataDoCadastroDataGridViewTextBoxColumn";
            dataDoCadastroDataGridViewTextBoxColumn.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            tabControl.ResumeLayout(false);
            tabPersonagens.ResumeLayout(false);
            tabPersonagens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridPersonagens).EndInit();
            tabRacas.ResumeLayout(false);
            tabRacas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRacas).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource personagemBindingSource;
        private Button buttonAdicionar;
        private Button button2;
        private Button button3;
        private TextBox barraDePesquisaDePersonagem;
        private RadioButton nomeRadioButton;
        private RadioButton idRadioButton;
        private DateTimePicker dateTimePicker;
        private CheckBox vivoCheckBox;
        private Button buttonReset;
        private BindingSource racaBindingSource;
        private TabControl tabControl;
        private TabPage tabPersonagens;
        private TabPage tabRacas;
        private DataGridView gridPersonagens;
        private TextBox barraDePesquisaDeRaca;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private CheckBox checkBox1;
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
    }
}
