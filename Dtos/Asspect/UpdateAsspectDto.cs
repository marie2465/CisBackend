namespace Cis_part2.Dtos.Asspect
{
    public class UpdateAsspectDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double MaxMark { get; set; }
        public int SectionsId { get; set; }
    }
}