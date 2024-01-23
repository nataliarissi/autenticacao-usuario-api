using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly AuthenticationDbContext _dbContext;
        public UsersService(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
