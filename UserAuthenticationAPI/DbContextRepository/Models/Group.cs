namespace UserAuthenticationAPI.DbContextRepository.Models
{
    public class Group : AbstractTable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}