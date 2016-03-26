using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter No. of Siblings");
            var siblingCount = new int();
            int.TryParse(Console.ReadLine(), out siblingCount);
            var siblings = new List<Sibling>();
            for (int i = 1; i < siblingCount + 1; i++)
            {
                Console.Write("Enter the date of birth for sibling as Month - Date - Year" + i.ToString() + ":"); 
                siblings.Add(new Sibling(DateTime.Parse(Console.ReadLine())));
            }
            siblings = siblings.OrderByDescending(x => x.DOB).ToList();

            for (int i = 1; i < siblings.Count + 1; i++)
            {
                var diff = DateTimeSpan.CompareDates(siblings[i - 1].DOB, DateTime.Now);
                Console.WriteLine("Sibling No. " + i + "'s age is: " + diff.Years + " years, " + diff.Months + " months and " + diff.Days + " days.");
            }

            for (var i = 1; i < siblingCount; i++)
            {
                var diff = DateTimeSpan.CompareDates(siblings[i - 1].DOB, siblings[i].DOB);
                Console.WriteLine("Age difference among siblings " + i.ToString() + " and " + (i + 1).ToString() + " is " +
                    diff.Years + " years, " + diff.Months + " months and " + diff.Days + " days.");
            }

            Console.ReadLine();

        }
    }
}




public struct DateTimeSpan
{
    private readonly int years;
    private readonly int months;
    private readonly int days;
    private readonly int hours;
    private readonly int minutes;
    private readonly int seconds;
    private readonly int milliseconds;

    public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
    {
        this.years = years;
        this.months = months;
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
        this.milliseconds = milliseconds;
    }


    public int Years { get { return years; } }
    public int Months { get { return months; } }
    public int Days { get { return days; } }
    public int Hours { get { return hours; } }
    public int Minutes { get { return minutes; } }
    public int Seconds { get { return seconds; } }
    public int Milliseconds { get { return milliseconds; } }

    enum Phase { Years, Months, Days, Done }

    public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
    {
        if (date2 < date1)
        {
            var sub = date1;
            date1 = date2;
            date2 = sub;
        }

        DateTime current = date1;
        int years = 0;
        int months = 0;
        int days = 0;

        Phase phase = Phase.Years;
        DateTimeSpan span = new DateTimeSpan();

        while (phase != Phase.Done)
        {
            switch (phase)
            {
                case Phase.Years:
                    if (current.AddYears(years + 1) > date2)
                    {
                        phase = Phase.Months;
                        current = current.AddYears(years);
                    }
                    else
                    {
                        years++;
                    }
                    break;
                case Phase.Months:
                    if (current.AddMonths(months + 1) > date2)
                    {
                        phase = Phase.Days;
                        current = current.AddMonths(months);
                    }
                    else
                    {
                        months++;
                    }
                    break;
                case Phase.Days:
                    if (current.AddDays(days + 1) > date2)
                    {
                        current = current.AddDays(days);
                        var timespan = date2 - current;
                        span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                        phase = Phase.Done;
                    }
                    else
                    {
                        days++;
                    }
                    break;
            }
        }
        return span;
    }
}