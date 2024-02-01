using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.DbContextRepository.Models.Users
{
    public class UserGroup
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdGroup { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }
}
