namespace UserAuthenticationAPI.DbContextRepository.Models.Groups
{
    public class UpdateGroup : AbstractTable
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
