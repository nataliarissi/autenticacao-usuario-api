using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using UserAuthenticationAPI.DbContextRepository;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.People;
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

                if (queryResult <= 0)
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

                var idExists = _dbContext.Groups.Any(i => i.Id == updateGroup.Id);

                if(!idExists)
                    return new Return<bool>("Id does not exist");

                var nameAlreadyRegistered = _dbContext.Groups.Any(n => n.Name == updateGroup.Name && n.Id != updateGroup.Id);

                if (nameAlreadyRegistered)
                    return new Return<bool>("Group with the same name already exists");

                group.Id = updateGroup.Id;
                group.Name = updateGroup.Name;
                group.Description = updateGroup.Description;

                _dbContext.Groups.Update(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
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

                if (id <= 0)
                    return new Return<bool>("ID not found");

                _dbContext.Groups.Remove(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                    return new Return<bool>("Error when removing the group");

                return new Return<bool>(true);

            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<Pagination<Group>> GetAllGroups(int page, int pageSize)
        {
            try
            {
                if (_dbContext.Groups == null)
                    return new Return<Pagination<Group>>("Error");


                var pagingModel = _dbContext.Groups
                .OrderBy(n => n.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

                var totalGroups = _dbContext.People.Count();
                var totalPages = (int)Math.Ceiling((double)totalGroups / pageSize);

                var result = new Pagination<Group>(pagingModel, page, totalPages);

                return new Return<Pagination<Group>>(result);
            }
            catch (Exception ex)
            {
                return new Return<Pagination<Group>>("Error" + ex.Message);
            }
        }
    }
}