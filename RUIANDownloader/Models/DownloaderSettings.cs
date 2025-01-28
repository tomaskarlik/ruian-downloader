using RUIANDownloader.Interfaces.Models;
using System.Net;
using System.Text;

namespace RUIANDownloader.Models
{

    public class DownloaderSettings : IDownloaderSettings
    {

        public string CsvFileURL { get; set; } = @"http://vdp.cuzk.cz/vymenny_format/csv/{DATE}_OB_ADR_csv.zip";


        public Encoding Encoding { get; set; } = CodePagesEncodingProvider.Instance.GetEncoding("Windows-1250")!;


        public char Delimiter { get; set; } = ';';


        public char Quote { get; set; } = '"';


        public bool IgnoreFirstLine { get; set; } = true;


        public int MaxNumberOfDownloadAttempts { get; set; } = 3;


        public int RetryDownloadDelay { get; set; } = 1500;


        public bool UseProxy { get; set; } = false;


        public bool UseDefaultCredentials { get; set; } = true;


        public IWebProxy? Proxy { get; set; } = null;


        public ICredentials? DefaultProxyCredentials { get; set; } = null;


        public string UserAgent { get; set; } = "RUIANDownloader";


        public int Timeout { get; set; } = 30000;

    }

}
