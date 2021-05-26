using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Persons;
using Cis_part2.Models;

namespace Cis_part2.Services.Persons
{
    public class PersonService:IPersonService
    {
        private readonly CisDBContext db;
        private readonly IMapper _mapper;
        public PersonService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }

        public async Task<ServicesResponse<GetPersonDto>> Add(AddPersonDto addPersonDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServicesResponse<List<GetPersonDto>>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServicesResponse<List<GetPersonDto>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServicesResponse<GetPersonDto>> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServicesResponse<GetPersonDto>> Update(int id, UpdatePersonDto updatePerson)
        {
            throw new System.NotImplementedException();
        }
    }
}