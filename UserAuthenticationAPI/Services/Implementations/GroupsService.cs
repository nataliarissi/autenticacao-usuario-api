using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                var queryResult = _dbContext.SaveChanges();

                if (queryResult == 0)
                    return new Return<Group?>("Error when finding group by ID");

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
                _dbContext.RegistrationGroups.Add(registrationGroup);

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
                _dbContext.UpdateGroups.Update(updateGroup);

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
                var groups = _dbContext.Groups.FirstOrDefault(x => x.Id == id);

                _dbContext.Groups.Remove(groups);

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