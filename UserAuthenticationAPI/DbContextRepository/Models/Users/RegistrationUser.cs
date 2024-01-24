namespace UserAuthenticationAPI.DbContextRepository.Models.Users
{
    public class RegistrationUser : AbstractTable
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int DaysRenewal { get; set; }
        public int IdPerson { get; set; }
        public int IdGroup { get; set; }
    }
}
