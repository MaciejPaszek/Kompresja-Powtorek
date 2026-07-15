using System.Diagnostics;
using System.Windows.Forms;

namespace Kompresja_Powtórek_GUI
{
    public partial class Form1 : Form
    {
        //------------------------------
        // Obiekty Globalne
        //------------------------------

        // Plik ustawień
        const string settingsFile = "settings.txt";

        //
        private bool isWatcherActive = false;

        // Parametry FFmpeg
        private static string OutputFolder;
        private static string Resolution;
        private static string FrameRate;
        private static string Encoder;

        // Monitorowanie folderu
        FileSystemWatcher FileSystemWatcher;

        //------------------------------
        // Zdarzenia
        //------------------------------

        // New Clip Event
        public event EventHandler<NewClipEventArgs>? NewClip;
        public class NewClipEventArgs : EventArgs
        {
            public string clipName { get; set; }
        }
        protected virtual void OnNewClip(NewClipEventArgs e)
        {
            NewClip?.Invoke(this, e);
        }

        // New Thumbnail Event
        public event EventHandler<NewThumbnailEventArgs>? NewThumbnail;
        public class NewThumbnailEventArgs : EventArgs
        {
            public string thumbnailFile { get; set; }
        }
        protected virtual void OnNewThumbnail(NewThumbnailEventArgs e)
        {
            NewThumbnail?.Invoke(this, e);
        }

        // Video Progress Event
        public event EventHandler<NewProgressEventArgs>? NewProgress;
        public class NewProgressEventArgs : EventArgs
        {
            public int currentFrame { get; set; }
            public int frameCount { get; set; }
        }
        protected virtual void OnNewProgress(NewProgressEventArgs e)
        {
            NewProgress?.Invoke(this, e);
        }

        //------------------------------
        // Form1
        //------------------------------

        public Form1()
        {

            InitializeComponent();

            NewClip += Form1_NewClip;
            NewThumbnail += Form1_NewThumbnail;
            NewProgress += Form1_NewProgress;
        }

        private void Form1_NewClip(object? sender, NewClipEventArgs e)
        {
            if (labelFileName.InvokeRequired)
            {
                labelFileName.Invoke(new Action(() => { labelFileName.Text = e.clipName; }));
            }
            else
            {
                labelFileName.Text = e.clipName;
            }

            if (progressBarOutput.InvokeRequired)
            {
                progressBarOutput.Invoke(new Action(() => { progressBarOutput.Value = 0; }));
            }
            else
            {
                progressBarOutput.Value = 0;
            }
        }

        private void Form1_NewThumbnail(object? sender, NewThumbnailEventArgs e)
        {

            if (pictureBoxThumbnail.InvokeRequired)
            {
                pictureBoxThumbnail.Invoke(new Action(() => {
                    pictureBoxThumbnail.Image = new Bitmap(e.thumbnailFile); 
                }));
            }
            else
            {
                pictureBoxThumbnail.Image = new Bitmap(e.thumbnailFile);
            }
        }

