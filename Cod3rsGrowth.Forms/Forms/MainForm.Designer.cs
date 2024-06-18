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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idRacaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profissaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estaVivoDataGridViewCheckBoxColumn = new DataGridViewTextBoxColumn();
            dataDoCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            personagemBindingSource = new BindingSource(components);
            personagemBindingSource2 = new BindingSource(components);
            personagemBindingSource1 = new BindingSource(components);
            buttonAdicionar = new Button();
            button2 = new Button();
            button3 = new Button();
            barraDePesquisa = new TextBox();
            nomeRadioButton = new RadioButton();
            idRadioButton = new RadioButton();
            dateTimePicker = new DateTimePicker();
            vivoCheckBox = new CheckBox();
            buttonReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, idRacaDataGridViewTextBoxColumn, profissaoDataGridViewTextBoxColumn, idadeDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, estaVivoDataGridViewCheckBoxColumn, dataDoCadastroDataGridViewTextBoxColumn });
            dataGridView1.DataSource = personagemBindingSource;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.Location = new Point(14, 53);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1058, 496);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nomeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // idRacaDataGridViewTextBoxColumn
            // 
            idRacaDataGridViewTextBoxColumn.DataPropertyName = "IdRaca";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idRacaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            idRacaDataGridViewTextBoxColumn.HeaderText = "IdRaca";
            idRacaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idRacaDataGridViewTextBoxColumn.Name = "idRacaDataGridViewTextBoxColumn";
            idRacaDataGridViewTextBoxColumn.Width = 125;
            // 
            // profissaoDataGridViewTextBoxColumn
            // 
            profissaoDataGridViewTextBoxColumn.DataPropertyName = "Profissao";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            profissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            profissaoDataGridViewTextBoxColumn.HeaderText = "Profissao";
            profissaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            profissaoDataGridViewTextBoxColumn.Name = "profissaoDataGridViewTextBoxColumn";
            profissaoDataGridViewTextBoxColumn.Width = 125;
            // 
            // idadeDataGridViewTextBoxColumn
            // 
            idadeDataGridViewTextBoxColumn.DataPropertyName = "Idade";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            idadeDataGridViewTextBoxColumn.HeaderText = "Idade";
            idadeDataGridViewTextBoxColumn.MinimumWidth = 6;
            idadeDataGridViewTextBoxColumn.Name = "idadeDataGridViewTextBoxColumn";
            idadeDataGridViewTextBoxColumn.Width = 125;
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            alturaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.MinimumWidth = 6;
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            alturaDataGridViewTextBoxColumn.Width = 125;
            // 
            // estaVivoDataGridViewCheckBoxColumn
            // 
            estaVivoDataGridViewCheckBoxColumn.DataPropertyName = "EstaVivo";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            estaVivoDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            estaVivoDataGridViewCheckBoxColumn.HeaderText = "EstaVivo";
            estaVivoDataGridViewCheckBoxColumn.MinimumWidth = 6;
            estaVivoDataGridViewCheckBoxColumn.Name = "estaVivoDataGridViewCheckBoxColumn";
            estaVivoDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.True;
            estaVivoDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            estaVivoDataGridViewCheckBoxColumn.Width = 125;
            // 
            // dataDoCadastroDataGridViewTextBoxColumn
            // 
            dataDoCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataDoCadastro";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            dataDoCadastroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            dataDoCadastroDataGridViewTextBoxColumn.HeaderText = "DataDoCadastro";
            dataDoCadastroDataGridViewTextBoxColumn.MinimumWidth = 6;
            dataDoCadastroDataGridViewTextBoxColumn.Name = "dataDoCadastroDataGridViewTextBoxColumn";
            dataDoCadastroDataGridViewTextBoxColumn.Width = 125;
            // 
            // personagemBindingSource
            // 
            personagemBindingSource.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // personagemBindingSource2
            // 
            personagemBindingSource2.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // personagemBindingSource1
            // 
            personagemBindingSource1.DataSource = typeof(Dominio.Modelos.Personagem);
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
            buttonAdicionar.Click += buttonAdicionar_Click;
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
            // 
            // barraDePesquisa
            // 
            barraDePesquisa.Location = new Point(14, 13);
            barraDePesquisa.Margin = new Padding(3, 4, 3, 4);
            barraDePesquisa.Multiline = true;
            barraDePesquisa.Name = "barraDePesquisa";
            barraDePesquisa.PlaceholderText = "Pesquise o personagem...";
            barraDePesquisa.Size = new Size(575, 29);
            barraDePesquisa.TabIndex = 4;
            barraDePesquisa.TextChanged += barraDePesquisa_TextChanged;
            barraDePesquisa.Enter += barraDePesquisa_Enter;
            barraDePesquisa.Leave += barraDePesquisa_Leave;
            // 
            // nomeRadioButton
            // 
            nomeRadioButton.AutoSize = true;
            nomeRadioButton.Checked = true;
            nomeRadioButton.Location = new Point(597, 15);
            nomeRadioButton.Margin = new Padding(3, 4, 3, 4);
            nomeRadioButton.Name = "nomeRadioButton";
            nomeRadioButton.Size = new Size(71, 24);
            nomeRadioButton.TabIndex = 5;
            nomeRadioButton.TabStop = true;
            nomeRadioButton.Text = "Nome";
            nomeRadioButton.UseVisualStyleBackColor = true;
            nomeRadioButton.CheckedChanged += nomeRadioButton_CheckedChanged;
            // 
            // idRadioButton
            // 
            idRadioButton.AutoSize = true;
            idRadioButton.Location = new Point(670, 16);
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
            dateTimePicker.Location = new Point(781, 13);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(291, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // vivoCheckBox
            // 
            vivoCheckBox.AutoSize = true;
            vivoCheckBox.Location = new Point(717, 17);
            vivoCheckBox.Margin = new Padding(3, 4, 3, 4);
            vivoCheckBox.Name = "vivoCheckBox";
            vivoCheckBox.Size = new Size(60, 24);
            vivoCheckBox.TabIndex = 8;
            vivoCheckBox.Text = "Vivo";
            vivoCheckBox.UseVisualStyleBackColor = true;
            vivoCheckBox.CheckedChanged += vivoCheckBox_CheckedChanged;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(12, 556);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(94, 29);
            buttonReset.TabIndex = 9;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1084, 600);
            Controls.Add(buttonReset);
            Controls.Add(vivoCheckBox);
            Controls.Add(dateTimePicker);
            Controls.Add(idRadioButton);
            Controls.Add(nomeRadioButton);
            Controls.Add(barraDePesquisa);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(buttonAdicionar);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "O Senhor dos Anéis DB";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource personagemBindingSource;
        private Button buttonAdicionar;
        private Button button2;
        private Button button3;
        private BindingSource personagemBindingSource1;
        private BindingSource personagemBindingSource2;
        private TextBox barraDePesquisa;
        private RadioButton nomeRadioButton;
        private RadioButton idRadioButton;
        private DateTimePicker dateTimePicker;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idRacaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profissaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estaVivoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataDoCadastroDataGridViewTextBoxColumn;
        private CheckBox vivoCheckBox;
        private Button buttonReset;
    }
}
