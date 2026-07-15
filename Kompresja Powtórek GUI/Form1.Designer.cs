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
            groupBoxSettings = new GroupBox();
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
            groupBoxOutput = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxThumbnail = new PictureBox();
            progressBarOutput = new ProgressBar();
            labelFileName = new Label();
            tableLayoutPanelMain = new TableLayoutPanel();
            groupBoxSettings.SuspendLayout();
            tableLayoutPanelSettings.SuspendLayout();
            groupBoxOutput.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).BeginInit();
            tableLayoutPanelMain.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.AutoSize = true;
            groupBoxSettings.Controls.Add(tableLayoutPanelSettings);
            groupBoxSettings.Dock = DockStyle.Top;
            groupBoxSettings.Location = new Point(10, 10);
            groupBoxSettings.Margin = new Padding(10);
            groupBoxSettings.MinimumSize = new Size(350, 200);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new Size(364, 200);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Ustawienia";
            // 
            // tableLayoutPanelSettings
            // 
            tableLayoutPanelSettings.ColumnCount = 3;
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
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
            tableLayoutPanelSettings.Controls.Add(buttonActivate, 2, 5);
            tableLayoutPanelSettings.Dock = DockStyle.Fill;
            tableLayoutPanelSettings.Location = new Point(3, 19);
            tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
            tableLayoutPanelSettings.RowCount = 6;
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelSettings.Size = new Size(358, 178);
            tableLayoutPanelSettings.TabIndex = 8;
            // 
            // labelInputFolder
            // 
            labelInputFolder.AutoSize = true;
            labelInputFolder.Dock = DockStyle.Top;
            labelInputFolder.Location = new Point(3, 5);
            labelInputFolder.Margin = new Padding(3, 5, 3, 0);
            labelInputFolder.Name = "labelInputFolder";
            labelInputFolder.Size = new Size(114, 15);
            labelInputFolder.TabIndex = 0;
            labelInputFolder.Text = "Folder wejściowy";
            // 
            // comboBoxEncoder
            // 
            comboBoxEncoder.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoder.FormattingEnabled = true;
            comboBoxEncoder.Items.AddRange(new object[] { "CPU", "GPU" });
            comboBoxEncoder.Location = new Point(123, 119);
            comboBoxEncoder.Name = "comboBoxEncoder";
            comboBoxEncoder.Size = new Size(121, 23);
            comboBoxEncoder.TabIndex = 7;
            comboBoxEncoder.SelectedIndexChanged += comboBoxEncoder_SelectedIndexChanged;
            // 
            // buttonOutputFolder
            // 
            buttonOutputFolder.Dock = DockStyle.Top;
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
            buttonInputFolder.Dock = DockStyle.Top;
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
            labelResolution.Margin = new Padding(3, 5, 3, 0);
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
            label1.Margin = new Padding(3, 5, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 6;
            label1.Text = "Enkoder";
            // 
            // comboBoxFrameRate
            // 
            comboBoxFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFrameRate.FormattingEnabled = true;
            comboBoxFrameRate.Items.AddRange(new object[] { "24", "30", "60" });
            comboBoxFrameRate.Location = new Point(123, 90);
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
            labelFrameRate.Margin = new Padding(3, 5, 3, 0);
            labelFrameRate.Name = "labelFrameRate";
            labelFrameRate.Size = new Size(114, 15);
            labelFrameRate.TabIndex = 3;
            labelFrameRate.Text = "FPS";
            // 
            // textBoxInputFolder
            // 
            textBoxInputFolder.Dock = DockStyle.Top;
            textBoxInputFolder.Location = new Point(123, 3);
            textBoxInputFolder.Name = "textBoxInputFolder";
            textBoxInputFolder.Size = new Size(132, 23);
            textBoxInputFolder.TabIndex = 3;
            // 
            // textBoxOutputFolder
            // 
            textBoxOutputFolder.Dock = DockStyle.Top;
            textBoxOutputFolder.Location = new Point(123, 32);
            textBoxOutputFolder.Name = "textBoxOutputFolder";
            textBoxOutputFolder.Size = new Size(132, 23);
            textBoxOutputFolder.TabIndex = 4;
            textBoxOutputFolder.TextChanged += textBoxOutputFolder_TextChanged;
            // 
            // labelOutputFolder
            // 
            labelOutputFolder.AutoSize = true;
            labelOutputFolder.Dock = DockStyle.Top;
            labelOutputFolder.Location = new Point(3, 34);
            labelOutputFolder.Margin = new Padding(3, 5, 3, 0);
            labelOutputFolder.Name = "labelOutputFolder";
            labelOutputFolder.Size = new Size(114, 15);
            labelOutputFolder.TabIndex = 1;
            labelOutputFolder.Text = "Folder wyjściowy";
            // 
            // comboBoxResolution
            // 
            comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxResolution.FormattingEnabled = true;
            comboBoxResolution.Items.AddRange(new object[] { "144p", "240p", "360p", "480p", "720p" });
            comboBoxResolution.Location = new Point(123, 61);
            comboBoxResolution.Name = "comboBoxResolution";
            comboBoxResolution.Size = new Size(121, 23);
            comboBoxResolution.TabIndex = 1;
            comboBoxResolution.SelectedIndexChanged += comboBoxResolution_SelectedIndexChanged;
            // 
            // buttonActivate
            // 
            buttonActivate.Dock = DockStyle.Top;
            buttonActivate.Location = new Point(261, 148);
            buttonActivate.Name = "buttonActivate";
            buttonActivate.Size = new Size(94, 23);
            buttonActivate.TabIndex = 7;
            buttonActivate.Text = "Rozpocznij";
            buttonActivate.UseVisualStyleBackColor = true;
            buttonActivate.Click += buttonActivate_Click;
            // 
            // groupBoxOutput
            // 
            groupBoxOutput.Controls.Add(tableLayoutPanel1);
            groupBoxOutput.Dock = DockStyle.Fill;
            groupBoxOutput.Location = new Point(10, 230);
            groupBoxOutput.Margin = new Padding(10);
            groupBoxOutput.Name = "groupBoxOutput";
            groupBoxOutput.Size = new Size(364, 221);
            groupBoxOutput.TabIndex = 1;
            groupBoxOutput.TabStop = false;
            groupBoxOutput.Text = "Wyjście";
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
            tableLayoutPanel1.Size = new Size(358, 199);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBoxThumbnail
            // 
            pictureBoxThumbnail.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxThumbnail.Dock = DockStyle.Fill;
            pictureBoxThumbnail.Location = new Point(3, 3);
            pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            pictureBoxThumbnail.Size = new Size(352, 149);
            pictureBoxThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxThumbnail.TabIndex = 0;
            pictureBoxThumbnail.TabStop = false;
            // 
            // progressBarOutput
            // 
            progressBarOutput.Dock = DockStyle.Top;
            progressBarOutput.Location = new Point(3, 173);
            progressBarOutput.Name = "progressBarOutput";
            progressBarOutput.Size = new Size(352, 23);
            progressBarOutput.TabIndex = 1;
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Dock = DockStyle.Top;
            labelFileName.Location = new Point(3, 155);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(352, 15);
            labelFileName.TabIndex = 2;
            labelFileName.Text = "Nazwa pliku";
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(groupBoxOutput, 0, 1);
            tableLayoutPanelMain.Controls.Add(groupBoxSettings, 0, 0);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new Size(384, 461);
            tableLayoutPanelMain.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 461);
            Controls.Add(tableLayoutPanelMain);
            MinimumSize = new Size(400, 500);
            Name = "Form1";
            Text = "Kompresja Powtórek";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBoxSettings.ResumeLayout(false);
            tableLayoutPanelSettings.ResumeLayout(false);
            tableLayoutPanelSettings.PerformLayout();
            groupBoxOutput.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).EndInit();
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxSettings;
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
    }
}
