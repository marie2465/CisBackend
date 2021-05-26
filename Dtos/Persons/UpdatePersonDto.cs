using System.ComponentModel.DataAnnotations;

namespace Cis_part2.Dtos.Persons
{
    public class UpdatePersonDto
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public int? MemberId { get; set; }
        [Required] public int? SkillsID { get; set; }
        [Required] public int? RolesId { get; set; }
    }
}