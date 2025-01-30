﻿namespace RUIANDownloader.Services.Utils
{

    internal static class StringExtensions
    {

        public static string? TrimToNull(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }

    }

}
