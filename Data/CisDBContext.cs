using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Data
{
    public class CisDBContext : DbContext
    {
        public CisDBContext(DbContextOptions<CisDBContext> options) : base(options) { }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}