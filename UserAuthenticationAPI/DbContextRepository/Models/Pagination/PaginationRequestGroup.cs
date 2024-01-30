using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.DbContextRepository.Models.Pagination
{
    public class PaginationRequestGroup
    {
        public List<Group> Groups { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
