using UserAuthenticationAPI.DbContextRepository.Models.Users;

namespace UserAuthenticationAPI.DbContextRepository.Models.Groups
{
    public class Group : AbstractTable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserGroup> UserGroup { get; set; }
    }
}