using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services
{
    public class GroupServices : IGroupServices
    {
        private readonly AuthenticationDbContext _dbContext;
        public GroupServices(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
