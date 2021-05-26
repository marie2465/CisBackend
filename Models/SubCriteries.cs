using System.ComponentModel.DataAnnotations;

namespace Cis_part2.Models
{
    public class SubCriteries
    {
        [Key] public int Id { get; set; }
        [Required] public string Letter { get; set; }
        [Required] public string Name { get; set; }
        [Required] public double Mark { get; set; }
        public int CriteriesId { get; set; }
        public Criteries Criteries { get; set; }
    }
}