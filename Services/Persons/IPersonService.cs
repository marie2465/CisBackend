using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Persons;
using Cis_part2.Models;

namespace Cis_part2.Services.Persons
{
    public interface IPersonService
    {
        public Task<ServicesResponse<List<GetPersonDto>>> GetAll();
        public Task<ServicesResponse<GetPersonDto>> GetById(int id);
        public Task<ServicesResponse<GetPersonDto>> Add(AddPersonDto addPersonDto);
        public Task<ServicesResponse<GetPersonDto>> Update(int id, UpdatePersonDto updatePerson);
        public Task<ServicesResponse<List<GetPersonDto>>> Delete(int id);
    }
}