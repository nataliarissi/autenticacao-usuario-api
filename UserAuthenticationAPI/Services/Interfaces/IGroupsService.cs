using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IGroupsService
    {
        Return<Group?> GetCompleteGroupById(int id);
        Return<bool> RegistrationGroupRequest(RegistrationGroup registrationGroup);
        Return<bool> UpdateGroupRequest(UpdateGroup updateGroup);
        Return<bool> RemoveGroupRequest(int id);
        Return<Pagination> GetAllGroups(int page);
    }
}
