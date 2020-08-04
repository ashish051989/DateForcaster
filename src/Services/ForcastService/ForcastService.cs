using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Forcast;

namespace Services.ForcastService
{
    public class ForcastService : IForcastService
    {
        public Task<List<DateForcast>> AddDates(List<RequestDate> dates)
        {
            return Task.FromResult(GetForcasts(dates).ToList());
        }

        public Task<List<DateForcast>> GetDates(bool isUrlProvided)
        {
            var dates = GetDates().ToList();
            return Task.FromResult(GetForcasts(dates, isUrlProvided).ToList());
        }

        private IEnumerable<DateForcast> GetForcasts(bool isUrlProvided)
        {
            return Enumerable.Range(0, 7).Select(s => new DateForcast
            {
                DayOfTheWeek = $"{s} {DateTime.Today.AddDays(s).DayOfWeek}",
                IsURLProvided = isUrlProvided,
                Date = new DateCollection
                {
                    CurrentDate = DateTime.Now.AddDays(s),
                    TomorrowsDate = DateTime.Now.AddDays(s + 1),
                    DayAfterTomorrowsDate = DateTime.Now.AddDays(s + 2)
                }
            });
        }

        private IEnumerable<RequestDate> GetDates()
        {
            for (int i = 0; i < 7; i++)
            {
                var dates = new RequestDate
                {
                    Date = DateTime.Now.AddDays(i).ToString("MM/dd/yyyy hh:mm")
                };

                yield return dates;
            }
        }

        private IEnumerable<DateForcast> GetForcasts(List<RequestDate> dates, bool isUrlProvided = false)
        {
            for (int i = 0; i < 7; i++)
            {
                var currentDate = ParseDateTime(dates[i].Date);

                var forcast = new DateForcast
                {
                    DayOfTheWeek = $"{i} {currentDate.DayOfWeek}",
                    IsURLProvided = isUrlProvided,
                    Date = new DateCollection
                    {
                        CurrentDate = currentDate,
                        TomorrowsDate = currentDate.AddDays(1),
                        DayAfterTomorrowsDate = currentDate.AddDays(2)
                    }
                };

                yield return forcast;
            }

        }

        private DateTime ParseDateTime(string dateTime)
        {
            DateTime.TryParse(dateTime, out DateTime date);
            return date;
        }
    }
}

