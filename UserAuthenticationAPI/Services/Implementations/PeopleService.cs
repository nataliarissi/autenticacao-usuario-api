using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using Microsoft.EntityFrameworkCore;
using UserAuthenticationAPI.DbContextRepository.Models.Pagination;

namespace UserAuthenticationAPI.Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly AuthenticationDbContext _dbContext;
        public PeopleService(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Return<Person?> GetCompletePeopleById(int id)
        {
            try
            {
                Person? person = _dbContext.People.FirstOrDefault(x => x.Id == id);

                if (person == null)
                    throw new Exception("ID does not exist");

                return new Return<Person?>(person);
            }
            catch (Exception ex)
            {
                return new Return<Person?>("Error" + ex.Message);
            }
        }

        public Return<bool> RegistrationPersonRequest(RegistrationPerson registrationPerson)
        {
            try
            {
                Person person = new Person();

                var personExists = _dbContext.People.Any(person => person.Cpf == registrationPerson.Cpf);

                if (personExists)
                    return new Return<bool>("Person with the same CPF already exists");

                var emailExists = _dbContext.People.Any(person => person.Email == registrationPerson.Email);

                if (emailExists)
                    return new Return<bool>("Person with the same email already exists");

                var numberExists = _dbContext.People.Any(person => person.Number == registrationPerson.Number);

                if (numberExists)
                    return new Return<bool>("Person with the same phone number already exists");

                person.Name = registrationPerson.Name;
                person.Cpf = registrationPerson.Cpf;
                person.Email = registrationPerson.Email;
                person.DDD = registrationPerson.DDD;
                person.Number = registrationPerson.Number;

                _dbContext.People.Add(person);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                    return new Return<bool>("Error when registering the person");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> UpdatePersonRequest(UpdatePerson updatePerson)
        {
            try
            {
                Person person = new Person();

                var CpfExists = _dbContext.Groups.Any(person => person.Id == updatePerson.Id);

                if (CpfExists)
                    return new Return<bool>("Person with the same Id already exists");

                var emailExists = _dbContext.People.Any(person => person.Email == updatePerson.Email && person.Id != updatePerson.Id);

                if (emailExists)
                    return new Return<bool>("Person with the same email already exists");

                var numberExists = _dbContext.People.Any(person => person.Number == updatePerson.Number && person.Id != updatePerson.Id);

                if (numberExists)
                    return new Return<bool>("Person with the same phone number already exists");

                person.Id = updatePerson.Id;
                person.Name = updatePerson.Name;
                person.Email = updatePerson.Email;
                person.DDD = updatePerson.DDD;
                person.Number = updatePerson.Number;

                _dbContext.People.Update(person);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                    return new Return<bool>("Error when updating the person");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> RemovePersonRequest(int id)
        {
            try
            {
                var person = _dbContext.People.FirstOrDefault(x => x.Id == id);

                if (id <= 0)
                    return new Return<bool>("ID not found");

                _dbContext.People.Remove(person);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult <= 0)
                    return new Return<bool>("Error when removing the person");

                return new Return<bool>(true);

            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<PaginationRequestPerson<Person>> GetAllPeople(int page, int pageSize)
        {
            try
            {
                var pagingModel = _dbContext.People
                .OrderBy(n => n.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

                var totalPeople= _dbContext.People.Count();
                var totalPages = (int)Math.Ceiling((double)totalPeople / pageSize);

                var result = new PaginationRequestPerson<Person>(pagingModel, page, totalPages);

                return new Return<PaginationRequestPerson<Person>>(result);
            }
            catch (Exception ex)
            {
                return new Return<PaginationRequestPerson<Person>>("Error" + ex.Message);
            }
        }
    }
}