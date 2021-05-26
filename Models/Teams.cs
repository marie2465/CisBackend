using System.Collections.Generic;

namespace Cis_part2.Models
{
    public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SkillsId { get; set; }
        public Skills Skills { get; set; }
        public List<PeopleInTeams> PeopleInTeams { get; set; }
    }
}