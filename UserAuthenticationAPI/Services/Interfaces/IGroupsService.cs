using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.Pagination;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IGroupsService
    {
        Return<Group?> GetCompleteGroupById(int id);
        Return<bool> RegistrationGroupRequest(RegistrationGroup registrationGroup);
        Return<bool> UpdateGroupRequest(UpdateGroup updateGroup);
        Return<bool> RemoveGroupRequest(int id);
        Return<PaginationRequestGroup> GetAllGroups(int page);
    }
}
