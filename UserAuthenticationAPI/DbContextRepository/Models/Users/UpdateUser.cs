namespace UserAuthenticationAPI.DbContextRepository.Models.Users
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int DaysRenewal { get; set; }
    }
}
