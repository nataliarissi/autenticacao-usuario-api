using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using Microsoft.EntityFrameworkCore;

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

        public Return<bool> RegistrationPersonRequest([FromBody] RegistrationPerson registrationPerson)
        {
            try
            {
                var personExists = _dbContext.People.Any(person => person.Name == registrationPerson.Name);

                if (personExists)
                    return new Return<bool>("Person with the same name already exists");

                Person person = new Person();

                person.Name = registrationPerson.Name;
                person.Cpf = registrationPerson.Cpf;
                person.Email = registrationPerson.Email;
                person.DDD = registrationPerson.DDD;
                person.Number = registrationPerson.Number;

                _dbContext.People.Add(person);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when registering the person");

                return new Return<bool>(queryResult > 0);
            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<bool> UpdatePersonRequest([FromBody] UpdatePerson updatePerson)
        {
            try
            {
                Person person = new Person();

                if (person.Name == updatePerson.Name)
                    return new Return<bool>("Person with the same name already exists");

                person.Name = updatePerson.Name;
                person.Email = updatePerson.Email;
                person.DDD = updatePerson.DDD;
                person.Number = updatePerson.Number;

                _dbContext.People.Update(person);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
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

                if (person == null)
                    return new Return<bool>("ID not found");

                _dbContext.People.Remove(person);

                var queryResult = _dbContext.SaveChanges();

                if (queryResult > 0)
                    return new Return<bool>("Error when removing the person");

                return new Return<bool>(true);

            }
            catch (Exception ex)
            {
                return new Return<bool>("Error" + ex.Message);
            }
        }

        public Return<List<Person?>> GetAllPeople()
        {
            try
            {
                var queryAllPeople = _dbContext.People.ToList();

                var queryResult = _dbContext.SaveChanges();

                if (queryResult == 0)
                    return new Return<List<Person?>>("Error when finding all people");

                return new Return<List<Person?>>(queryAllPeople);
            }
            catch (Exception ex)
            {
                return new Return<List<Person?>>("Error" + ex.Message);
            }
        }
    }
}