namespace Cis_part2.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string CodeSkills { get; set; }
        public string NameSkills { get; set; }
        public int? TypeSkillsId { get; set; }
        public TypeSkills TypeSkills { get; set; }
    }
}