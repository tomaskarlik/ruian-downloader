using RUIANDownloader.Models;
using RUIANDownloader.Services.Utils;
using System.Globalization;

namespace RUIANDownloader.Interfaces.Models
{

    internal static class IAddressExtensions
    {

        internal static IAddress Assign(this IAddress address, string[] fields)
        {
            if (fields == null || fields.Length < 19)
            {
                throw new AddressDownloaderException(
                    operation: nameof(Assign),
                    message: string.Format("Invalid fields count. Fields: {0}", (fields == null ? "N/A" : string.Join(",", fields)))
                );
            }

            List<string> errors = [];

            // ID
            if (!string.IsNullOrWhiteSpace(fields[0]) && int.TryParse(fields[0], out int id))
            {
                address.Id = id;
            }
            else
            {
                errors.Add(string.Format("Missing or invalid field [0] {0}. Value: {1}", nameof(address.Id), fields[0]));
            }

            // MunicipalityId
            if (!string.IsNullOrWhiteSpace(fields[1]) && int.TryParse(fields[1], out int municipalityId))
            {
                address.MunicipalityId = municipalityId;
            }
            else
            {
                errors.Add(string.Format("Missing or invalid field [1] {0}. Value: {1}", nameof(address.MunicipalityId), fields[1]));
            }

            // Name
            if (!string.IsNullOrWhiteSpace(fields[2]))
            {
                address.Name = fields[2].Trim();
            }
            else
            {
                errors.Add(string.Format("Missing or invalid field [2] {0}. Value: {1}", nameof(address.Name), fields[2]));
            }

            // MunicipalityDistrictId
            if (!string.IsNullOrWhiteSpace(fields[3]))
            {
                if (int.TryParse(fields[3], out int municipalityDistrictId))
                {
                    address.MunicipalityDistrictId = municipalityDistrictId;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [3] {0}. Value: {1}", nameof(address.MunicipalityDistrictId), fields[3]));
                }
            }
            else
            {
                address.MunicipalityDistrictId = null;
            }

            // MunicipalityDistrictName
            address.MunicipalityDistrictName = fields[4]?.TrimToNull();

            // MunicipalityPrgDistrictId
            if (!string.IsNullOrWhiteSpace(fields[5]))
            {
                if (int.TryParse(fields[5], out int municipalityPrgDistrictId))
                {
                    address.MunicipalityPrgDistrictId = municipalityPrgDistrictId;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [5] {0}. Value: {1}", nameof(address.MunicipalityPrgDistrictId), fields[5]));
                }
            }
            else
            {
                address.MunicipalityPrgDistrictId = null;
            }

            // MunicipalityPrgDistrictName
            address.MunicipalityPrgDistrictName = fields[6]?.TrimToNull();

            // MunicipalityPartId
            if (!string.IsNullOrWhiteSpace(fields[7]))
            {
                if (int.TryParse(fields[7], out int municipalityPartId))
                {
                    address.MunicipalityPartId = municipalityPartId;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [7] {0}. Value: {1}", nameof(address.MunicipalityPartId), fields[7]));
                }
            }
            else
            {
                address.MunicipalityPartId = null;
            }

            // MunicipalityPartName
            address.MunicipalityPartName = fields[8]?.TrimToNull();

            // StreetId
            if (!string.IsNullOrWhiteSpace(fields[9]))
            {
                if (int.TryParse(fields[9], out int streetId))
                {
                    address.StreetId = streetId;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [9] {0}. Value: {1}", nameof(address.StreetId), fields[9]));
                }
            }
            else
            {
                address.StreetId = null;
            }

            // StreetName
            address.StreetName = fields[10]?.TrimToNull();

            // TypeOfBuilding
            if (!string.IsNullOrWhiteSpace(fields[11]))
            {
                var typeOfBuilding = fields[11].ToLower().Trim();
                switch (typeOfBuilding)
                {
                    case "č.p.":
                        address.TypeOfBuilding = TypeOfBuilding.CP;
                        break;
                    case "č.ev.":
                        address.TypeOfBuilding = TypeOfBuilding.CEv;
                        break;
                    default:
                        errors.Add(string.Format("Invalid field [11] {0}. Value: {1}", nameof(address.TypeOfBuilding), fields[11]));
                        break;
                }
            }
            else
            {
                errors.Add(string.Format("Missing field [11] {0}. Value: {1}", nameof(address.TypeOfBuilding), fields[11]));
            }

            // BuildingNumber
            if (!string.IsNullOrWhiteSpace(fields[12]) && int.TryParse(fields[12], out int buildingNumber))
            {
                address.BuildingNumber = buildingNumber;
            }
            else
            {
                errors.Add(string.Format("Missing or invalid field [12] {0}. Value: {1}", nameof(address.BuildingNumber), fields[12]));
            }

            // OrientationNumber
            if (!string.IsNullOrWhiteSpace(fields[13]))
            {
                if (int.TryParse(fields[13], out int orientationNumber))
                {
                    address.OrientationNumber = orientationNumber;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [13] {0}. Value: {1}", nameof(address.OrientationNumber), fields[13]));
                }
            }
            else
            {
                address.OrientationNumber = null;
            }

            // OrientationNumberChar
            address.OrientationNumberChar = fields[14]?.TrimToNull();

            // PostCode
            if (!string.IsNullOrWhiteSpace(fields[15]) && int.TryParse(fields[15], out int postCode))
            {
                address.PostCode = postCode;
            }
            else
            {
                errors.Add(string.Format("Missing or invalid field [15] {0}. Value: {1}", nameof(address.PostCode), fields[15]));
            }

            // CoordinateY
            if (!string.IsNullOrWhiteSpace(fields[16]))
            {
                if (double.TryParse(fields[16], CultureInfo.InvariantCulture, out double coordinateY))
                {
                    address.CoordinateY = coordinateY;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [16] {0}. Value: {1}", nameof(address.CoordinateY), fields[16]));
                }
            }
            else
            {
                address.CoordinateY = null;
            }

            // CoordinateX
            if (!string.IsNullOrWhiteSpace(fields[17]))
            {
                if (double.TryParse(fields[17], CultureInfo.InvariantCulture, out double coordinateX))
                {
                    address.CoordinateX = coordinateX;
                }
                else
                {
                    errors.Add(string.Format("Invalid field [17] {0}. Value: {1}", nameof(address.CoordinateX), fields[17]));
                }
            }
            else
            {
                address.CoordinateX = null;
            }

            // ValidFrom
            if (!string.IsNullOrWhiteSpace(fields[18]) && DateTime.TryParse(fields[18], out DateTime validFrom))
            {
                address.ValidFrom = validFrom;
            }
            else
            {
                errors.Add(string.Format("Missing or invalid field [18] {0}. Value: {1}", nameof(address.ValidFrom), fields[18]));
            }

            // errors
            if (errors.Count > 0)
            {
                throw new AddressDownloaderException(
                    operation: nameof(Assign),
                    message: string.Format("Errors: {0}.", string.Join("\n", errors))
                );
            }

            return address;
        }

    }

}
