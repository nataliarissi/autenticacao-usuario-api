namespace UserAuthenticationAPI.DbContextRepository.Models.People
{
    public class UpdatePerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DDD { get; set; }
        public int Number { get; set; }
    }
}
