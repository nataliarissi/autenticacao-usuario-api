using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.Pagination;
using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.Services.Implementations;
using UserAuthenticationAPI.Services.Interfaces;

namespace UserAuthenticationAPI.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        [Route("{id}")]
        public Return<Person?> GetCompletePeopleById(int id)
        {
            return _peopleService.GetCompletePeopleById(id);
        }

        [HttpPost]
        public Return<bool> RegistrationPersonRequest([FromBody] RegistrationPerson registrationPerson)
        {
            return _peopleService.RegistrationPersonRequest(registrationPerson);
        }

        [HttpPut]
        public Return<bool> UpdatePersonRequest([FromBody] UpdatePerson updatePerson)
        {
            return _peopleService.UpdatePersonRequest(updatePerson);
        }

        [HttpDelete]
        public Return<bool> RemovePersonRequest(int id)
        {
            return _peopleService.RemovePersonRequest(id);

        }

        [HttpGet]
        public Return<PaginationRequestPerson<Person>> GetAllPeople(int page, int pageSize)
        {
            return _peopleService.GetAllPeople(page, pageSize);
        }
    }
}
