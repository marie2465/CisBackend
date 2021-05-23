using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Data
{
    public class CisDBContext : DbContext
    {
        public CisDBContext(DbContextOptions<CisDBContext> options) : base(options) { }
        public DbSet<Asspects> Asspects { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<TypeSkills> TypeSkills { get; set; }
        public DbSet<User> Users { get; set; }
    }
}