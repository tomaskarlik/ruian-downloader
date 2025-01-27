namespace RUIANDownloader.Tests
{

    [TestClass]
    public sealed class RUIANDownloaderTestMain
    {

        [TestMethod, Timeout(600000)]
        public async Task AddressDownloaderTestAsync()
        {
            var addressDownloader = new AddressDownloader();
            await addressDownloader.DownloadAsync();

            Assert.AreEqual(true, true); // TODO
        }

    }

}
