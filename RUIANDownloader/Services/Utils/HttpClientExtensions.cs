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
            var fileStream = fileInfo.OpenWrite();

            try
            {
                await stream.CopyToAsync(fileStream);

            }
            finally
            {
                fileStream?.Close();
                stream?.Close();
                response?.Dispose();
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
