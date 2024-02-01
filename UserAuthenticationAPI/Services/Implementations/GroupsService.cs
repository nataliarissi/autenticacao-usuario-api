using UserAuthenticationAPI.DbContextRepository;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

namespace UserAuthenticationAPI.Services.Implementations
{
    public class GroupsService : IGroupsService
    {
        private readonly AuthenticationDbContext _dbContext;
        private readonly ILogger<GroupsService> _logger;
        public GroupsService(AuthenticationDbContext dbContext, ILogger<GroupsService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }

        public Return<Group?> GetCompleteGroupById(int id)
        {
            try
            {
                Group? group = _dbContext.Groups.FirstOrDefault(group => group.Id == id);

                if (group == null)
                {
                    _logger.LogError("It's not possible to update the group ID: {id}", id);
                    return new Return<Group?>("Error when searching for the group by ID, please try again later");
                }

                return new Return<Group?>(group);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when searching for an ID. Searched ID: {id}", id);
                return new Return<Group?>("Error while getting group by ID");
            }
        }

        public Return<bool> RegistrationGroupRequest(RegistrationGroup registrationGroup)
        {
            try
            {
                Group group = new Group();

                var groupExists = _dbContext.Groups.Any(group => group.Name == registrationGroup.Name);

                if (groupExists)
                {
                    _logger.LogError("The group does not exist", registrationGroup.Name);
                    return new Return<bool>("Error when searching for the group by ID, please try again later");
                }

                group.Name = registrationGroup.Name;
                group.Description = registrationGroup.Description;

                _dbContext.Groups.Add(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                {
                    _logger.LogError("It was not possible to register the group", queryResult);
                    return new Return<bool>("Error when registering the group");
                }

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "It was not possible to locate the group name: {name}", registrationGroup.Name);
                return new Return<bool>("Error while getting group by name");
            }
        }

        public Return<bool> UpdateGroupRequest(UpdateGroup updateGroup)
        {
            try
            {
                Group group = new Group();

                var idExists = _dbContext.Groups.Any(group => group.Id == updateGroup.Id);

                if (!idExists)
                {
                    _logger.LogError("It's not possible to update the group ID: {id}", updateGroup.Id);
                    return new Return<bool>("Please try again later");
                }

                var nameAlreadyRegistered = _dbContext.Groups.Any(group => group.Name == updateGroup.Name && group.Id != updateGroup.Id);

                if (nameAlreadyRegistered)
                {
                    _logger.LogError("It's not possible to update the group name: {name}", updateGroup.Name);
                    return new Return<bool>("Please try again later"); 
                }

                group.Id = updateGroup.Id;
                group.Name = updateGroup.Name;
                group.Description = updateGroup.Description;

                _dbContext.Groups.Update(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                {
                    _logger.LogError("It's not possible to update the group", queryResult);
                    return new Return<bool>("It was not possible to save the changes to the group");
                }
                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating the group {id} {name}", updateGroup.Id, updateGroup.Name);
                return new Return<bool>("Error");
            }
        }

        public Return<bool> RemoveGroupRequest(int id)
        {
            try
            {
                var group = _dbContext.Groups.FirstOrDefault(x => x.Id == id);

                if (group == null)
                {
                    _logger.LogError("It's not possible to remove the group ID: {id}", id);
                    return new Return<bool>("ID not found, please try again later");
                }

                _dbContext.Groups.Remove(group);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                {
                    _logger.LogError("It's not possible to remove the group", queryResult);
                    return new Return<bool>("Error when removing the group");
                }
                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while removing the group {id}", id);
                return new Return<bool>("Error");
            }
        }

        public Return<Pagination<Group>> GetAllGroups(int page, int pageSize)
        {
            try
            {
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
                _logger.LogError(ex, "Error while locating all groups.");
                return new Return<Pagination<Group>>("Error");
            }
        }
    }
}