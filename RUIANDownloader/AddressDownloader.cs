using RUIANDownloader.Interfaces.Models;
using RUIANDownloader.Models;
using RUIANDownloader.Models.RUIAN;
using RUIANDownloader.Services.Http;
using RUIANDownloader.Services.Utils;
using RUIANDownloader.Services.Xml;

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


        public async Task DownloadAsync()
        {
            // main feed
            if (!Uri.TryCreate(this._downloaderSettings.AtomServiceURL, UriKind.Absolute, out Uri? atomSvcUri))
            {
                throw new AddressDownloaderException("Settings", "Invalid URI.");
            }

            var atomFeed = await this.ProcessAtomFeedAsync(atomSvcUri);
            foreach (var entry in atomFeed.Entry)
            {
                if (!Uri.TryCreate(entry.Id, UriKind.Absolute, out Uri? entryUri))
                {
                    throw new AddressDownloaderException(
                        operation: "Proccess entry.",
                        message: string.Format("Invalid URI \"{0}\".", entry.Id)
                    );
                }

                var entryData = await this.ProcessAtomFeedAsync(entryUri);
                // TODO
            }
        }


        private async Task<AtomFeed> ProcessAtomFeedAsync(Uri uri)
        {
            // download feed
            string tmpFileFeed;
            int attemp = 1;

            do
            {
                try
                {
                    tmpFileFeed = await this._httpClient.DownloadFileToTempAsync(uri);
                    break;

                }
                catch (Exception ex)
                {
                    if (attemp >= this._downloaderSettings.MaxNumberOfDownloadAttempts)
                    {
                        throw new AddressDownloaderException(
                            operation: string.Format("File download: {0}, attemps: {1}", uri.AbsolutePath, attemp),
                            message: ex.Message,
                            innerException: ex
                        );
                    }

                    await Task.Delay(this._downloaderSettings.RetryDownloadDelay);
                    attemp++;

                    continue;
                }

            } while (true);

            // deserialize feed
            AtomFeed? atomFeed = null;
            try
            {
                atomFeed = XmlDeserializer.Deserialize<AtomFeed>(tmpFileFeed);

            }
            catch (Exception ex)
            {
                throw new AddressDownloaderException(
                   string.Format("File deserialization: {0}", uri.AbsolutePath), ex.Message, ex
               );

            }
            finally
            {
                if (File.Exists(tmpFileFeed))  // cleanup
                {
                    File.Delete(tmpFileFeed);
                }
            }

            return (AtomFeed)atomFeed!;
        }

    }

}
