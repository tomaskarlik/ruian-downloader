using RUIANDownloader.Interfaces.Models;
using RUIANDownloader.Models;
using RUIANDownloader.Services.Http;
using RUIANDownloader.Services.Utils;
using System.IO.Compression;

namespace RUIANDownloader
{

    public class AddressDownloader
    {

        private readonly IDownloaderSettings _downloaderSettings;


        private readonly HttpClient _httpClient;


        public AddressDownloader(
            IDownloaderSettings? downloaderSettings = null,
            HttpClientHandler? httpClientHandler = null
        )
        {
            this._downloaderSettings = downloaderSettings ?? new DownloaderSettings();
            this._httpClient = HttpClientFactory.Create(this._downloaderSettings, httpClientHandler);
        }


        public async Task DownloadAsync(DateTime? dateTime = null)
        {
            string? csvFile = null;

            try
            {
                csvFile = await this.DownloadCsvFileAsync(dateTime);
                this.ExtractFile(csvFile);

            }
            finally
            {
                if (csvFile != null && File.Exists(csvFile))
                {
                    File.Delete(csvFile);
                }
            }
        }


        private async Task<string> DownloadCsvFileAsync(DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now.LastDayInPreviousMonth();

            var csvFileUri = new Uri(
                this._downloaderSettings.CsvFileURL.Replace("{DATE}", dateTime.Value.ToString("yyyyMMdd"))
            );

            string tempFile;
            int attemp = 1;

            do
            {
                try
                {
                    tempFile = await this._httpClient.DownloadFileToTempAsync(csvFileUri);
                    break;

                }
                catch (Exception ex)
                {
                    if (attemp >= this._downloaderSettings.MaxNumberOfDownloadAttempts)
                    {
                        throw new AddressDownloaderException(
                            operation: nameof(DownloadCsvFileAsync),
                            message: string.Format("File download: {0}, Attemps: {1}, Error: {2}", csvFileUri.AbsolutePath, attemp, ex.Message),
                            innerException: ex
                        );
                    }

                    await Task.Delay(this._downloaderSettings.RetryDownloadDelay);
                    attemp++;

                    continue;
                }

            } while (true);

            return tempFile;
        }


        private void ExtractFile(string fileName)
        {
            var tempDirectory = Directory.CreateTempSubdirectory("ruian_");
            using (ZipArchive archive = ZipFile.OpenRead(fileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(tempDirectory.FullName, entry.Name));
                }
            }
        }

    }

}
