using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.Pagination;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IPeopleService
    {
        Return<Person?> GetCompletePeopleById(int id);
        Return<bool> RegistrationPersonRequest(RegistrationPerson registrationPerson);
        Return<bool> UpdatePersonRequest(UpdatePerson updatePerson);
        Return<bool> RemovePersonRequest(int id);
        Return<PaginationRequestPerson<Person>> GetAllPeople(int page, int pageSize);
    }
}
