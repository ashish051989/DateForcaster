using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Forcast;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.ForcastService;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DateForecastController : ControllerBase
    {
        private readonly IForcastService _forcastService;

        public DateForecastController(IForcastService forcastService)
        {
            _forcastService = forcastService;
        }

        [HttpGet(Name = "{url}")]
        public async Task<IActionResult> Get(string url)
        {
            var result = await _forcastService.GetDates(string.IsNullOrEmpty(url) ? false : true);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<RequestDate> dates)
        {
            var result = await _forcastService.AddDates(dates);
            return Ok(result);
        }
    }
}
