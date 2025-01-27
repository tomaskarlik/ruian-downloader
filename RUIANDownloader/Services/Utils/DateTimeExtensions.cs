namespace RUIANDownloader.Services.Utils
{

    internal static class DateTimeExtensions
    {

        internal static DateTime LastDayInPreviousMonth(this DateTime current)
        {
            var month = current.Month;
            var year = current.Year;

            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            int daysInMonth = DateTime.DaysInMonth(year, month);

            return new DateTime(year, month, daysInMonth, 0, 0, 0, 0, current.Kind);
        }

    }

}
