namespace Cis_part2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? MemberId { get; set; }
        public Member Member { get; set; }
        public int? SkillsID { get; set; }
        public Skills Skills { get; set; }
        public int? RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}