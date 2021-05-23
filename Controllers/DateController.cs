using System;
using System.Threading.Tasks;
using Cis_part2.Dtos.Dates;
using Cis_part2.Services.Date;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cis_part2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DateController:ControllerBase
    {
        public readonly IDatesService _idateService;

        public DateController(IDatesService datesService)
        {
            _idateService = datesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _idateService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _idateService.GetById(id));
        }
        [HttpGet("{times}")]
        public async Task<IActionResult> GetByTimes(DateTime times)
        {
            return Ok(await _idateService.GetByTime(times));
        }
        [HttpPost]
        public async Task<IActionResult> AddDates(AddDatesDto add)
        {
            return Ok(await _idateService.Add(add));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDates(int id, UpdateDatesDto update)
        {
            return Ok(await _idateService.Update(id, update));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDates(int id)
        {
            return Ok(await _idateService.Delete(id));
        }
    }
}