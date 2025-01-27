using RUIANDownloader.Interfaces.Models;
using System.Net.Http.Headers;

namespace RUIANDownloader.Services.Http
{

    internal static class HttpClientFactory
    {

        private static HttpClient? _httpClient = null;


        internal static HttpClient Create(
            IDownloaderSettings downloaderSettings,
            HttpClientHandler? httpClientHandler = null
        )
        {
            if (_httpClient != null)
            {
                return _httpClient;
            }

            // create client
            _httpClient = new HttpClient(
                handler: httpClientHandler ?? HttpClientHandlerFactory.Create(downloaderSettings)
            );

            // set headers
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/zip")
            );
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/*")
            );

            _httpClient.DefaultRequestHeaders.Add("User-Agent", downloaderSettings.UserAgent);

            // client properties
            _httpClient.Timeout = TimeSpan.FromMilliseconds(downloaderSettings.Timeout);

            return _httpClient;
        }

    }

}
