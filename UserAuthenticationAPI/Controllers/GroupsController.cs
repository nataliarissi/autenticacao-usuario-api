using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models;
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

        [HttpPost]
        public Return<bool> GroupRegistration([FromBody] Group group)
        {
            return _groupService.GroupRegistration(group);
        }
    }
}
