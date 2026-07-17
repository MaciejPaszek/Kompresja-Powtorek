using System.Net.Http;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace Discord_Test
{
    internal class Program
    {
        // Wklej tutaj adres swojego webhooka
        private const string WebhookUrl = "https://discord.com/api/webhooks/1527670181789438123/HwcJ8NTXmfJoc7Sgrw8dQts8eQzy44SlQnE8MrS23F6RTKUmg18GL8jTj4KoH5uPlmQ_";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
      
            VideoSend();

            Console.WriteLine("Hello, World!");
            Console.ReadLine();


        }

        public static async void VideoSend()
        {
            try
            {
                string filePath = "C:\\Users\\macie\\Wideo Lokalne\\OBS Studio\\Klipy 360p\\Replay 2026-07-16 21-48-44 (720p, 30 FPS).mp4";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Nie znaleziono pliku video.mp4");
                    return;
                }

                using HttpClient client = new();

                using MultipartFormDataContent form = new();

                // Wiadomość
                form.Add(new StringContent("Film wysłany z aplikacji Windows Forms"), "content");

                // Plik
                byte[] fileBytes = await File.ReadAllBytesAsync(filePath);

                ByteArrayContent fileContent = new(fileBytes);
                fileContent.Headers.ContentType =
                    new MediaTypeHeaderValue("video/mp4");

                form.Add(fileContent, "files[0]", "video.mp4");

                HttpResponseMessage response =
                    await client.PostAsync(WebhookUrl, form);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Film został wysłany.");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(
                        $"Błąd:\n{response.StatusCode}\n\n{error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
