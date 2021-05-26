namespace Cis_part2.Models
{
    public class Asspect
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Mark { get; set; }
        public int? SectionsId { get; set; }
        public Sections Sections { get; set; }
        public int? TypeAsspectId { get; set; }
        public TypeAsspect TypeAsspect { get; set; }
        public int? SubCriteriesId { get; set; }
        public SubCriteries SubCriteries { get; set; }
    }
}