using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Kompresja_Powtórek_GUI
{
    public partial class Form1 : Form
    {
        //------------------------------
        // Obiekty Globalne
        //------------------------------

        // Plik ustawień
        const string settingsFile = "settings.txt";

        // Czy monitorowanie plików jest aktywne
        private bool isWatcherActive = false;

        // Monitorowanie folderu
        FileSystemWatcher FileSystemWatcher;

        // Klasa FFmpeg
        FFmpeg FFmpeg = new FFmpeg();

        //------------------------------
        // Form1
        //------------------------------

        public Form1()
        {
            InitializeComponent();

            InitalizeComboBoxes();

            // Załaduj ustawienia z pliku settings.txt
            LoadSettings();

            // Utwóz obiekt klasy FFmpeg i dodaj obsługę zdarzeń
            FFmpeg.FFmpegError += Form1_FFmpegError;
            FFmpeg.ConversionStarted += FFmpeg_ConversionStarted;
            FFmpeg.ThumbnailCreated += Form1_ThumbnailCreated;
            FFmpeg.ProgressChanged += Form1_ProgressChanged;
            FFmpeg.VideoCreated += FFmpeg_VideoCreated;
        }

        private void InitalizeComboBoxes()
        {
            comboBoxResolution.SelectedIndex = 2;
            comboBoxFrameRate.SelectedIndex = 1;
            comboBoxEncoder.SelectedIndex = 1;
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                StreamReader streamReader = File.OpenText(settingsFile);

                int i = 0;
                string line = "";

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (i == 0) { textBoxInputFolder.Text = line; }
                    if (i == 1) { textBoxOutputFolder.Text = line; }
                    if (i == 2) { comboBoxResolution.SelectedIndex = Convert.ToInt32(line); }
                    if (i == 3) { comboBoxFrameRate.SelectedIndex = Convert.ToInt32(line); }
                    if (i == 4) { comboBoxEncoder.SelectedIndex = Convert.ToInt32(line); }
                    if (i == 5) { comboBoxColorMode.SelectedIndex = Convert.ToInt32(line); }
                    if (i == 6) { numericUpDownFontSize.Value = Convert.ToInt32(line); }
                    i++;
                }

                streamReader.Close();
                streamReader.Dispose();

                FFmpeg.OutputFolder = textBoxOutputFolder.Text;

                UpdateResolution();
                UpdateFrameRate();
                UpdateEncoder();
                UpdateColorMode();
                UpdateConsoleFontSize();
            }
        }

        private void Form1_FFmpegError(object? sender, FFmpeg.FFmpegErrorEventArgs e)
        {
            if (richTextBoxConsole.InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action(() => {
                    RichTextBoxColor(e.ClipFileName, FontStyle.Bold, Color.Red);
                }));
            }
            else
            {
                RichTextBoxColor(e.ClipFileName, FontStyle.Bold, Color.Red);
            }
        }

        private void FFmpeg_ConversionStarted(object? sender, FFmpeg.ConversionStartedEventArgs e)
        {
            // Ustaw nazwę nowego klipu 
            if (labelFileName.InvokeRequired)
            {
                labelFileName.Invoke(new Action(() => { labelFileName.Text = e.ClipFileName; }));
            }
            else
            {
                labelFileName.Text = e.ClipFileName;
            }

            if (progressBarOutput.InvokeRequired)
            {
                progressBarOutput.Invoke(new Action(() =>
                {
                    // możliwe, że warto dać też maksimum
                    progressBarOutput.Value = 0;
                }));
            }
            else
            {
                progressBarOutput.Value = 0;
            }
        }

        private void Form1_ThumbnailCreated(object? sender, FFmpeg.ThumbnailCreatedEventArgs e)
        {
            if(labelFileName.InvokeRequired)
            {
                labelFileName.Invoke(new Action(() =>
                {
                    labelFileName.Text = e.ClipFileName;
                }));
            }
            else
            {
                labelFileName.Text = e.ClipFileName;
            }

            if (pictureBoxThumbnail.InvokeRequired)
            {
                pictureBoxThumbnail.Invoke(new Action(() =>
                {
                    pictureBoxThumbnail.Image = new Bitmap(e.ThumbnailFilePath);
                }));
            }
            else
            {
                pictureBoxThumbnail.Image = new Bitmap(e.ThumbnailFilePath);
            }

            if (richTextBoxConsole.InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action(() => {
                    RichTextBoxColor(e.ClipFileName, FontStyle.Bold, Color.Blue);
                }));
            }
            else
            {
                RichTextBoxColor(e.ClipFileName, FontStyle.Bold, Color.Blue);
            }
        }

        private void Form1_ProgressChanged(object? sender, FFmpeg.ProgressChangedEventArgs e)
        {
            if (progressBarOutput.InvokeRequired)
            {
                progressBarOutput.Invoke(new Action(() =>
                {
                    progressBarOutput.Maximum = e.FrameCount;
                    progressBarOutput.Value = e.Frame;
                }));
            }
            else
            {
                progressBarOutput.Maximum = e.FrameCount;
                progressBarOutput.Value = e.Frame;
            }
        }

        private void FFmpeg_VideoCreated(object? sender, FFmpeg.VideoCreatedEventArgs e)
        {
            if (progressBarOutput.InvokeRequired)
            {
                progressBarOutput.Invoke(new Action(() =>
                {
                    progressBarOutput.Maximum = e.FrameCount;
                    progressBarOutput.Value = e.FrameCount;
                }));
            }
            else
            {
                progressBarOutput.Maximum = e.FrameCount;
                progressBarOutput.Value = e.FrameCount;
            }

            if (richTextBoxConsole.InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action(() => {
                    RichTextBoxColor(e.ClipFileName, FontStyle.Bold, Color.Green);
                }));
            }
            else
            {
                RichTextBoxColor(e.ClipFileName, FontStyle.Bold, Color.Green);
            }
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            if (!isWatcherActive)
            {
                if (!InitalizeFileSystemWatcher())
                {
                    return;
                }

                // FileWatcher jest nieaktywny
                textBoxInputFolder.Enabled = false;
                textBoxOutputFolder.Enabled = false;
                buttonInputFolder.Enabled = false;
                buttonOutputFolder.Enabled = false;
                comboBoxResolution.Enabled = false;
                comboBoxFrameRate.Enabled = false;
                comboBoxEncoder.Enabled = false;

                buttonActivate.Text = "Zatrzymaj";
                isWatcherActive = true;
            }
            else
            {
                textBoxInputFolder.Enabled = true;
                textBoxOutputFolder.Enabled = true;
                buttonInputFolder.Enabled = true;
                buttonOutputFolder.Enabled = true;
                comboBoxResolution.Enabled = true;
                comboBoxFrameRate.Enabled = true;
                comboBoxEncoder.Enabled = true;

                buttonActivate.Text = "Rozpocznij";
                isWatcherActive = false;
            }
        }

        private bool InitalizeFileSystemWatcher()
        {
            // Walidacja pola InputFolder
            if (textBoxInputFolder.Text == null || textBoxInputFolder.Text == string.Empty)
            {
                MessageBox.Show("Nie określono folderu wejściowego.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(textBoxInputFolder.Text))
            {
                MessageBox.Show($"Folder wejściowy {textBoxInputFolder.Text} nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja pola OutputFolder
            if (textBoxOutputFolder.Text == null || textBoxOutputFolder.Text == string.Empty)
            {
                MessageBox.Show("Nie określono folderu wyjściowego.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(textBoxOutputFolder.Text))
            {
                MessageBox.Show($"Folder wyjściowy {textBoxInputFolder.Text} nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Wyłącz poprzedniego FileSystemWatchera
            if (FileSystemWatcher != null)
            {
                FileSystemWatcher.Dispose();
            }

            // Nowy FileSystemWatcher
            FileSystemWatcher = new FileSystemWatcher(textBoxInputFolder.Text);
            FileSystemWatcher.Created += FileSystemWatcher_Created;
            FileSystemWatcher.Filter = "*.mkv";
            FileSystemWatcher.IncludeSubdirectories = false;
            FileSystemWatcher.EnableRaisingEvents = true;

            return true;
        }

        /// <summary>
        /// Obsługa zdarzenia utworzenia nowego pliku klipu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            // Dodaj plik na listę RichText
            if (richTextBoxConsole.InvokeRequired)
            {
                richTextBoxConsole.Invoke(new Action(() => {
                    if (richTextBoxConsole.Text == string.Empty)
                    {
                        richTextBoxConsole.AppendText(e.Name);
                    }
                    else
                    {
                        richTextBoxConsole.AppendText(Environment.NewLine + e.Name);
                    }
                    RichTextBoxColor(e.Name, FontStyle.Regular, Color.Gray);
                    richTextBoxConsole.ScrollToCaret();
                }));
            }
            else
            {
                if (richTextBoxConsole.Text == string.Empty)
                {
                    richTextBoxConsole.AppendText(e.Name);
                }
                else
                {
                    richTextBoxConsole.AppendText(Environment.NewLine + e.Name);
                }
                RichTextBoxColor(e.Name, FontStyle.Regular, Color.Gray);
                richTextBoxConsole.ScrollToCaret();
            }

            // Dodaj plik do kolejki FFMpeg
            Task AddClipTask = new Task(() => FFmpeg.AddClip(e.FullPath, e.Name));
            AddClipTask.Start();

            return;
        }

        //------------------------------
        // Metody Zdarzeń
        //------------------------------

        /// <summary>
        /// Wybierz folder wejściowy lub wyjświowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFolder_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Equals(buttonInputFolder))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Wybierz folder wejściowy";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxInputFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }

            if (button.Equals(buttonOutputFolder))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Wybierz folder wyjściowy";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxOutputFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void textBoxOutputFolder_TextChanged(object sender, EventArgs e)
        {
            FFmpeg.OutputFolder = textBoxOutputFolder.Text;
        }

        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateResolution();
        }

        private void comboBoxFrameRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFrameRate();
        }

        private void comboBoxEncoder_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEncoder();
        }

        private void comboBoxColorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColorMode.IsHandleCreated)
            {
                MessageBox.Show("Uruchom ponownie, aby zastosować zmiany.", "Tryb kolorów", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateConsoleFontSize();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        /*******************************************************
         * Funkcje pomocnicze 
         *******************************************************/

        /// <summary>
        /// Przelicza wysokość klatki na szerokość
        /// </summary>
        private void UpdateResolution()
        {
            string selectedItemString = comboBoxResolution.SelectedItem.ToString();

            string[] strings = selectedItemString.Split('p');

            int height = Convert.ToInt32(strings[0]);
            int width = height * 16 / 9;

            FFmpeg.ResolutionName = selectedItemString;
            FFmpeg.Resolution = $"{width}x{height}";
        }

        /// <summary>
        /// Nadpisuje FPS
        /// </summary>
        private void UpdateFrameRate()
        {
            FFmpeg.FrameRate = comboBoxFrameRate.SelectedItem.ToString();
        }

        /// <summary>
        /// Nadpisuje enkoder
        /// </summary>
        private void UpdateEncoder()
        {
            string selectedItemString = comboBoxEncoder.SelectedItem.ToString();

            if (selectedItemString == "CPU")
            {
                FFmpeg.Encoder = "libx264";
                return;
            }

            if (selectedItemString == "GPU")
            {
                FFmpeg.Encoder = "h264_nvenc";
                return;
            }
        }

        void UpdateConsoleFontSize()
        {
            richTextBoxConsole.Font = new Font(richTextBoxConsole.Font.FontFamily, (float)numericUpDownFontSize.Value, richTextBoxConsole.Font.Style);
        }

        /// <summary>
        /// Nadpisuje tryb kolorów
        /// </summary>
        private void UpdateColorMode()
        {
            if (comboBoxColorMode.SelectedIndex == 0)
            {
                Application.SetColorMode(SystemColorMode.Classic);
                return;
            }

            if (comboBoxColorMode.SelectedIndex == 1)
            {
                Application.SetColorMode(SystemColorMode.Dark);
                return;
            }

            if (comboBoxColorMode.SelectedIndex == 2)
            {
                Application.SetColorMode(SystemColorMode.System);
                return;
            }
        }

        /// <summary>
        /// Znajdź wyrażenie w richtextbox i zmień jego kolor
        /// </summary>
        private void RichTextBoxColor(string text, FontStyle fontStyle, Color color)
        {
            Regex regex = new Regex(text);
            Match match = regex.Match(richTextBoxConsole.Text);

            if (match.Success)
            {
                richTextBoxConsole.Select(match.Index, match.Length);
                richTextBoxConsole.SelectionFont = new Font(richTextBoxConsole.Font, fontStyle);
                richTextBoxConsole.SelectionColor = color;
            }
        }

        private void SaveSettings()
        {
            StreamWriter streamWriter = File.CreateText(settingsFile);

            streamWriter.WriteLine(textBoxInputFolder.Text);
            streamWriter.WriteLine(textBoxOutputFolder.Text);
            streamWriter.WriteLine(comboBoxResolution.SelectedIndex.ToString());
            streamWriter.WriteLine(comboBoxFrameRate.SelectedIndex.ToString());
            streamWriter.WriteLine(comboBoxEncoder.SelectedIndex.ToString());
            streamWriter.WriteLine(comboBoxColorMode.SelectedIndex.ToString());
            streamWriter.WriteLine(numericUpDownFontSize.Value.ToString());

            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
