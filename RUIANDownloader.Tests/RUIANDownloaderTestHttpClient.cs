using RUIANDownloader.Models;
using RUIANDownloader.Services.Http;
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

            Assert.AreEqual(true, result.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

    }

}
