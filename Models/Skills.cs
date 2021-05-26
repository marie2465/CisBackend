using System.Collections.Generic;

namespace Cis_part2.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string CodeSkills { get; set; }
        public string NameSkills { get; set; }
        public int TypeSkillsId { get; set; }
        public TypeSkills TypeSkills { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Sections> Sections { get; set; }
        public List<Criteries> Criteries { get; set; }
        public List<Person> Person { get; set; }
    }
}