namespace Kompresja_Powtórek_GUI
{
    partial class Form1
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
            groupBoxCompresionSettings = new GroupBox();
            tableLayoutPanelSettings = new TableLayoutPanel();
            labelInputFolder = new Label();
            comboBoxEncoder = new ComboBox();
            buttonOutputFolder = new Button();
            buttonInputFolder = new Button();
            labelResolution = new Label();
            label1 = new Label();
            comboBoxFrameRate = new ComboBox();
            labelFrameRate = new Label();
            textBoxInputFolder = new TextBox();
            textBoxOutputFolder = new TextBox();
            labelOutputFolder = new Label();
            comboBoxResolution = new ComboBox();
            buttonActivate = new Button();
            comboBoxColorMode = new ComboBox();
            groupBoxOutput = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxThumbnail = new PictureBox();
            progressBarOutput = new ProgressBar();
            labelFileName = new Label();
            tableLayoutPanelMain = new TableLayoutPanel();
            groupBoxApplicationSettings = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelColorMode = new Label();
            labelFontSize = new Label();
            numericUpDownFontSize = new NumericUpDown();
            splitContainerOutput = new SplitContainer();
            groupBox1 = new GroupBox();
            richTextBoxConsole = new RichTextBox();
            groupBoxCompresionSettings.SuspendLayout();
            tableLayoutPanelSettings.SuspendLayout();
            groupBoxOutput.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).BeginInit();
            tableLayoutPanelMain.SuspendLayout();
            groupBoxApplicationSettings.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerOutput).BeginInit();
            splitContainerOutput.Panel1.SuspendLayout();
            splitContainerOutput.Panel2.SuspendLayout();
            splitContainerOutput.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxCompresionSettings
            // 
            groupBoxCompresionSettings.AutoSize = true;
            groupBoxCompresionSettings.Controls.Add(tableLayoutPanelSettings);
            groupBoxCompresionSettings.Dock = DockStyle.Fill;
            groupBoxCompresionSettings.Location = new Point(10, 100);
            groupBoxCompresionSettings.Margin = new Padding(10, 5, 10, 10);
            groupBoxCompresionSettings.MinimumSize = new Size(350, 0);
            groupBoxCompresionSettings.Name = "groupBoxCompresionSettings";
            groupBoxCompresionSettings.Size = new Size(364, 167);
            groupBoxCompresionSettings.TabIndex = 0;
            groupBoxCompresionSettings.TabStop = false;
            groupBoxCompresionSettings.Text = "Ustawienia Kompresji";
            // 
            // tableLayoutPanelSettings
            // 
            tableLayoutPanelSettings.AutoSize = true;
            tableLayoutPanelSettings.ColumnCount = 3;
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSettings.Controls.Add(labelInputFolder, 0, 0);
            tableLayoutPanelSettings.Controls.Add(comboBoxEncoder, 1, 4);
            tableLayoutPanelSettings.Controls.Add(buttonOutputFolder, 2, 1);
            tableLayoutPanelSettings.Controls.Add(buttonInputFolder, 2, 0);
            tableLayoutPanelSettings.Controls.Add(labelResolution, 0, 2);
            tableLayoutPanelSettings.Controls.Add(label1, 0, 4);
            tableLayoutPanelSettings.Controls.Add(comboBoxFrameRate, 1, 3);
            tableLayoutPanelSettings.Controls.Add(labelFrameRate, 0, 3);
            tableLayoutPanelSettings.Controls.Add(textBoxInputFolder, 1, 0);
            tableLayoutPanelSettings.Controls.Add(textBoxOutputFolder, 1, 1);
            tableLayoutPanelSettings.Controls.Add(labelOutputFolder, 0, 1);
            tableLayoutPanelSettings.Controls.Add(comboBoxResolution, 1, 2);
            tableLayoutPanelSettings.Controls.Add(buttonActivate, 2, 4);
            tableLayoutPanelSettings.Dock = DockStyle.Fill;
            tableLayoutPanelSettings.Location = new Point(3, 19);
            tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
            tableLayoutPanelSettings.RowCount = 5;
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle());
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle());
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle());
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle());
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle());
            tableLayoutPanelSettings.Size = new Size(358, 145);
            tableLayoutPanelSettings.TabIndex = 8;
            // 
            // labelInputFolder
            // 
            labelInputFolder.AutoSize = true;
            labelInputFolder.Dock = DockStyle.Top;
            labelInputFolder.Location = new Point(3, 5);
            labelInputFolder.Margin = new Padding(3, 5, 3, 3);
            labelInputFolder.Name = "labelInputFolder";
            labelInputFolder.Size = new Size(97, 15);
            labelInputFolder.TabIndex = 0;
            labelInputFolder.Text = "Folder wejściowy";
            // 
            // comboBoxEncoder
            // 
            comboBoxEncoder.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoder.FormattingEnabled = true;
            comboBoxEncoder.Items.AddRange(new object[] { "CPU", "GPU" });
            comboBoxEncoder.Location = new Point(106, 119);
            comboBoxEncoder.Name = "comboBoxEncoder";
            comboBoxEncoder.Size = new Size(121, 23);
            comboBoxEncoder.TabIndex = 7;
            comboBoxEncoder.SelectedIndexChanged += comboBoxEncoder_SelectedIndexChanged;
            // 
            // buttonOutputFolder
            // 
            buttonOutputFolder.Dock = DockStyle.Fill;
            buttonOutputFolder.Location = new Point(261, 32);
            buttonOutputFolder.Name = "buttonOutputFolder";
            buttonOutputFolder.Size = new Size(94, 23);
            buttonOutputFolder.TabIndex = 6;
            buttonOutputFolder.Text = "...";
            buttonOutputFolder.UseVisualStyleBackColor = true;
            buttonOutputFolder.Click += buttonFolder_Click;
            // 
            // buttonInputFolder
            // 
            buttonInputFolder.Dock = DockStyle.Fill;
            buttonInputFolder.Location = new Point(261, 3);
            buttonInputFolder.Name = "buttonInputFolder";
            buttonInputFolder.Size = new Size(94, 23);
            buttonInputFolder.TabIndex = 5;
            buttonInputFolder.Text = "...";
            buttonInputFolder.UseVisualStyleBackColor = true;
            buttonInputFolder.Click += buttonFolder_Click;
            // 
            // labelResolution
            // 
            labelResolution.AutoSize = true;
            labelResolution.Location = new Point(3, 63);
            labelResolution.Margin = new Padding(3, 5, 3, 3);
            labelResolution.Name = "labelResolution";
            labelResolution.Size = new Size(79, 15);
            labelResolution.TabIndex = 0;
            labelResolution.Text = "Rozdzielczość";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 121);
            label1.Margin = new Padding(3, 5, 3, 3);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 6;
            label1.Text = "Enkoder";
            // 
            // comboBoxFrameRate
            // 
            comboBoxFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFrameRate.FormattingEnabled = true;
            comboBoxFrameRate.Items.AddRange(new object[] { "24", "30", "60" });
            comboBoxFrameRate.Location = new Point(106, 90);
            comboBoxFrameRate.Name = "comboBoxFrameRate";
            comboBoxFrameRate.Size = new Size(121, 23);
            comboBoxFrameRate.TabIndex = 4;
            comboBoxFrameRate.SelectedIndexChanged += comboBoxFrameRate_SelectedIndexChanged;
            // 
            // labelFrameRate
            // 
            labelFrameRate.AutoSize = true;
            labelFrameRate.Dock = DockStyle.Top;
            labelFrameRate.Location = new Point(3, 92);
            labelFrameRate.Margin = new Padding(3, 5, 3, 3);
            labelFrameRate.Name = "labelFrameRate";
            labelFrameRate.Size = new Size(97, 15);
            labelFrameRate.TabIndex = 3;
            labelFrameRate.Text = "FPS";
            // 
            // textBoxInputFolder
            // 
            textBoxInputFolder.Dock = DockStyle.Top;
            textBoxInputFolder.Location = new Point(106, 3);
            textBoxInputFolder.Name = "textBoxInputFolder";
            textBoxInputFolder.Size = new Size(149, 23);
            textBoxInputFolder.TabIndex = 3;
            // 
            // textBoxOutputFolder
            // 
            textBoxOutputFolder.Dock = DockStyle.Top;
            textBoxOutputFolder.Location = new Point(106, 32);
            textBoxOutputFolder.Name = "textBoxOutputFolder";
            textBoxOutputFolder.Size = new Size(149, 23);
            textBoxOutputFolder.TabIndex = 4;
            textBoxOutputFolder.TextChanged += textBoxOutputFolder_TextChanged;
            // 
            // labelOutputFolder
            // 
            labelOutputFolder.AutoSize = true;
            labelOutputFolder.Dock = DockStyle.Top;
            labelOutputFolder.Location = new Point(3, 34);
            labelOutputFolder.Margin = new Padding(3, 5, 3, 3);
            labelOutputFolder.Name = "labelOutputFolder";
            labelOutputFolder.Size = new Size(97, 15);
            labelOutputFolder.TabIndex = 1;
            labelOutputFolder.Text = "Folder wyjściowy";
            // 
            // comboBoxResolution
            // 
            comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxResolution.FormattingEnabled = true;
            comboBoxResolution.Items.AddRange(new object[] { "144p", "240p", "360p", "480p", "720p" });
            comboBoxResolution.Location = new Point(106, 61);
            comboBoxResolution.Name = "comboBoxResolution";
            comboBoxResolution.Size = new Size(121, 23);
            comboBoxResolution.TabIndex = 1;
            comboBoxResolution.SelectedIndexChanged += comboBoxResolution_SelectedIndexChanged;
            // 
            // buttonActivate
            // 
            buttonActivate.Dock = DockStyle.Fill;
            buttonActivate.Location = new Point(261, 119);
            buttonActivate.Name = "buttonActivate";
            buttonActivate.Size = new Size(94, 23);
            buttonActivate.TabIndex = 7;
            buttonActivate.Text = "Rozpocznij";
            buttonActivate.UseVisualStyleBackColor = true;
            buttonActivate.Click += buttonActivate_Click;
            // 
            // comboBoxColorMode
            // 
            comboBoxColorMode.AutoCompleteCustomSource.AddRange(new string[] { "Jasny", "Ciemny" });
            comboBoxColorMode.FormattingEnabled = true;
            comboBoxColorMode.Items.AddRange(new object[] { "Jasny", "Ciemny", "Systemowy" });
            comboBoxColorMode.Location = new Point(129, 3);
            comboBoxColorMode.Name = "comboBoxColorMode";
            comboBoxColorMode.Size = new Size(121, 23);
            comboBoxColorMode.TabIndex = 8;
            comboBoxColorMode.SelectedIndexChanged += comboBoxColorMode_SelectedIndexChanged;
            // 
            // groupBoxOutput
            // 
            groupBoxOutput.Controls.Add(tableLayoutPanel1);
            groupBoxOutput.Dock = DockStyle.Fill;
            groupBoxOutput.Location = new Point(0, 0);
            groupBoxOutput.Margin = new Padding(10, 5, 10, 10);
            groupBoxOutput.Name = "groupBoxOutput";
            groupBoxOutput.Size = new Size(364, 259);
            groupBoxOutput.TabIndex = 1;
            groupBoxOutput.TabStop = false;
            groupBoxOutput.Text = "Podgląd";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBoxThumbnail, 0, 0);
            tableLayoutPanel1.Controls.Add(progressBarOutput, 0, 2);
            tableLayoutPanel1.Controls.Add(labelFileName, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(358, 237);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBoxThumbnail
            // 
            pictureBoxThumbnail.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxThumbnail.Dock = DockStyle.Fill;
            pictureBoxThumbnail.Location = new Point(3, 3);
            pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            pictureBoxThumbnail.Size = new Size(352, 187);
            pictureBoxThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxThumbnail.TabIndex = 0;
            pictureBoxThumbnail.TabStop = false;
            // 
            // progressBarOutput
            // 
            progressBarOutput.Dock = DockStyle.Top;
            progressBarOutput.Location = new Point(3, 211);
            progressBarOutput.Name = "progressBarOutput";
            progressBarOutput.Size = new Size(352, 23);
            progressBarOutput.TabIndex = 1;
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Dock = DockStyle.Top;
            labelFileName.Location = new Point(3, 193);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(352, 15);
            labelFileName.TabIndex = 2;
            labelFileName.Text = "Nazwa pliku";
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(groupBoxApplicationSettings, 0, 0);
            tableLayoutPanelMain.Controls.Add(groupBoxCompresionSettings, 0, 1);
            tableLayoutPanelMain.Controls.Add(splitContainerOutput, 0, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Margin = new Padding(0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanelMain.Size = new Size(384, 634);
            tableLayoutPanelMain.TabIndex = 2;
            // 
            // groupBoxApplicationSettings
            // 
            groupBoxApplicationSettings.AutoSize = true;
            groupBoxApplicationSettings.Controls.Add(tableLayoutPanel2);
            groupBoxApplicationSettings.Dock = DockStyle.Fill;
            groupBoxApplicationSettings.Location = new Point(10, 5);
            groupBoxApplicationSettings.Margin = new Padding(10, 5, 10, 10);
            groupBoxApplicationSettings.MinimumSize = new Size(350, 0);
            groupBoxApplicationSettings.Name = "groupBoxApplicationSettings";
            groupBoxApplicationSettings.Size = new Size(364, 80);
            groupBoxApplicationSettings.TabIndex = 2;
            groupBoxApplicationSettings.TabStop = false;
            groupBoxApplicationSettings.Text = "Ustawienia Aplikacji";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(labelColorMode, 0, 0);
            tableLayoutPanel2.Controls.Add(comboBoxColorMode, 1, 0);
            tableLayoutPanel2.Controls.Add(labelFontSize, 0, 1);
            tableLayoutPanel2.Controls.Add(numericUpDownFontSize, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(358, 58);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // labelColorMode
            // 
            labelColorMode.AutoSize = true;
            labelColorMode.Dock = DockStyle.Top;
            labelColorMode.Location = new Point(3, 5);
            labelColorMode.Margin = new Padding(3, 5, 3, 0);
            labelColorMode.Name = "labelColorMode";
            labelColorMode.Size = new Size(120, 15);
            labelColorMode.TabIndex = 9;
            labelColorMode.Text = "Tryb kolorów";
            // 
            // labelFontSize
            // 
            labelFontSize.AutoSize = true;
            labelFontSize.Dock = DockStyle.Top;
            labelFontSize.Location = new Point(3, 34);
            labelFontSize.Margin = new Padding(3, 5, 3, 0);
            labelFontSize.Name = "labelFontSize";
            labelFontSize.Size = new Size(120, 15);
            labelFontSize.TabIndex = 10;
            labelFontSize.Text = "Rozmiar czcionki listy";
            // 
            // numericUpDownFontSize
            // 
            numericUpDownFontSize.Location = new Point(129, 32);
            numericUpDownFontSize.Maximum = new decimal(new int[] { 36, 0, 0, 0 });
            numericUpDownFontSize.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownFontSize.Name = "numericUpDownFontSize";
            numericUpDownFontSize.Size = new Size(120, 23);
            numericUpDownFontSize.TabIndex = 11;
            numericUpDownFontSize.Value = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDownFontSize.ValueChanged += numericUpDownFontSize_ValueChanged;
            // 
            // splitContainerOutput
            // 
            splitContainerOutput.Dock = DockStyle.Fill;
            splitContainerOutput.FixedPanel = FixedPanel.Panel2;
            splitContainerOutput.Location = new Point(10, 282);
            splitContainerOutput.Margin = new Padding(10, 5, 10, 10);
            splitContainerOutput.Name = "splitContainerOutput";
            splitContainerOutput.Orientation = Orientation.Horizontal;
            // 
            // splitContainerOutput.Panel1
            // 
            splitContainerOutput.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainerOutput.Panel2
            // 
            splitContainerOutput.Panel2.Controls.Add(groupBoxOutput);
            splitContainerOutput.Size = new Size(364, 342);
            splitContainerOutput.SplitterDistance = 79;
            splitContainerOutput.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBoxConsole);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(10, 5, 10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7);
            groupBox1.Size = new Size(364, 79);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista";
            // 
            // richTextBoxConsole
            // 
            richTextBoxConsole.BorderStyle = BorderStyle.None;
            richTextBoxConsole.Dock = DockStyle.Fill;
            richTextBoxConsole.Font = new Font("Consolas", 9F);
            richTextBoxConsole.Location = new Point(7, 23);
            richTextBoxConsole.Margin = new Padding(10);
            richTextBoxConsole.Name = "richTextBoxConsole";
            richTextBoxConsole.ReadOnly = true;
            richTextBoxConsole.Size = new Size(350, 49);
            richTextBoxConsole.TabIndex = 0;
            richTextBoxConsole.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 634);
            Controls.Add(tableLayoutPanelMain);
            MinimumSize = new Size(400, 500);
            Name = "Form1";
            Text = "Kompresja Powtórek";
            FormClosing += Form1_FormClosing;
            groupBoxCompresionSettings.ResumeLayout(false);
            groupBoxCompresionSettings.PerformLayout();
            tableLayoutPanelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.PerformLayout();
            groupBoxOutput.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).EndInit();
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            groupBoxApplicationSettings.ResumeLayout(false);
            groupBoxApplicationSettings.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFontSize).EndInit();
            splitContainerOutput.Panel1.ResumeLayout(false);
            splitContainerOutput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerOutput).EndInit();
            splitContainerOutput.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxCompresionSettings;
        private Label labelOutputFolder;
        private Label labelInputFolder;
        private GroupBox groupBoxOutput;
        private PictureBox pictureBoxThumbnail;
        private TextBox textBoxOutputFolder;
        private TextBox textBoxInputFolder;
        private Label labelFileName;
        private ProgressBar progressBarOutput;
        private ComboBox comboBoxFrameRate;
        private Label labelFrameRate;
        private ComboBox comboBoxResolution;
        private Label labelResolution;
        private Button buttonInputFolder;
        private Button buttonOutputFolder;
        private ComboBox comboBoxEncoder;
        private Label label1;
        private Button buttonActivate;
        private TableLayoutPanel tableLayoutPanelSettings;
        private TableLayoutPanel tableLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox comboBoxColorMode;
        private GroupBox groupBoxApplicationSettings;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelColorMode;
        private Label labelFontSize;
        private NumericUpDown numericUpDownFontSize;
        private SplitContainer splitContainerOutput;
        private GroupBox groupBox1;
        private RichTextBox richTextBoxConsole;
    }
}
