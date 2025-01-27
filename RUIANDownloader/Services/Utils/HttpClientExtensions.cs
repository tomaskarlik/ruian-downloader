namespace RUIANDownloader.Services.Utils
{

    internal static class HttpClientExtensions
    {

        internal static async Task DownloadFileTaskAsync(this HttpClient client, Uri uri, string fileName)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var fileInfo = new FileInfo(fileName);

            using (var fileStream = fileInfo.OpenWrite())
            {
                await stream.CopyToAsync(fileStream);
            }
        }


        internal static async Task<string> DownloadFileToTempAsync(this HttpClient client, Uri uri)
        {
            var file = Path.GetTempFileName();

            try
            {
                await client.DownloadFileTaskAsync(uri, file);

            }
            catch (Exception)
            {
                if (File.Exists(file))  // cleanup
                {
                    File.Delete(file);
                }

                throw;
            }

            return file;
        }

    }

}
