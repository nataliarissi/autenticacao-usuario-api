namespace UserAuthenticationAPI.DbContextRepository.Models.People
{
    public class RegistrationPerson : AbstractTable
    {
        public string Name { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }
        public int DDD { get; set; }
        public int Number { get; set; }
    }
}
