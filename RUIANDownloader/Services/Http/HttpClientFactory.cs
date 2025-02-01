using RUIANDownloader.Interfaces.Models;
using System.Net.Http.Headers;

namespace RUIANDownloader.Services.Http
{

    internal static class HttpClientFactory
    {

        internal static HttpClient Create(
            IDownloaderSettings downloaderSettings,
            HttpMessageHandler? httpClientHandler = null
        )
        {
            // create client
            var httpClient = new HttpClient(
                handler: httpClientHandler ?? HttpClientHandlerFactory.Create(downloaderSettings)
            );

            // set headers
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/zip")
            );
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/*")
            );
            httpClient.DefaultRequestHeaders.Add("User-Agent", downloaderSettings.UserAgent);

            // client properties
            httpClient.Timeout = TimeSpan.FromMilliseconds(downloaderSettings.Timeout);

            return httpClient;
        }

    }

}
