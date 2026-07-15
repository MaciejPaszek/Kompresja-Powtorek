using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Channels;

namespace Kompresja_Powtórek
{
    internal class Program
    {
        private static readonly string inputFolder = "C:\\Users\\macie\\Wideo Lokalne\\OBS Studio\\Klipy 1080p";
        private static readonly string outputFolder = "C:\\Users\\macie\\Wideo Lokalne\\OBS Studio\\Klipy 360p";
        private static readonly string outputResolution = "640x360";

        static bool isProcessRunning = false;

        static void Main(string[] args)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(inputFolder);

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            fileSystemWatcher.Filter = "*.mkv";
            fileSystemWatcher.IncludeSubdirectories = false;
            fileSystemWatcher.EnableRaisingEvents = true;

            Console.WriteLine($"Folder wejściowy:\t{inputFolder}");
            Console.WriteLine($"Folder wyjściowy:\t{outputFolder}");

            Console.WriteLine();
            Console.WriteLine("Naciśnij enter, aby zakończyć program.");
            Console.WriteLine();

            Console.ReadLine();

            if(isProcessRunning)
            {
                Console.ResetColor();
                Console.WriteLine("Oczekiwanie na zakończenie procesu...");
                while (isProcessRunning) ;
            }
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            // Komunikat o wykryciu nowego pliku
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Wykryto:\t{e.Name}");

            // Długość nazwy pliku zakończonej ".mkv"
            int nameLength = e.Name.Length;

            // Nazwa pliku po zmianie rozszerzenia na ".mp4"
            string outputFileName = $"{e.Name.Substring(0, nameLength - 4)} (360p).mp4";

            // Pełna ścieżka do pliku wyjściowego
            string outputFullPath = $"{outputFolder}\\{outputFileName}";

            // Proces FFmpeg
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = "C:\\FFmpeg\\bin";
            process.StartInfo.Arguments = $"/C ffmpeg -i \"{e.FullPath}\" -r 30 -s {outputResolution} -n \"{outputFullPath}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Rozpoczęcie procesu
            isProcessRunning = true;
            process.Start();

            // OCzekiwanie na zakończenie procesu
            process.WaitForExit();
            isProcessRunning = false;

            if (process.ExitCode == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Zapisano:\t{outputFileName}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd zapisu:\t{outputFileName}");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}