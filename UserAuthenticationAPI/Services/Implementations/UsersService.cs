using UserAuthenticationAPI.DbContextRepository.Models.Users;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;
using UserAuthenticationAPI.DbContextRepository.Models.People;
using Microsoft.AspNetCore.Mvc;
using System;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly AuthenticationDbContext _dbContext;
        public UsersService(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Return<User?> GetCompleteUserById(int id)
        {
            try
            {
                User? user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                    return new Return<User?>("ID does not exist");

                return new Return<User?>(user);
            }
            catch (Exception ex)
            {
                return new Return<User?>("Error" + ex.Message);
            }
        }

        public Return<bool> RegistrationUserRequest(RegistrationUser registrationUser)
        {
            try
            {
                var userExists = _dbContext.Users.Any(user => user.UserLogin == registrationUser.UserLogin);

                if (userExists)
                    return new Return<bool>("User with the same login already exists");

                User user = new User();

                user.UserLogin = registrationUser.UserLogin;
                user.Password = registrationUser.Password;
                user.IdPerson = registrationUser.IdPerson;
                user.IdGroup = registrationUser.IdGroup;

                _dbContext.Users.Add(user);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when registering the user");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> UpdateUserRequest(UpdateUser updateUser)
        {
            try
            {
                User user = new User();

                if (user.UserLogin == updateUser.UserLogin)
                    return new Return<bool>("This login already exists");

                user.UserLogin = updateUser.UserLogin;
                user.Password = updateUser.Password;

                _dbContext.Users.Update(user);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when updating the user");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> RemoveUserRequest(int id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                    return new Return<bool>("ID not found");

                _dbContext.Users.Remove(user);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when removing the user");

                return new Return<bool>(true);

            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<List<User?>> GetAllUsers()
        {
            try
            {
                var queryAllUsers = _dbContext.Users.ToList();

                var queryResult = _dbContext.SaveChanges();

                if (queryResult == 0)
                    return new Return<List<User?>>("Error when finding all users");

                return new Return<List<User?>>(queryAllUsers);
            }
            catch (Exception ex)
            {
                return new Return<List<User?>>("Error" + ex.Message);
            }
        }
    }
}
