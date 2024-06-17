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
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, idRacaDataGridViewTextBoxColumn, profissaoDataGridViewTextBoxColumn, idadeDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, estaVivoDataGridViewCheckBoxColumn, dataDoCadastroDataGridViewTextBoxColumn });
            dataGridView1.DataSource = personagemBindingSource;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle18;
            dataGridView1.Location = new Point(12, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(915, 372);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            nomeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // idRacaDataGridViewTextBoxColumn
            // 
            idRacaDataGridViewTextBoxColumn.DataPropertyName = "IdRaca";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idRacaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            idRacaDataGridViewTextBoxColumn.HeaderText = "IdRaca";
            idRacaDataGridViewTextBoxColumn.Name = "idRacaDataGridViewTextBoxColumn";
            // 
            // profissaoDataGridViewTextBoxColumn
            // 
            profissaoDataGridViewTextBoxColumn.DataPropertyName = "Profissao";
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            profissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            profissaoDataGridViewTextBoxColumn.HeaderText = "Profissao";
            profissaoDataGridViewTextBoxColumn.Name = "profissaoDataGridViewTextBoxColumn";
            // 
            // idadeDataGridViewTextBoxColumn
            // 
            idadeDataGridViewTextBoxColumn.DataPropertyName = "Idade";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            idadeDataGridViewTextBoxColumn.HeaderText = "Idade";
            idadeDataGridViewTextBoxColumn.Name = "idadeDataGridViewTextBoxColumn";
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            alturaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            // 
            // estaVivoDataGridViewCheckBoxColumn
            // 
            estaVivoDataGridViewCheckBoxColumn.DataPropertyName = "EstaVivo";
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            estaVivoDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            estaVivoDataGridViewCheckBoxColumn.HeaderText = "EstaVivo";
            estaVivoDataGridViewCheckBoxColumn.Name = "estaVivoDataGridViewCheckBoxColumn";
            estaVivoDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.True;
            estaVivoDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataDoCadastroDataGridViewTextBoxColumn
            // 
            dataDoCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataDoCadastro";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Format = "d";
            dataGridViewCellStyle17.NullValue = null;
            dataDoCadastroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            dataDoCadastroDataGridViewTextBoxColumn.HeaderText = "DataDoCadastro";
            dataDoCadastroDataGridViewTextBoxColumn.Name = "dataDoCadastroDataGridViewTextBoxColumn";
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
            buttonAdicionar.Location = new Point(690, 418);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(75, 23);
            buttonAdicionar.TabIndex = 1;
            buttonAdicionar.Text = "Adicionar";
            buttonAdicionar.UseVisualStyleBackColor = true;
            buttonAdicionar.Click += buttonAdicionar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(771, 418);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(852, 418);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // barraDePesquisa
            // 
            barraDePesquisa.Location = new Point(12, 10);
            barraDePesquisa.Multiline = true;
            barraDePesquisa.Name = "barraDePesquisa";
            barraDePesquisa.PlaceholderText = "Pesquise o personagem...";
            barraDePesquisa.Size = new Size(504, 23);
            barraDePesquisa.TabIndex = 4;
            barraDePesquisa.TextChanged += barraDePesquisa_TextChanged;
            barraDePesquisa.Enter += barraDePesquisa_Enter;
            barraDePesquisa.Leave += barraDePesquisa_Leave;
            // 
            // nomeRadioButton
            // 
            nomeRadioButton.AutoSize = true;
            nomeRadioButton.Checked = true;
            nomeRadioButton.Location = new Point(522, 11);
            nomeRadioButton.Name = "nomeRadioButton";
            nomeRadioButton.Size = new Size(58, 19);
            nomeRadioButton.TabIndex = 5;
            nomeRadioButton.TabStop = true;
            nomeRadioButton.Text = "Nome";
            nomeRadioButton.UseVisualStyleBackColor = true;
            nomeRadioButton.CheckedChanged += nomeRadioButton_CheckedChanged;
            // 
            // idRadioButton
            // 
            idRadioButton.AutoSize = true;
            idRadioButton.Location = new Point(586, 12);
            idRadioButton.Name = "idRadioButton";
            idRadioButton.Size = new Size(35, 19);
            idRadioButton.TabIndex = 6;
            idRadioButton.TabStop = true;
            idRadioButton.Text = "Id";
            idRadioButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(683, 10);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(244, 23);
            dateTimePicker.TabIndex = 7;
            // 
            // vivoCheckBox
            // 
            vivoCheckBox.AutoSize = true;
            vivoCheckBox.Location = new Point(627, 13);
            vivoCheckBox.Name = "vivoCheckBox";
            vivoCheckBox.Size = new Size(49, 19);
            vivoCheckBox.TabIndex = 8;
            vivoCheckBox.Text = "Vivo";
            vivoCheckBox.UseVisualStyleBackColor = true;
            vivoCheckBox.CheckedChanged += vivoCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(939, 450);
            Controls.Add(vivoCheckBox);
            Controls.Add(dateTimePicker);
            Controls.Add(idRadioButton);
            Controls.Add(nomeRadioButton);
            Controls.Add(barraDePesquisa);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(buttonAdicionar);
            Controls.Add(dataGridView1);
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
    }
}
