namespace Cis_part2.Models
{
    public class SubCriteries
    {
        public int Id { get; set; }
        public string Letter { get; set; }
        public string Name { get; set; }
        public double Mark { get; set; }
        public int CriteriesId { get; set; }
        public Criteries Criteries { get; set; }
    }
}