namespace Cis_part2.Models
{
    public class Asspects
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double MaxMark { get; set; }
        public int SectionsId { get; set; }
        public Sections Sections { get; set; }
    }
}