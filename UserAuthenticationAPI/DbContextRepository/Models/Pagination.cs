using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.DbContextRepository.Models
{
    public class Pagination
    {
        public List<Group> Groups { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
