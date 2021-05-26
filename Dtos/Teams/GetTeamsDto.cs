using System.Collections.Generic;
using Cis_part2.Dtos.PeopleInTeams;

namespace Cis_part2.Dtos.Teams
{
    public class GetTeamsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SkillsId { get; set; }
        public List<GetPeopleTeamDto> PeopleInTeams { get; set; }
    }
}