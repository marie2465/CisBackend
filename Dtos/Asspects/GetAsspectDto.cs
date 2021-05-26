namespace Cis_part2.Dtos.Asspects
{
    public class GetAsspectDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Mark { get; set; }
        public int? SectionsId { get; set; }
        public int? TypeAsspectId { get; set; }
        public int? SubCriteriesId { get; set; }
    }
}