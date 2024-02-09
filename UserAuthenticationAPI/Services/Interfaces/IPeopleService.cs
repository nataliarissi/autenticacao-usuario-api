using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IPeopleService
    {
        Return<Person?> GetCompletePeopleById(Guid id);
        Return<bool> RegistrationPersonRequest(RegistrationPerson registrationPerson);
        Return<bool> UpdatePersonRequest(UpdatePerson updatePerson);
        Return<bool> RemovePersonRequest(Guid id);
        Return<Pagination<Person>> GetAllPeople(int page, int pageSize);
    }
}
