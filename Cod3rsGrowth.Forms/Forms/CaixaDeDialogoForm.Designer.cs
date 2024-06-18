namespace Forms.Forms
{
    partial class CaixaDeDialogoForm
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
            okButton = new Button();
            labelTextoErro = new Label();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Location = new Point(363, 78);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 0;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // labelTextoErro
            // 
            labelTextoErro.Dock = DockStyle.Fill;
            labelTextoErro.Location = new Point(0, 0);
            labelTextoErro.Name = "labelTextoErro";
            labelTextoErro.Size = new Size(823, 119);
            labelTextoErro.TabIndex = 1;
            labelTextoErro.Text = "Deve ser informado um erro onde voce precisa reparar um campo ou uma propriedade a ser preenchida";
            labelTextoErro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CaixaDeDialogoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 119);
            Controls.Add(okButton);
            Controls.Add(labelTextoErro);
            MaximizeBox = false;
            Name = "CaixaDeDialogoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CaixaDeDialogoForm";
            ResumeLayout(false);
        }

        #endregion

        private Button okButton;
        private Label labelTextoErro;
    }
}