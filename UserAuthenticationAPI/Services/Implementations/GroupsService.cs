using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services.Implementations
{
    public class GroupsService : IGroupsService
    {
        private readonly AuthenticationDbContext _dbContext;
        public GroupsService(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Return<Group?> GetCompleteGroupById(int id)
        {
            try
            {
                Group? group = _dbContext.Groups.FirstOrDefault(x => x.Id == id);

                if (group == null)
                    return new Return<Group?>("ID does not exist");

                return new Return<Group?>(group);
            }
            catch (Exception ex)
            {
                return new Return<Group?>("Error" + ex.Message);
            }
        }

        public Return<bool> RegistrationGroupRequest(RegistrationGroup registrationGroup)
        {
            try
            {
                var groupExists = _dbContext.Groups.Any(group => group.Name == registrationGroup.Name);

                if (groupExists)
                    return new Return<bool>("Group with the same name already exists");

                Group group = new Group();

                group.Name = registrationGroup.Name;
                group.Description = registrationGroup.Description;

                _dbContext.Groups.Add(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when registering the group");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> UpdateGroupRequest(UpdateGroup updateGroup)
        {
            try
            {
                Group group = new Group();

                if (group.Name == updateGroup.Name)
                    return new Return<bool>("Group with the same name already exists");

                group.Name = updateGroup.Name;
                group.Description = updateGroup.Description;

                _dbContext.Groups.Update(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when updating the group");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> RemoveGroupRequest(int id)
        {
            try
            {
                var group = _dbContext.Groups.FirstOrDefault(x => x.Id == id);

                if (group == null)
                    return new Return<bool>("ID not found");

                _dbContext.Groups.Remove(group);

                var queryResult = _dbContext.SaveChanges();


                if (queryResult > 0)
                    return new Return<bool>("Error when removing the group");

                return new Return<bool>(true);

            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<List<Group?>> GetAllGroups()
        {
            try
            {
                var queryAllGroups = _dbContext.Groups.ToList();

                var queryResult = _dbContext.SaveChanges();

                if (queryResult == 0)
                    return new Return<List<Group?>>("Error when finding all groups");

                return new Return<List<Group?>>(queryAllGroups);
            }
            catch (Exception ex)
            {
                return new Return<List<Group?>>("Error" + ex.Message);
            }
        }
    }
}