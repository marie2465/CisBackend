using System.Collections.Generic;
using System.Threading.Tasks;
using Cis_part2.Dtos.Scores;
using Cis_part2.Models;

namespace Cis_part2.Services.Scores
{
    public interface IScoreService
    {
        public Task<ServicesResponse<List<GetScoreDto>>> GetAll(int asspectId);
        public Task<ServicesResponse<GetScoreDto>> GetById(int asspectId, int id);
        public Task<ServicesResponse<GetScoreDto>> Add(int asspectId, AddScoreDto addScore);
        public Task<ServicesResponse<GetScoreDto>> Update(int asspectId, int id, UpdateScoreDto updateScore);
        public Task<ServicesResponse<List<GetScoreDto>>> Delete(int asspectId, int id);
    }
}