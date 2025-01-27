using System.Net;

namespace RUIANDownloader.Interfaces.Models
{

    public interface IDownloaderSettings
    {

        /// <summary>
        /// CZUK Atom Service - RUIAN-CSV-ADR-OB
        /// </summary>
        string AtomServiceURL { get; set; }


        int MaxNumberOfDownloadAttempts { get; set; }


        /// <summary>
        /// Delay between unsuccessful attempts in ms
        /// </summary>
        int RetryDownloadDelay { get; set; }


        /// <summary>
        /// HTTP client - UseProxy
        /// </summary>
        bool UseProxy { get; set; }


        /// <summary>
        /// HTTP client - Proxy use default credentials
        /// </summary>
        bool UseDefaultCredentials { get; set; }


        /// <summary>
        /// HTTP client - Proxy settings
        /// </summary>
        IWebProxy? Proxy { get; set; }


        /// <summary>
        /// HTTP client - Proxy default credentials
        /// </summary>
        ICredentials? DefaultProxyCredentials { get; set; }


        /// <summary>
        /// HTTP client - User-Agent header
        /// </summary>
        string UserAgent { get; set; }


        /// <summary>
        /// HTTP client - request timeout in ms
        /// </summary>
        int Timeout { get; set; }


        /// <summary>
        /// Delay between requests in ms
        /// </summary>
        int RequestDelay { get; set; }

    }

}
