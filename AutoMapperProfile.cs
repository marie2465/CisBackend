using AutoMapper;
using Cis_part2.Dtos.Asspect;
using Cis_part2.Dtos.Section;
using Cis_part2.Dtos.Skills;
using Cis_part2.Models;

namespace Cis_part2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Skills
            CreateMap<Skills, GetSkillsDto>();
            CreateMap<AddSkillsDto, Skills>();
            CreateMap<UpdateSkillsDto, Skills>();
            //section
            CreateMap<Sections, GetSectionDto>();
            CreateMap<AddSectionDto, Sections>();
            CreateMap<UpdateSectionDto, Sections>();
            //asspect
            CreateMap<Asspects, GetAsspectDto>();
            CreateMap<AddAsspectDto,Asspects>();
            CreateMap<UpdateAsspectDto, Asspects>();
        }
    }
}