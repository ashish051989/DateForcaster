using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO.Forcast;

namespace Services.ForcastService
{
    public interface IForcastService
    {
        Task<List<DateForcast>> GetDates(bool isUrlProvided);

        Task<List<DateForcast>> AddDates(List<RequestDate> dates);
    }
}
