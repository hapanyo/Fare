using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fare.Models.Extensions
{
    public static class DateExtensions
    {
        private static readonly TimeSpan StartOfNightHours = new TimeSpan(20, 0, 0);
        private static readonly TimeSpan EndOfNightHours = new TimeSpan(6, 0, 0);
        private static readonly TimeSpan StartOfPeakHours = new TimeSpan(16, 0, 0);
        private static readonly TimeSpan EndOfPeakHours = new TimeSpan(20, 0, 0);

        public static bool IsWeekend(this DateTime value)
        {

            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        public static bool IsPeakHour(this DateTime value)
        {
            return !value.IsWeekend() && value.TimeOfDay >= StartOfPeakHours && value.TimeOfDay < EndOfPeakHours;
        }

        public static bool IsNight(this DateTime value)
        {
            if (value.TimeOfDay < EndOfNightHours || value.TimeOfDay >= StartOfNightHours)
            {
                return true;
            }
            if (StartOfNightHours < EndOfNightHours)
            {
                return value.TimeOfDay >= StartOfNightHours && value.TimeOfDay < EndOfNightHours;
            }

            return false;
        }
    }
}