using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cis_part2.Data;
using Cis_part2.Dtos.Scores;
using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Services.Scores
{
    public class ScoreService : IScoreService
    {
        public CisDBContext db;
        public IMapper _mapper;

        public ScoreService(CisDBContext dBContext, IMapper mapper)
        {
            db = dBContext;
            _mapper = mapper;
        }

        public async Task<ServicesResponse<GetScoreDto>> Add(int asspectId, AddScoreDto addScore)
        {
            ServicesResponse<GetScoreDto> services = new ServicesResponse<GetScoreDto>();
            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == asspectId);
            if (asspect == null) throw new Exception("Not Found");

            var scores = _mapper.Map<AddScoreDto, Score>(addScore);
            scores.AsspectId = asspect.Id;
            await db.Score.AddAsync(scores);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetScoreDto>(scores);
            return services;
        }

        public async Task<ServicesResponse<List<GetScoreDto>>> Delete(int asspectId, int id)
        {
            ServicesResponse<List<GetScoreDto>> services = new ServicesResponse<List<GetScoreDto>>();
            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == asspectId);
            if (asspect == null) throw new Exception("Not Found");

            var scores = await db.Score.FirstOrDefaultAsync(c => c.Id == id);
            if (scores == null) throw new Exception("Not Found");

            db.Score.Remove(scores);
            await db.SaveChangesAsync();
            services.Data = await db.Score.Select(c => _mapper.Map<GetScoreDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<List<GetScoreDto>>> GetAll(int asspectId)
        {
            ServicesResponse<List<GetScoreDto>> services = new ServicesResponse<List<GetScoreDto>>();
            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == asspectId);
            if (asspect == null) throw new Exception("Not Found");

            services.Data = await db.Score.Select(c => _mapper.Map<GetScoreDto>(c)).ToListAsync();
            return services;
        }

        public async Task<ServicesResponse<GetScoreDto>> GetById(int asspectId, int id)
        {
            ServicesResponse<GetScoreDto> services = new ServicesResponse<GetScoreDto>();
            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == asspectId);
            if (asspect == null) throw new Exception("Not Found");

            var scores = await db.Score.FirstOrDefaultAsync(c => c.Id == id);
            services.Data = _mapper.Map<GetScoreDto>(scores);
            return services;
        }

        public async Task<ServicesResponse<GetScoreDto>> Update(int asspectId, int id, UpdateScoreDto updateScore)
        {
            ServicesResponse<GetScoreDto> services = new ServicesResponse<GetScoreDto>();
            var asspect = await db.Asspect.FirstOrDefaultAsync(c => c.Id == asspectId);
            if (asspect == null) throw new Exception("Not Found");
            
            var scores = await db.Score.FirstOrDefaultAsync(c => c.Id == id);
            _mapper.Map(updateScore, scores);
            db.Score.Update(scores);
            await db.SaveChangesAsync();
            services.Data = _mapper.Map<GetScoreDto>(scores);
            return services;
        }
    }
}