using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;

namespace UserAuthenticationAPI.Services.Interfaces
{
    public interface IPeopleService
    {
        Return<Person?> GetCompletePeopleById(int id);
        Return<bool> RegistrationPersonRequest([FromBody] RegistrationPerson registrationPerson);
        Return<bool> UpdatePersonRequest([FromBody] UpdatePerson updatePerson);
        Return<bool> RemovePersonRequest(int id);
        Return<List<Person?>> GetAllPeople();
    }
}
