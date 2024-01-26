using UserAuthenticationAPI.DbContextRepository.Models.Users;
using UserAuthenticationAPI.DbContextRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IUsersService
    {
        Return<User?> GetCompleteUserById(int id);
        Return<bool> RegistrationUserRequest(RegistrationUser registrationUser);
        Return<bool> UpdateUserRequest(UpdateUser updateUser);
        Return<bool> RemoveUserRequest(int id);
        Return<List<User?>> GetAllUsers();
    }
}