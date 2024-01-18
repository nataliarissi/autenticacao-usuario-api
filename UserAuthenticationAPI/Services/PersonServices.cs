using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly AuthenticationDbContext _dbContext;
        public PersonServices(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
