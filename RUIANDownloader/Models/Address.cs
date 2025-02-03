using RUIANDownloader.Interfaces.Models;

namespace RUIANDownloader.Models
{

    public class Address : IAddress
    {

        public int Id { get; set; }


        public int MunicipalityId { get; set; }


        public string Name { get; set; } = string.Empty;


        public int? MunicipalityDistrictId { get; set; }


        public string? MunicipalityDistrictName { get; set; }


        public int? MunicipalityPrgDistrictId { get; set; }


        public string? MunicipalityPrgDistrictName { get; set; }


        public int? MunicipalityPartId { get; set; }


        public string? MunicipalityPartName { get; set; }


        public int? StreetId { get; set; }


        public string? StreetName { get; set; }


        public TypeOfBuilding TypeOfBuilding { get; set; }


        public int BuildingNumber { get; set; }


        public int? OrientationNumber { get; set; }


        public string? OrientationNumberChar { get; set; }


        public int PostCode { get; set; }


        public double? CoordinateY { get; set; }


        public double? CoordinateX { get; set; }


        public DateTime ValidFrom { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", this.PostCode, this.Name, this.Id);
        }

    }

}
