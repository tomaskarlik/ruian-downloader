using RUIANDownloader.Models;

namespace RUIANDownloader.Tests
{

    [TestClass]
    public sealed class RUIANDownloaderTestMain
    {

        private const int MinAddressCount = 2990000;


        [TestMethod, Timeout(600000)]
        public async Task AddressDownloaderTestAsync()
        {
            var addressDownloader = new AddressDownloader();
            var records = addressDownloader.DownloadAsync<Address>();

            Assert.IsNotNull(records);

            var count = 0;
            var exists16000 = false;
            var exists61600 = false;

            await foreach (var address in records)
            {
                count++;
                exists16000 = exists16000 || (address.PostCode == 16000);
                exists61600 = exists61600 || (address.PostCode == 61600);
            }

            Assert.IsTrue(count > MinAddressCount);
            Assert.IsTrue(exists16000);
            Assert.IsTrue(exists61600);
        }

    }

}
