namespace UserAuthenticationAPI.DbContextRepository.Models
{
    public abstract class AbstractTable
    {
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public int Id { get; set; }
    }
}
