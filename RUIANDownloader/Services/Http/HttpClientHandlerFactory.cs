using RUIANDownloader.Interfaces.Models;

namespace RUIANDownloader.Services.Http
{

    public static class HttpClientHandlerFactory
    {

        public static HttpClientHandler Create(IDownloaderSettings downloaderSettings)
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
