using Cis_part2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cis_part2.Data
{
    public class CisDBContext : DbContext
    {
        public CisDBContext(DbContextOptions<CisDBContext> options) : base(options) { }
        DbSet<Roles> Roles { get; set; }
        DbSet<User> Users { get; set; }
    }
}