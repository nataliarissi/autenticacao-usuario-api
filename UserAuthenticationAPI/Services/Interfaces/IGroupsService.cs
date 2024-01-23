using UserAuthenticationAPI.DbContextRepository.Models;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IGroupsService
    {
        Return<bool> GroupRegistration(Group group);
    }
}
