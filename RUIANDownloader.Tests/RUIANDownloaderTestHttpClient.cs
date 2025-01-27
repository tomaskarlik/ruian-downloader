using RUIANDownloader.Models;
using RUIANDownloader.Services.Http;
using RUIANDownloader.Services.Utils;
using System.Net;

namespace RUIANDownloader.Tests
{

    [TestClass]
    public sealed class RUIANDownloaderTestHttpClient
    {

        [TestMethod]
        public async Task TestHTTPClientAsync()
        {
            var settings = new DownloaderSettings();
            var httpClient = HttpClientFactory.Create(settings);

            var result = await httpClient.GetAsync(settings.AtomServiceURL);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }


        [TestMethod]
        public async Task TestFileDownloadAsync()
        {
            var settings = new DownloaderSettings();
            var httpClient = HttpClientFactory.Create(settings);

            var file = await httpClient.DownloadFileToTempAsync(new Uri(settings.AtomServiceURL));
            var fileInfo = new FileInfo(file);

            Assert.IsTrue(fileInfo.Exists);
            Assert.IsTrue(fileInfo.Length > 0);

            File.Delete(file);
        }

    }

}
