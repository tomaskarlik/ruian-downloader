using RUIANDownloader.Interfaces.Models;

namespace RUIANDownloader.Models
{

    public class DownloaderSettings : IDownloaderSettings
    {

        public string AtomServiceURL { get; set; } = "https://atom.cuzk.cz/getservicefeed.ashx?service=RUIAN-CSV-ADR-OB";


        public int MaxNumberOfDownloadAttempts { get; set; } = 3;


        public int RetryDownloadDelay { get; set; } = 1500;

    }

}
