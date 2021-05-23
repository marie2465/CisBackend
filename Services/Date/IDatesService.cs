using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Dates;
using Cis_part2.Models;

namespace Cis_part2.Services.Date
{
    public interface IDatesService
    {
         public Task<ServicesResponse<List<GetDatesDto>>> GetAll();
         public Task<ServicesResponse<GetDatesDto>> GetById(int id);
         public Task<ServicesResponse<List<GetDatesDto>>> GetByTime(DateTime times);
         public Task<ServicesResponse<GetDatesDto>> Add(AddDatesDto add);
         public Task<ServicesResponse<GetDatesDto>> Update(int id, UpdateDatesDto update);
         public Task<ServicesResponse<List<GetDatesDto>>> Delete (int id);         
    }
}