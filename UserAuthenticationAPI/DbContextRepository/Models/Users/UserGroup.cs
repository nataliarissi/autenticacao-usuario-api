using System.Text.RegularExpressions;

namespace UserAuthenticationAPI.DbContextRepository.Models.Users
{
    public class UserGroup
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdGroup { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }
}
