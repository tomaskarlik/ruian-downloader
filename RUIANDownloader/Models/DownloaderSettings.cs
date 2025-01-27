using RUIANDownloader.Interfaces.Models;
using System.Net;

namespace RUIANDownloader.Models
{

    public class DownloaderSettings : IDownloaderSettings
    {

        public string AtomServiceURL { get; set; } = "https://atom.cuzk.cz/getservicefeed.ashx?service=RUIAN-CSV-ADR-OB";


        public int MaxNumberOfDownloadAttempts { get; set; } = 3;


        public int RetryDownloadDelay { get; set; } = 1500;


        public bool UseProxy { get; set; } = false;


        public bool UseDefaultCredentials { get; set; } = true;


        public IWebProxy? Proxy { get; set; } = null;


        public ICredentials? DefaultProxyCredentials { get; set; } = null;


        public string UserAgent { get; set; } = "RUIANDownloader";


        public int Timeout { get; set; } = 30000;


        public int RequestDelay { get; set; } = 50;

    }

}
