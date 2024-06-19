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
            gridDeDados = new DataGridView();
            racaBindingSource = new BindingSource(components);
            personagemBindingSource = new BindingSource(components);
            buttonAdicionar = new Button();
            button2 = new Button();
            button3 = new Button();
            barraDePesquisa = new TextBox();
            nomeRadioButton = new RadioButton();
            idRadioButton = new RadioButton();
            dateTimePicker = new DateTimePicker();
            vivoCheckBox = new CheckBox();
            buttonReset = new Button();
            menuStrip1 = new MenuStrip();
            personagensToolStripMenuItem = new ToolStripMenuItem();
            raçasToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)gridDeDados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gridDeDados
            // 
            gridDeDados.AllowUserToAddRows = false;
            gridDeDados.AllowUserToDeleteRows = false;
            gridDeDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDeDados.BackgroundColor = SystemColors.Control;
            gridDeDados.BorderStyle = BorderStyle.None;
            gridDeDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            gridDeDados.DefaultCellStyle = dataGridViewCellStyle1;
            gridDeDados.Location = new Point(14, 68);
            gridDeDados.Margin = new Padding(3, 4, 3, 4);
            gridDeDados.Name = "gridDeDados";
            gridDeDados.ReadOnly = true;
            gridDeDados.RowHeadersWidth = 51;
            gridDeDados.RowTemplate.Height = 25;
            gridDeDados.Size = new Size(1058, 481);
            gridDeDados.TabIndex = 0;
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
            // barraDePesquisa
            // 
            barraDePesquisa.Location = new Point(14, 32);
            barraDePesquisa.Margin = new Padding(3, 4, 3, 4);
            barraDePesquisa.Multiline = true;
            barraDePesquisa.Name = "barraDePesquisa";
            barraDePesquisa.PlaceholderText = "Pesquise o personagem...";
            barraDePesquisa.Size = new Size(575, 29);
            barraDePesquisa.TabIndex = 4;
            barraDePesquisa.TextChanged += AoDigitarNaBarraDePesquisaDeveListarOsItensCorrespondentesAPesquisa;
            barraDePesquisa.Enter += AoEntrarNaBarraDePesquisaDeveLimparOPlaceholder;
            barraDePesquisa.Leave += AoSairDaBarraDePesquisaDeveAdicionarOPlaceholder;
            // 
            // nomeRadioButton
            // 
            nomeRadioButton.AutoSize = true;
            nomeRadioButton.Checked = true;
            nomeRadioButton.Location = new Point(597, 34);
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
            idRadioButton.Location = new Point(670, 35);
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
            dateTimePicker.Location = new Point(781, 34);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(291, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // vivoCheckBox
            // 
            vivoCheckBox.AutoSize = true;
            vivoCheckBox.Location = new Point(717, 36);
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { personagensToolStripMenuItem, raçasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1084, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // personagensToolStripMenuItem
            // 
            personagensToolStripMenuItem.Name = "personagensToolStripMenuItem";
            personagensToolStripMenuItem.Size = new Size(105, 24);
            personagensToolStripMenuItem.Text = "Personagens";
            personagensToolStripMenuItem.Click += AoClicarNoMenuDePersonagensDeveListarTodasOsPersonagensNoDataGrid;
            // 
            // raçasToolStripMenuItem
            // 
            raçasToolStripMenuItem.Name = "raçasToolStripMenuItem";
            raçasToolStripMenuItem.Size = new Size(61, 24);
            raçasToolStripMenuItem.Text = "Raças";
            raçasToolStripMenuItem.Click += AoClicarNoMenuDeRacasDeveListarTodasAsRacasNoDataGrid;
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
            Controls.Add(gridDeDados);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "O Senhor dos Anéis DB";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridDeDados).EndInit();
            ((System.ComponentModel.ISupportInitialize)racaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridDeDados;
        private BindingSource personagemBindingSource;
        private Button buttonAdicionar;
        private Button button2;
        private Button button3;
        private TextBox barraDePesquisa;
        private RadioButton nomeRadioButton;
        private RadioButton idRadioButton;
        private DateTimePicker dateTimePicker;
        private CheckBox vivoCheckBox;
        private Button buttonReset;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem personagensToolStripMenuItem;
        private ToolStripMenuItem raçasToolStripMenuItem;
        private BindingSource racaBindingSource;
    }
}