        private void Form1_NewProgress(object? sender, NewProgressEventArgs e)
        {
            if (progressBarOutput.InvokeRequired)
            {
                progressBarOutput.Invoke(new Action(() => {
                    progressBarOutput.Maximum = e.frameCount;
                    progressBarOutput.Value = e.currentFrame;
                    
                }));
            }
            else
            {
                progressBarOutput.Maximum = e.frameCount;
                progressBarOutput.Value = e.currentFrame;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitalizeComboBoxes();
            LoadSettings();
        }

        //------------------------------
        // Metody Zdarzeń
        //------------------------------

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

        private void InitalizeComboBoxes()
        {
            comboBoxResolution.SelectedIndex = 2;
            comboBoxFrameRate.SelectedIndex = 1;
            comboBoxEncoder.SelectedIndex = 1;
        }

        private bool InitalizeFileSystemWatcher()
        {
            if (textBoxInputFolder.Text == null || textBoxInputFolder.Text == string.Empty)
            {
                MessageBox.Show("Nie określono folderu wejściowego.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(FileSystemWatcher!= null)
            {
                FileSystemWatcher.Dispose();
            }

            FileSystemWatcher = new FileSystemWatcher(textBoxInputFolder.Text);
            FileSystemWatcher.Created += FileSystemWatcher_Created;
            FileSystemWatcher.Filter = "*.mkv";
            FileSystemWatcher.IncludeSubdirectories = false;
            FileSystemWatcher.EnableRaisingEvents = true;

            return true;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            // Zapal Event NewClip
            NewClipEventArgs newClipEventArgs = new NewClipEventArgs();
            newClipEventArgs.clipName = e.Name;
            OnNewClip(newClipEventArgs);

            // Nazwa nowego pliku
            string inputFile = e.FullPath;

            if (e.Name == null)
            {
                return;
            }

            // Długość nazwy pliku zakończonej ".mkv"
            int nameLength = e.Name.Length;

            // Nazwa pliku po zmianie rozszerzenia na ".mp4"
            string inputFileName = e.Name.Substring(0, nameLength - 4);

            string outputFile = $"{OutputFolder}\\{inputFileName}.mp4";
            string thumbnailFile = $"{OutputFolder}\\{inputFileName}.png";

            FFmpegThumbnail(inputFile, thumbnailFile);

            // Zapal Event Thumbnail
            NewThumbnailEventArgs newThumbnailEventArgs = new NewThumbnailEventArgs();
            newThumbnailEventArgs.thumbnailFile = thumbnailFile;
            OnNewThumbnail(newThumbnailEventArgs);

            // Wyznacz liczbę klatek
            int frameCount = FFprobeCountFrames(inputFile);

            FFmpegVideo(inputFile, outputFile, Resolution, FrameRate, Encoder, frameCount);
            
            // Zapal Event Progress
            NewProgressEventArgs newProgressEventArgs = new NewProgressEventArgs();
            newProgressEventArgs.currentFrame = frameCount;
            newProgressEventArgs.frameCount = frameCount;
            OnNewProgress(newProgressEventArgs);
        }

        void FFmpegThumbnail(string inputFile, string thumbnailFile)
        {
            // Proces FFmpeg
            Process thumbnailProcess = new Process();
            thumbnailProcess.StartInfo.FileName = "cmd.exe";
            thumbnailProcess.StartInfo.Arguments = $"/C ffmpeg -y -i \"{inputFile}\" -frames:v 1 -update true \"{thumbnailFile}\"";
            thumbnailProcess.StartInfo.UseShellExecute = false;
            thumbnailProcess.StartInfo.CreateNoWindow = true;

            // Rozpoczęcie procesu
            thumbnailProcess.Start();

            // OCzekiwanie na zakończenie procesu
            thumbnailProcess.WaitForExit();
            thumbnailProcess.Close();
        }
        private int FFprobeCountFrames(string inputFile)
        {
            // Proces FFmpeg
            Process countProcess = new Process();
            countProcess.StartInfo.FileName = "cmd.exe";
            countProcess.StartInfo.Arguments = $"/C ffprobe -v error -select_streams v:0 -count_packets -show_entries stream=nb_read_packets -of csv=p=0 \"{inputFile}\"";
            countProcess.StartInfo.UseShellExecute = false;
            countProcess.StartInfo.CreateNoWindow = true;
            countProcess.StartInfo.RedirectStandardOutput = true;

            // Rozpoczęcie procesu
            countProcess.Start();

            string? frameCount = countProcess.StandardOutput.ReadLine();

            // Oczekiwanie na zakończenie procesu
            countProcess.WaitForExit();
            countProcess.Close();

            return Convert.ToInt32(frameCount);
        }
        private void FFmpegVideo(string inputFile, string outputFile, string resolution, string frameRate, string encoder, int frameCount)
        {
            //progressBarOutput.Value = 0;

            // Proces FFmpeg
            Process videoProcess = new Process();
            videoProcess.StartInfo.FileName = "cmd.exe";
            videoProcess.StartInfo.Arguments = $"/C ffmpeg -y -progress pipe:1 -i \"{inputFile}\" -r {frameRate} -s {resolution} -c:v {encoder} -c:a copy \"{outputFile}\"";
            videoProcess.StartInfo.UseShellExecute = false;
            videoProcess.StartInfo.CreateNoWindow = true;
            videoProcess.StartInfo.RedirectStandardOutput = true;

            // Rozpoczęcie procesu
            videoProcess.Start();

            string? line;

            while ((line = videoProcess.StandardOutput.ReadLine()) != null)
            {
                string[] strings = line.Split('='); 
                if(strings.Length > 1) {
                    string name = strings[0];
                    string value = strings[1];

                    if(name == "frame")
                    {
                        int currentFrame = Convert.ToInt32(value);

                        // Zapal Event Progress
                        NewProgressEventArgs newProgressEventArgs = new NewProgressEventArgs();
                        newProgressEventArgs.currentFrame = currentFrame;
                        newProgressEventArgs.frameCount = frameCount;
                        OnNewProgress(newProgressEventArgs);
                    }
                }
            }

            // Oczekiwanie na zakończenie procesu
            videoProcess.WaitForExit();
            videoProcess.Close();

            //progressBarOutput.Value = 100;
        }

        private void UpdateResolution()
        {
            string selectedItemString = comboBoxResolution.SelectedItem.ToString();

            string[] strings = selectedItemString.Split('p');

            int height = Convert.ToInt32(strings[0]);
            int width = height * 16 / 9;

            Resolution = $"{width}x{height}";
        }

        private void UpdateFrameRate()
        {
            FrameRate = comboBoxFrameRate.SelectedItem.ToString();
        }

        private void UpdateEncoder()
        {
            string selectedItemString = comboBoxEncoder.SelectedItem.ToString();

            if (selectedItemString == "CPU")
            {
                Encoder = "libx264";
                return;
            }

            if (selectedItemString == "GPU")
            {
                Encoder = "h264_nvenc";
                return;
            }
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

        private void SaveSettings()
        {
            StreamWriter streamWriter = File.CreateText(settingsFile);

            streamWriter.WriteLine(textBoxInputFolder.Text);
            streamWriter.WriteLine(textBoxOutputFolder.Text);
            streamWriter.WriteLine(comboBoxResolution.SelectedIndex.ToString());
            streamWriter.WriteLine(comboBoxFrameRate.SelectedIndex.ToString());
            streamWriter.WriteLine(comboBoxEncoder.SelectedIndex.ToString());
            streamWriter.WriteLine(Application.ColorMode);
            

            streamWriter.Close();
            streamWriter.Dispose();
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
                    if (i == 5) { Application.SetColorMode((SystemColorMode) Convert.ToInt32(line)); }
                    i++;
                }

                streamReader.Close();
                streamReader.Dispose();

                OutputFolder = textBoxOutputFolder.Text;
                UpdateResolution();
                UpdateFrameRate();
                UpdateEncoder();
              
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

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
            OutputFolder = textBoxOutputFolder.Text;
        }
    }
}
