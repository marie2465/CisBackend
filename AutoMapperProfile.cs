using AutoMapper;
using Cis_part2.Dtos.Asspects;
using Cis_part2.Dtos.Criteries;
using Cis_part2.Dtos.Section;
using Cis_part2.Dtos.Skills;
using Cis_part2.Dtos.SubCritery;
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
            //critery
            CreateMap<Criteries, GetCriteriesDto>();
            CreateMap<AddCriteriesDto, Criteries>();
            CreateMap<UpdateCriteriesDto, Criteries>();
            //sub critery
            CreateMap<SubCriteries, GetSubCriteriesDto>();
            CreateMap<AddSubCriteriesDto, SubCriteries>();
            CreateMap<UpdateSubCriteriesDto, SubCriteries>();
            //asspect
            CreateMap<Asspect, GetAsspectDto>();
            CreateMap<AddAsspectDto, Asspect>();
            CreateMap<UpdateAsspectDto, Asspect>();
        }
    }
}