using System.Collections.Generic;
using Cis_part2.Dtos.Criteries;
using Cis_part2.Dtos.Persons;
using Cis_part2.Dtos.Section;
using Cis_part2.Models;

namespace Cis_part2.Dtos.Skills
{
    public class GetSkillsDto
    {
        public int Id { get; set; }
        public string CodeSkills { get; set; }
        public string NameSkills { get; set; }
        public int? TypeSkillsId { get; set; }
        public List<GetSectionDto> Sections { get; set; }
        public List<GetCriteriesDto> Criteries {get;set;}
        public List<GetPersonDto> Person {get;set;}
    }
}