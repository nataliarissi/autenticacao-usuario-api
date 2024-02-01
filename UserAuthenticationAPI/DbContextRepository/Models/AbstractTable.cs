namespace UserAuthenticationAPI.DbContextRepository.Models
{
    public abstract class AbstractTable
    {
        public AbstractTable()
        {
            RegistrationDate = DateTime.Now;
            Active = true;
        }

        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public Guid Id { get; set; }
    }
}
