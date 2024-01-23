namespace UserAuthenticationAPI.DbContextRepository.Models
{
    public class User : AbstractTable
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int DaysRenewal { get; set; }
        public int IdPerson { get; set; }
        public int IdGroup { get; set; }
        public Group Group { get; set; }
    }
}