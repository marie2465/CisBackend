namespace Cis_part2.Dtos.Asspects
{
    public class AddAsspectDto
    {
        public string Description { get; set; }
        public double Mark { get; set; }
        public int? SectionsId { get; set; }
        public int? TypeAsspectId { get; set; }
    }
}