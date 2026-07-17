using System.Net.Http.Headers;

namespace Kompresja_Powtórek_GUI
{
    internal class Discord
    {
        public Discord()
        {

        }

        public string WebhookURL = string.Empty;

        public async void Send(string outputFilePath, string outputFileName)
        {
            if (WebhookURL == null || WebhookURL == string.Empty)
            {
                MessageBox.Show("Webhook jest pusty");
                return;
            }

            try
            {
                if (!File.Exists(outputFilePath))
                {
                    MessageBox.Show("Nie znaleziono pliku video.mp4");
                    return;
                }

                using HttpClient client = new();

                using MultipartFormDataContent form = new();

                // Wiadomość
                //form.Add(new StringContent("Film wysłany z aplikacji Windows Forms"), "content");

                // Plik
                byte[] fileBytes = await File.ReadAllBytesAsync(outputFilePath);

                ByteArrayContent fileContent = new(fileBytes);
                fileContent.Headers.ContentType =
                    new MediaTypeHeaderValue("video/mp4");

                form.Add(fileContent, "files[0]", outputFileName);

                HttpResponseMessage response =
                    await client.PostAsync(WebhookURL, form);

                if (response.IsSuccessStatusCode)
                {
                    //MessageBox.Show("Film został wysłany.");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        $"Błąd:\n{response.StatusCode}\n\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
