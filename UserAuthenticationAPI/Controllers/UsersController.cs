using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.Services.Implementations;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.DbContextRepository.Models.Users;
using UserAuthenticationAPI.DbContextRepository;

namespace UserAuthenticationAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public Return<User?> GetCompleteUserById(int id)
        {
            return _userService.GetCompleteUserById(id);
        }

        [HttpPost]
        public Return<bool> RegistrationUserRequest([FromBody] RegistrationUser registrationUser)
        {
            return _userService.RegistrationUserRequest(registrationUser);
        }

        [HttpPut]
        public Return<bool> UpdateUserRequest([FromBody] UpdateUser updateUser)
        {
            return _userService.UpdateUserRequest(updateUser);
        }

        [HttpDelete]
        public Return<bool> RemoveUserRequest(int id)
        {
            return _userService.RemoveUserRequest(id);

        }

        [HttpGet]
        public Return<Pagination<User>> GetAllUsers(int page, int pageSize)
        {
            return _userService.GetAllUsers(page, pageSize);
        }
    }
}
