namespace Cis_part2.Dtos.Skills
{
    public class GetSkillsDto
    {
        public int Id { get; set; }
        public string CodeSkills { get; set; }
        public string NameSkills { get; set; }
        public int? TypeSkillsId { get; set; }
    }
}