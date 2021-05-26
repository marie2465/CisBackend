namespace Cis_part2.Models
{
    public class PeopleInTeams
    {
        public int Id { get; set; }
        public int TeamsId { get; set; }
        public Teams Teams { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}