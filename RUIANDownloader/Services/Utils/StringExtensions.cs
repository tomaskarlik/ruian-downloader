namespace RUIANDownloader.Services.Utils
{

    internal static class StringExtensions
    {

        internal static string? TrimToNull(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }

    }

}
