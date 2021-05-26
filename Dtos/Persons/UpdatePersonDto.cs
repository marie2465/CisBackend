namespace Cis_part2.Dtos.Persons
{
    public class UpdatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? MemberId { get; set; }
        public int? SkillsID { get; set; }
        public int? RolesId { get; set; }
    }
}