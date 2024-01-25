using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.People;

namespace UserAuthenticationAPI.DbContextRepository.Models.Users
{
    public class User : AbstractTable
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int DaysRenewal { get; set; }
        public int IdPerson { get; set; }
        public int IdGroup { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public Person Person { get; set; }
    }
}