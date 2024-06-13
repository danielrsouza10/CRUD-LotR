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
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idRacaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profissaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estaVivoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataDoCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            personagemBindingSource2 = new BindingSource(components);
            personagemBindingSource1 = new BindingSource(components);
            personagemBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, idRacaDataGridViewTextBoxColumn, profissaoDataGridViewTextBoxColumn, idadeDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, estaVivoDataGridViewCheckBoxColumn, dataDoCadastroDataGridViewTextBoxColumn });
            dataGridView1.DataSource = personagemBindingSource2;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(791, 400);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // idRacaDataGridViewTextBoxColumn
            // 
            idRacaDataGridViewTextBoxColumn.DataPropertyName = "IdRaca";
            idRacaDataGridViewTextBoxColumn.HeaderText = "IdRaca";
            idRacaDataGridViewTextBoxColumn.Name = "idRacaDataGridViewTextBoxColumn";
            // 
            // profissaoDataGridViewTextBoxColumn
            // 
            profissaoDataGridViewTextBoxColumn.DataPropertyName = "Profissao";
            profissaoDataGridViewTextBoxColumn.HeaderText = "Profissao";
            profissaoDataGridViewTextBoxColumn.Name = "profissaoDataGridViewTextBoxColumn";
            // 
            // idadeDataGridViewTextBoxColumn
            // 
            idadeDataGridViewTextBoxColumn.DataPropertyName = "Idade";
            idadeDataGridViewTextBoxColumn.HeaderText = "Idade";
            idadeDataGridViewTextBoxColumn.Name = "idadeDataGridViewTextBoxColumn";
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            // 
            // estaVivoDataGridViewCheckBoxColumn
            // 
            estaVivoDataGridViewCheckBoxColumn.DataPropertyName = "EstaVivo";
            estaVivoDataGridViewCheckBoxColumn.HeaderText = "EstaVivo";
            estaVivoDataGridViewCheckBoxColumn.Name = "estaVivoDataGridViewCheckBoxColumn";
            // 
            // dataDoCadastroDataGridViewTextBoxColumn
            // 
            dataDoCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataDoCadastro";
            dataDoCadastroDataGridViewTextBoxColumn.HeaderText = "DataDoCadastro";
            dataDoCadastroDataGridViewTextBoxColumn.Name = "dataDoCadastroDataGridViewTextBoxColumn";
            // 
            // personagemBindingSource2
            // 
            personagemBindingSource2.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // personagemBindingSource1
            // 
            personagemBindingSource1.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // personagemBindingSource
            // 
            personagemBindingSource.DataSource = typeof(Dominio.Modelos.Personagem);
            // 
            // button1
            // 
            button1.Location = new Point(566, 418);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(647, 418);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(728, 418);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idRacaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profissaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estaVivoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataDoCadastroDataGridViewTextBoxColumn;
        private BindingSource personagemBindingSource;
        private Button button1;
        private Button button2;
        private Button button3;
        private BindingSource personagemBindingSource1;
        private BindingSource personagemBindingSource2;
    }
}
