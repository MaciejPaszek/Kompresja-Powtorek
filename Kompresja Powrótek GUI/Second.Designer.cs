namespace Kompresja_Powrótek_GUI
{
    partial class Second
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInputFolder = new System.Windows.Forms.TextBox();
            this.groupBoxFolders = new System.Windows.Forms.GroupBox();
            this.buttonOutputFolder = new System.Windows.Forms.Button();
            this.textBoxOutputFolder = new System.Windows.Forms.TextBox();
            this.labelOutputFolder = new System.Windows.Forms.Label();
            this.buttonInputFolder = new System.Windows.Forms.Button();
            this.labelInputFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxFolders.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxInputFolder
            // 
            this.textBoxInputFolder.Location = new System.Drawing.Point(98, 32);
            this.textBoxInputFolder.Name = "textBoxInputFolder";
            this.textBoxInputFolder.Size = new System.Drawing.Size(368, 20);
            this.textBoxInputFolder.TabIndex = 0;
            // 
            // groupBoxFolders
            // 
            this.groupBoxFolders.Controls.Add(this.buttonOutputFolder);
            this.groupBoxFolders.Controls.Add(this.textBoxOutputFolder);
            this.groupBoxFolders.Controls.Add(this.labelOutputFolder);
            this.groupBoxFolders.Controls.Add(this.buttonInputFolder);
            this.groupBoxFolders.Controls.Add(this.labelInputFolder);
            this.groupBoxFolders.Controls.Add(this.textBoxInputFolder);
            this.groupBoxFolders.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFolders.Name = "groupBoxFolders";
            this.groupBoxFolders.Size = new System.Drawing.Size(758, 151);
            this.groupBoxFolders.TabIndex = 1;
            this.groupBoxFolders.TabStop = false;
            this.groupBoxFolders.Text = "Pliki";
            // 
            // buttonOutputFolder
            // 
            this.buttonOutputFolder.Location = new System.Drawing.Point(484, 70);
            this.buttonOutputFolder.Name = "buttonOutputFolder";
            this.buttonOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOutputFolder.TabIndex = 6;
            this.buttonOutputFolder.Text = "...";
            this.buttonOutputFolder.UseVisualStyleBackColor = true;
            // 
            // textBoxOutputFolder
            // 
            this.textBoxOutputFolder.Location = new System.Drawing.Point(98, 70);
            this.textBoxOutputFolder.Name = "textBoxOutputFolder";
            this.textBoxOutputFolder.Size = new System.Drawing.Size(368, 20);
            this.textBoxOutputFolder.TabIndex = 5;
            // 
            // labelOutputFolder
            // 
            this.labelOutputFolder.AutoSize = true;
            this.labelOutputFolder.Location = new System.Drawing.Point(6, 73);
            this.labelOutputFolder.Name = "labelOutputFolder";
            this.labelOutputFolder.Size = new System.Drawing.Size(86, 13);
            this.labelOutputFolder.TabIndex = 4;
            this.labelOutputFolder.Text = "Folder wyjściowy";
            // 
            // buttonInputFolder
            // 
            this.buttonInputFolder.Location = new System.Drawing.Point(484, 32);
            this.buttonInputFolder.Name = "buttonInputFolder";
            this.buttonInputFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonInputFolder.TabIndex = 3;
            this.buttonInputFolder.Text = "...";
            this.buttonInputFolder.UseVisualStyleBackColor = true;
            this.buttonInputFolder.Click += new System.EventHandler(this.buttonInputFolder_Click);
            // 
            // labelInputFolder
            // 
            this.labelInputFolder.AutoSize = true;
            this.labelInputFolder.Location = new System.Drawing.Point(6, 35);
            this.labelInputFolder.Name = "labelInputFolder";
            this.labelInputFolder.Size = new System.Drawing.Size(87, 13);
            this.labelInputFolder.TabIndex = 2;
            this.labelInputFolder.Text = "Folder wejściowy";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.comboBoxResolution);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(110, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video";
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Location = new System.Drawing.Point(113, 12);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(121, 21);
            this.comboBoxResolution.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Rozdzielczość";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "FPS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Rozdzielczość";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFolders);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxFolders.ResumeLayout(false);
            this.groupBoxFolders.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInputFolder;
        private System.Windows.Forms.GroupBox groupBoxFolders;
        private System.Windows.Forms.Button buttonInputFolder;
        private System.Windows.Forms.Label labelInputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonOutputFolder;
        private System.Windows.Forms.TextBox textBoxOutputFolder;
        private System.Windows.Forms.Label labelOutputFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

