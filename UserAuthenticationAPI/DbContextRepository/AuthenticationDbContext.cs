using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserAuthenticationAPI.DbContextRepository.Models;

namespace UserAuthenticationAPI.UserDbContext
{
    public class AuthenticationDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("USERMANAGEMENT");
    }
}