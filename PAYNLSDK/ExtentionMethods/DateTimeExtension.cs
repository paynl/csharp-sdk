using System;

namespace PayNLSdk.ExtentionMethods
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Get the first day of the previous week
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        /// <remarks>
        /// original from https://stackoverflow.com/a/41784250/97615
        /// </remarks>
        public static DateTime LastWeek(this DateTime date, DayOfWeek dow)
        {
            var dayOfWeek = (int)date.DayOfWeek - 1;
            if (dayOfWeek < 0) dayOfWeek = 6;

            var thisWeeksMonday = date.AddDays(-dayOfWeek).Date;
            return thisWeeksMonday.AddDays(-7);
        }

        /// <summary>
        /// Get this weeks' monday
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime ThisWeek(this DateTime date, DayOfWeek dow)
        {
            var dayOfWeek = (int)date.DayOfWeek - 1;
            if (dayOfWeek < 0) dayOfWeek = 6;

            return date.AddDays(-dayOfWeek).Date;
        }

        /// <summary>
        /// Get the first day of the previous month
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>

        public static DateTime LastMonthFirstDay(this DateTime currentDate)
        {
            DateTime d = currentDate.LastMonthLastDay();

            return new DateTime(d.Year, d.Month, 1);
        }

        /// <summary>
        /// get the last months last day
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateTime LastMonthLastDay(this DateTime currentDate)
        {
            return new DateTime(currentDate.Year, currentDate.Month, 1).AddDays(-1);
        }
    }
}
