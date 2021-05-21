using System.Collections.Generic;

namespace Cis_part2.Models
{
    public class Sections
    {
        public int Id { get; set; }
        public string NameSection { get; set; }
        public double Importance { get; set; }
        public int SkillsId { get; set; }
        public Skills Skills { get; set; }
        public List<Asspects> Asspects { get; set; }
    }
}