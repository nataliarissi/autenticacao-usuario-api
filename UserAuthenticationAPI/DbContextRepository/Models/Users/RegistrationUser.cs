namespace UserAuthenticationAPI.DbContextRepository.Models.Users
{
    public class RegistrationUser
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int DaysRenewal { get; set; }
        public Guid IdPerson { get; set; }
        public Guid IdGroup { get; set; }
    }
}
