namespace Cis_part2.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int AsspectId { get; set; }
        public Asspect Asspect { get; set; }
    }
}