namespace Cis_part2.Dtos.Users
{
    public class UserRegisterDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RolesId { get; set; }
    }
}