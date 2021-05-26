using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Persons;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Persons
{
    public class PersonService : IPersonService
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
            ServicesResponse<GetPersonDto> services = new ServicesResponse<GetPersonDto>();
            var persons = _mapper.Map<AddPersonDto, Person>(addPersonDto);
            await db.Person.AddAsync(persons);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetPersonDto>(persons);
            return services;
        }

        public async Task<ServicesResponse<List<GetPersonDto>>> Delete(int id)
        {
            ServicesResponse<List<GetPersonDto>> services = new ServicesResponse<List<GetPersonDto>>();
            var persons = await db.Person.FirstOrDefaultAsync(c => c.Id == id);
            if (persons == null) throw new Exception("Not Found");

            db.Person.Remove(persons);
            await db.SaveChangesAsync();
            services.Data = await db.Person.Select(c => _mapper.Map<GetPersonDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetPersonDto>>> GetAll()
        {
            ServicesResponse<List<GetPersonDto>> services = new ServicesResponse<List<GetPersonDto>>();
            services.Data = await db.Person.Select(c => _mapper.Map<GetPersonDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetPersonDto>> GetById(int id)
        {
            ServicesResponse<GetPersonDto> services = new ServicesResponse<GetPersonDto>();
            var persons = await db.Person.FirstOrDefaultAsync(c => c.Id == id);
            if (persons == null) throw new Exception("Not Found");
            services.Data = _mapper.Map<GetPersonDto>(persons);
            return services;
        }

        public async Task<ServicesResponse<GetPersonDto>> Update(int id, UpdatePersonDto updatePerson)
        {
            ServicesResponse<GetPersonDto> services = new ServicesResponse<GetPersonDto>();
            var persons = await db.Person.FirstOrDefaultAsync(c => c.Id == id);
            if (persons == null) throw new Exception("Not Found");
            _mapper.Map(updatePerson, persons);
            db.Person.Update(persons);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetPersonDto>(persons);
            return services;
        }
    }
}