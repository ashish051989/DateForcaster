using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Forcast
{
    public class DateForcast
    {
        public string DayOfTheWeek { get; set; }
        public bool IsURLProvided { get; set; }
        public DateCollection Date { get; set; }
    }

    public class DateCollection
    {
        public DateTime CurrentDate { get; set; }
        public DateTime TomorrowsDate { get; set; }
        public DateTime DayAfterTomorrowsDate { get; set; }
    }
}
