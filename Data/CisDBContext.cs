using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Data
{
    public class CisDBContext : DbContext
    {
        public CisDBContext(DbContextOptions<CisDBContext> options) : base(options) { }
        public DbSet<Asspect> Asspect { get; set; }
        public DbSet<Criteries> Criteries { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SubCriteries> SubCriteries { get; set; }
        public DbSet<TypeAsspect> TypeAsspect { get; set; }
        public DbSet<TypeSkills> TypeSkills { get; set; }
        public DbSet<User> Users { get; set; }
    }
}