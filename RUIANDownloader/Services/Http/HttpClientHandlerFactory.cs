using RUIANDownloader.Interfaces.Models;

namespace RUIANDownloader.Services.Http
{

    internal static class HttpClientHandlerFactory
    {

        internal static HttpClientHandler Create(IDownloaderSettings downloaderSettings)
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
