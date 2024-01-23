using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly AuthenticationDbContext _dbContext;
        public PeopleService(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
