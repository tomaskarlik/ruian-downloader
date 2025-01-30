using RUIANDownloader.Services.Utils;

namespace RUIANDownloader.Models
{

    internal static class AddressExtensions
    {

        internal static Address Assign(this Address address, string[] fields)
        {
            if (fields == null || fields.Length < 19)
            {
                throw new ArgumentException("Invalid fields count.", nameof(fields));
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

            //  TODO

            if (errors.Count > 0)
            {
                throw new ArgumentException(string.Format("Errors: {0}.", string.Join(", ", errors)), nameof(fields));
            }

            return address;
        }

    }

}
