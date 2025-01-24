using RUIANDownloader.Models;

namespace RUIANDownloader.Services.Http
{

    public static class HttpClientFactory
    {

        public static HttpClientHandler Create(DownloaderSettings downloaderSettings)
        {
            return new HttpClientHandler()
            {
                UseProxy = downloaderSettings.UseProxy,
                UseDefaultCredentials = downloaderSettings.UseDefaultCredentials,
                Proxy = downloaderSettings.UseProxy ? downloaderSettings.Proxy : null,
                DefaultProxyCredentials = downloaderSettings.DefaultProxyCredentials
            };
        }

    }

}
