# ruian-downloader
Registr územní identifikace, adres a nemovitostí (RÚIAN) - address downloader for C#

## Example code
```cs
public async Task Main()
{
    var addressDownloader = new AddressDownloader();
    var records = addressDownloader.DownloadAsync<Address>();

    try
    {
        await foreach (var address in records)
        {
            // your logic ...
            Console.WriteLine($"{address.PostCode}, {address.Name}, {address.StreetName} {address.BuildingNumber}");
        }

    } catch (AddressDownloaderException ex)
    {
        Console.WriteLine(ex);
    }
}
```
