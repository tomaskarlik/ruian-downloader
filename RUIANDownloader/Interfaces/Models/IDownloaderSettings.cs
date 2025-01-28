using System.Net;
using System.Text;

namespace RUIANDownloader.Interfaces.Models
{

    public interface IDownloaderSettings
    {

        /// <summary>
        /// CSV URL
        /// Placeholder {DATE} will been replaced with version
        /// </summary>
        string CsvFileURL { get; set; }


        /// <summary>
        /// CSV Encoding
        /// </summary>
        Encoding Encoding { get; set; }


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

    }

}
