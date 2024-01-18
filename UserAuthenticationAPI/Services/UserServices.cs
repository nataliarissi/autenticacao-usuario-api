using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly AuthenticationDbContext _dbContext;
        public UserServices(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
