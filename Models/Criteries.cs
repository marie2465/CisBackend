
namespace Cis_part2.Models
{
    public class Criteries
    {
        public int Id { get; set; }
        public string Letter { get; set; }
        public string Name { get; set; }
        public double Mark { get; set; }
        public int SkillsId { get; set; }
        public Skills Skills { get; set; }
    }
}