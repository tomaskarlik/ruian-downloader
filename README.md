# ruian-downloader
Registr územní identifikace, adres a nemovitostí (RÚIAN) - address downloader for C#

Download from ```http://vdp.cuzk.cz/vymenny_format/csv/<yyyyMMdd>_OB_ADR_csv.zip```

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

    }
    catch (AddressDownloaderException ex)
    {
        Console.WriteLine(ex);
    }
}
```

### Custom settings and implementation of IAddress
```cs
var settings = new DownloaderSettings()
{
    Proxy = new WebProxy() // ex. proxy settings
};

var downloader = new AddressDownloader(settings);
var reader = downloader.DownloadAsync<RUIANAddress>(DateTime.Parse("2025-01-31")); // custom file date

// custom implementation of entity,
// for example ef database entity
[Table("ruian_adresy")]
public class RUIANAddress : IAddress
{

    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("kod_obce")]
    public int MunicipalityId { get; set; }
    
    // ...

}
```
