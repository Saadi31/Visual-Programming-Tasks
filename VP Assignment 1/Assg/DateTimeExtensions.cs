using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assg
{
    class DateTimeExtensions
    {
        public static int AgeInYears(DateTime age1, DateTime age2)
        {
            return Math.Abs(age1.Year - age2.Year);
        }
        public static int AgeInMonths(DateTime age1, DateTime age2)
        {
            return ((age1.Year - age2.Year) * 12) + (age1.Month - age2.Month);
        }
        public static int AgeInDays(DateTime age1, DateTime age2)
        {
            return Convert.ToInt32(((age1.Year - age2.Year) * 365.25) + (age1.DayOfYear - age2.DayOfYear));
        }

        public static int AgePartYears(DateTime age1, DateTime age2)
        {
            return DateTimeSpan.CompareDates(age1, age2).Years;
        }

        public static int AgePartMonths(DateTime age1, DateTime age2)
        {
            return DateTimeSpan.CompareDates(age1, age2).Months;
        }

        public static int AgePartDays(DateTime age1, DateTime age2)
        {
            return DateTimeSpan.CompareDates(age1, age2).Days;
        }

    }
}
