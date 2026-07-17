using System.Diagnostics;

namespace Kompresja_Powtórek_GUI
{
    internal class FFmpeg
    {
        public FFmpeg()
        {
            // Obsługa zdarzenia dodaj klip
            ClipAdded += FFmpeg_ClipAdded;
        }

        private void FFmpeg_ClipAdded(object? sender, ClipAddedEventArgs e)
        {
            if (busy)
            {
                return;
            }
            else
            {
                busy = true;
                while (ClipQueue.Count > 0)
                {
                    Clip clip;
                    try
                    {
                        clip = ClipQueue.Dequeue();
                    }
                    catch
                    {
                        continue;
                    }

                    CompressClip(clip.FilePath, clip.FileName);
                }
                busy = false;
            }
        }

        private void CompressClip(string clipFilePath, string clipFileName)
        { 
            if (clipFilePath == null || clipFilePath == string.Empty)
            {
                return;
            }

            if (clipFileName == null || clipFileName == string.Empty)
            {
                return;
            }

            // Długość nazwy pliku zakończonej ".mkv"
            int clipFileNameLength = clipFileName.Length;

            // Nazwa pliku po zmianie rozszerzenia na ".mp4"
            string clipFileNameWihoutExtension = clipFileName.Substring(0, clipFileNameLength - 4);

            string outputFileName = $"{clipFileNameWihoutExtension} ({ResolutionName}, {FrameRate} FPS).mp4";
            string outputFilePath = $"{OutputFolder}\\{outputFileName}";
            string thumbnailFilePath = $"{OutputFolder}\\{clipFileNameWihoutExtension}.png";

            int frameCount;

            if(!CountFrames(clipFilePath, out frameCount))
            {
                FFmpegErrorEventArgs err = new FFmpegErrorEventArgs();
                err.ClipFileName = clipFileName;
                err.ErrorMessage = "FFprobe: Nie można wyznaczyć liczby klatek.";
                OnFFmpegError(err);
                return;
            }

            if(!CreateThumbnail(clipFilePath, thumbnailFilePath))
            {
                FFmpegErrorEventArgs err = new FFmpegErrorEventArgs();
                err.ClipFileName = clipFileName;
                err.ErrorMessage = "FFMpeg: Nie można utworzyć miniatury.";
                OnFFmpegError(err);
                return;
            }

            ThumbnailCreatedEventArgs eThumbnail = new ThumbnailCreatedEventArgs();
            eThumbnail.ClipFileName = clipFileName;
            eThumbnail.ThumbnailFilePath = thumbnailFilePath;
            OnThumbnailCreated(eThumbnail);

            if (!CreateVideo(clipFilePath, clipFileName, outputFilePath, frameCount))
            {
                FFmpegErrorEventArgs err = new FFmpegErrorEventArgs();
                err.ClipFileName = clipFileName;
                err.ErrorMessage = "FFMpeg: Błąd filmu.";
                OnFFmpegError(err);
                return;
            }

            VideoCreatedEventArgs eVideo = new VideoCreatedEventArgs();
            eVideo.ClipFileName = clipFileName;
            eVideo.OutputFilePath = outputFilePath;
            eVideo.OutputFileName = outputFileName;
            eVideo.FrameCount = frameCount;
            OnVideoCreated(eVideo);
        }

        // Pola Prywatne
        private struct Clip
        {
            public string FilePath;
            public string FileName;
        };

        private Queue<Clip> ClipQueue = new Queue<Clip>();
        private bool busy = false;

        public void AddClip(string clipFilePath, string clipFileName)
        {
            Clip clip = new Clip();
            clip.FilePath = clipFilePath;
            clip.FileName = clipFileName;

            ClipQueue.Enqueue(clip);

            ClipAddedEventArgs e = new ClipAddedEventArgs();
            e.ClipFilePath = clipFilePath;
            e.ClipFileName = clipFileName;
            OnClipAdded(e);
        }

        // Pola publiczne
        public string OutputFolder = string.Empty;
        public string Resolution = string.Empty;
        public string ResolutionName = string.Empty;
        public string FrameRate = string.Empty;
        public string Encoder = string.Empty;

        // Zdarzenia
        public event EventHandler<ClipAddedEventArgs>? ClipAdded;

        public event EventHandler<FFmpegErrorEventArgs>? FFmpegError;
        public event EventHandler<ConversionStartedEventArgs>? ConversionStarted;
        public event EventHandler<ThumbnailCreatedEventArgs>? ThumbnailCreated;
        public event EventHandler<ProgressChangedEventArgs>? ProgressChanged;
        public event EventHandler<VideoCreatedEventArgs>? VideoCreated;

        // Argumenty zdarzeń
        public class ClipAddedEventArgs : EventArgs
        {
            public string ClipFilePath { get; set; }
            public string ClipFileName { get; set; }
        }
        public class FFmpegErrorEventArgs : EventArgs
        {
            // Nazwa klipu, dla którego wystapił błąd
            public string ClipFileName { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class ConversionStartedEventArgs : EventArgs
        {
            // Nazwa klipu, dla którego wystapił błąd
            public string ClipFileName { get; set; }
        }

        public class ThumbnailCreatedEventArgs : EventArgs
        {
            // Nazwa klipu, dla którego utworzono miniaturę
            public string ClipFileName { get; set; }
            public string ThumbnailFilePath { get; set; }
        }
        public class ProgressChangedEventArgs : EventArgs
        {
            public string ClipFileName { get; set; }
            public int Frame { get; set; }
            public int FrameCount { get; set; }
        }
        public class VideoCreatedEventArgs : EventArgs
        {
            public string ClipFileName { get; set; }

            public string OutputFilePath { get; set; }
            public string OutputFileName { get; set; }
            public int FrameCount { get; set; }
        }

        // Metody zapalania zdarzeń
        protected virtual void OnClipAdded(ClipAddedEventArgs e)
        {
            ClipAdded?.Invoke(this, e);
        }
        protected virtual void OnFFmpegError(FFmpegErrorEventArgs e)
        {
            FFmpegError?.Invoke(this, e);
        }
        protected virtual void OnConversionStarted(ConversionStartedEventArgs e)
        {
            ConversionStarted?.Invoke(this, e);
        }
        protected virtual void OnThumbnailCreated(ThumbnailCreatedEventArgs e)
        {
            ThumbnailCreated?.Invoke(this, e);
        }
        protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }
        protected virtual void OnVideoCreated(VideoCreatedEventArgs e)
        {
            VideoCreated?.Invoke(this, e);
        }

