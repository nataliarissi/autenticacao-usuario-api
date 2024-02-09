using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IGroupsService
    {
        Return<Group?> GetCompleteGroupById(Guid id);
        Return<bool> RegistrationGroupRequest(RegistrationGroup registrationGroup);
        Return<bool> UpdateGroupRequest(UpdateGroup updateGroup);
        Return<bool> RemoveGroupRequest(Guid id);
        Return<Pagination<Group>> GetAllGroups(int page, int pageSize);
    }
}
