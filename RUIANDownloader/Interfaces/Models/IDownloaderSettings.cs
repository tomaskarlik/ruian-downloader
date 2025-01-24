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

    }

}
