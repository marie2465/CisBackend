using System.Collections.Generic;
using Cis_part2.Models;

namespace Cis_part2.Dtos.Skills
{
    public class UpdateSkillsDto
    {
        public int Id { get; set; }
        public string CodeSkills { get; set; }
        public string NameSkills { get; set; }
        public int TypeSkillsId { get; set; }
        public List<Sections> Sections { get; set; }
    }
}