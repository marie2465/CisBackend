namespace Cis_part2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public byte[]PasswordSalt { get; set; }
        public byte[]PasswordHash { get; set; }
        public int? RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}