        public bool CountFrames(string inputFile, out int frameCount)
        {
            // Proces FFprobe do liczenia klatek filmu
            Process countProcess = new Process();
            countProcess.StartInfo.FileName = "cmd.exe";
            countProcess.StartInfo.Arguments = $"/C ffprobe -v error -select_streams v:0 -count_packets -show_entries stream=nb_read_packets -of csv=p=0 \"{inputFile}\"";

            // Nie używaj Shella
            countProcess.StartInfo.UseShellExecute = false;

            // Otwórz terminal bez tworzenia okna
            countProcess.StartInfo.CreateNoWindow = true;

            // Włącz logowanie wyjścia
            countProcess.StartInfo.RedirectStandardOutput = true;

            // Rozpoczęcie procesu
            countProcess.Start();

            // Odczytaj liczbę klatek w formie tekstu
            string? line = countProcess.StandardOutput.ReadLine();

            // Oczekiwanie na zakończenie procesu
            countProcess.WaitForExit();

            int exitCode = countProcess.ExitCode;

            // Zamykanie procesu
            countProcess.Close();

            // Konwersja
            try
            {
                frameCount = Convert.ToInt32(line);
            }
            catch
            {
                frameCount = 0;
                return false;
            }

            // Sprawdzenie, czy nastąpił błąd
            if (exitCode != 0)
            {
                return false;
            }

            return true;
        }

        public bool CreateThumbnail(string inputFilePath, string thumbnailFilePath)
        {
            // Proces FFmpeg do tworzenia miniatury
            Process thumbnailProcess = new Process();
            thumbnailProcess.StartInfo.FileName = "cmd.exe";

            // Komenda FFmpeg
            thumbnailProcess.StartInfo.Arguments = $"/C ffmpeg -y -i \"{inputFilePath}\" -frames:v 1 -update true \"{thumbnailFilePath}\"";

            // Nie używaj Shella
            thumbnailProcess.StartInfo.UseShellExecute = false;

            // Otwórz terminal bez tworzenia okna
            thumbnailProcess.StartInfo.CreateNoWindow = true;

            // Rozpoczęcie procesu
            thumbnailProcess.Start();

            // Oczekiwanie na zakończenie procesu
            thumbnailProcess.WaitForExit();

            int exitCode = thumbnailProcess.ExitCode;

            // Zamykanie procesu
            thumbnailProcess.Close();

            // Sprawdzenie, czy nastąpił błąd
            if (exitCode != 0)
            {
                return false;
            }

            return true;
        }

        public bool CreateVideo(string inputFilePath, string clipFileName, string outputFilePath, int frameCount)
        {
            // Proces FFmpeg
            Process videoProcess = new Process();
            videoProcess.StartInfo.FileName = "cmd.exe";
            videoProcess.StartInfo.Arguments = $"/C ffmpeg -y -progress pipe:1 -i \"{inputFilePath}\" -r {FrameRate} -s {Resolution} -c:v {Encoder} -c:a copy \"{outputFilePath}\"";

            // Nie używaj Shella
            videoProcess.StartInfo.UseShellExecute = false;

            // Otwórz terminal bez tworzenia okna
            videoProcess.StartInfo.CreateNoWindow = true;

            // Włącz logowanie wyjścia
            videoProcess.StartInfo.RedirectStandardOutput = true;

            // Rozpoczęcie procesu
            videoProcess.Start();

            // Odczytania linia
            string? line;

            // Czytaj aż do końca strumienia
            while ((line = videoProcess.StandardOutput.ReadLine()) != null)
            {
                // Rodziel nazwę i wartość
                string[] strings = line.Split('=');

                // Jeśli istnieje nazwa i wartość
                if (strings.Length == 2)
                {
                    // Odczytaj nawzę parametru
                    string name = strings[0];

                    // Jeśli parametr to numer klatki
                    if (name == "frame")
                    {
                        // Odczytaj wartość parametru
                        string value = strings[1];

                        // Zmienna na numer klatki
                        int frame = 0;

                        // Spróbuj przekowertować tekst na liczbę
                        try
                        {
                            frame = Convert.ToInt32(value);
                        }
                        catch
                        {
                            return false;
                        }

                        // Zapal Event Progress
                        ProgressChangedEventArgs e = new ProgressChangedEventArgs();
                        e.ClipFileName = clipFileName;
                        e.Frame = frame;
                        e.FrameCount = frameCount;
                        OnProgressChanged(e);
                    }
                }
            }

            // Oczekiwanie na zakończenie procesu
            videoProcess.WaitForExit();

            int exitCode = videoProcess.ExitCode;

            // Zamykanie procesu
            videoProcess.Close();

            // Sprawdzenie, czy nastąpił błąd
            if (exitCode != 0)
            {
                return false;
            }

            return true;
        }
    }
}