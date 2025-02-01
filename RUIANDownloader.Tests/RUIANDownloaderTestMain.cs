using DotNet.Sdk.Extensions.Testing.HttpMocking.HttpMessageHandlers;
using DotNet.Sdk.Extensions.Testing.HttpMocking.HttpMessageHandlers.ResponseMocking;
using RUIANDownloader.Models;
using System.Net;
using System.Net.Http.Headers;

namespace RUIANDownloader.Tests
{

    [TestClass]
    public sealed class RUIANDownloaderTestMain
    {

        private const int AddressCount = 2;


        private const string TestUri = "http://vdp.cuzk.cz/vymenny_format/csv/";


        private const int TestPostCode = 545465;


        [TestMethod]
        public async Task AddressDownloaderTestAsync()
        {
            // create http mocks
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "MockData1.zip");
            var handler = this.CreateHttpHandlerMock(file);

            // run downloader
            var addressDownloader = new AddressDownloader(null, handler);
            var records = addressDownloader.DownloadAsync<Address>();

            Assert.IsNotNull(records);

            var count = 0;
            await foreach (var address in records)
            {
                count++;
                Assert.AreEqual(address.PostCode, TestPostCode);
            }

            Assert.IsTrue(count == AddressCount);
        }


        private TestHttpMessageHandler CreateHttpHandlerMock(string file)
        {
            // prepare http mocks
            var httpResponseMessageMock = new HttpResponseMessageMockBuilder()
                .Where(httpRequestMessage =>
                {
                    return httpRequestMessage.Method == HttpMethod.Get &&
                        httpRequestMessage.RequestUri.AbsoluteUri.StartsWith(TestUri);
                })
                .RespondWith(httpRequestMessage =>
                {
                    var fileBytes = File.ReadAllBytes(file);
                    var content = new ByteArrayContent(fileBytes);
                    content.ReadAsByteArrayAsync();

                    var response = new HttpResponseMessage
                    {
                        Content = content,
                        StatusCode = HttpStatusCode.OK
                    };

                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");

                    return response;
                })
                .Build();

            // add the mocks to the http handler
            var handler = new TestHttpMessageHandler();
            handler.MockHttpResponse(httpResponseMessageMock);

            return handler;
        }

    }

}
