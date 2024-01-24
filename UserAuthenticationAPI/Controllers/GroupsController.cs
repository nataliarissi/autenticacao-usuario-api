using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.Services.Interfaces;

namespace UserAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _groupService;

        public GroupsController(IGroupsService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [Route("{id}")]
        public Return<Group?> GetCompleteGroupById(int id)
        {
            return _groupService.GetCompleteGroupById(id);
        }

        [HttpPost]
        public Return<bool> RegistrationGroupRequest([FromBody] RegistrationGroup registrationGroup)
        {
            return _groupService.RegistrationGroupRequest(registrationGroup);
        }

        [HttpPut]
        public Return<bool> UpdateGroupRequest([FromBody] UpdateGroup updateGroup)
        {
            return _groupService.UpdateGroupRequest(updateGroup);
        }

        [HttpDelete]
        public Return<bool> RemoveGroupRequest(int id)
        {
            return _groupService.RemoveGroupRequest(id);

        }

        [HttpGet("getAllGroups")]
        public Return<List<Group?>> GetAllGroups()
        {
            return _groupService.GetAllGroups();
        }
    }
}
