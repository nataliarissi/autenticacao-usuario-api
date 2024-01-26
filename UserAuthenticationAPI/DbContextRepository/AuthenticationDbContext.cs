using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models.Users;

namespace UserAuthenticationAPI.UserDbContext
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<UserGroup> UserGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=USERMANAGEMENT;User ID=sa;Password=Natalia@123; TrustServerCertificate=True");
        }
        //    protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer("USERMANAGEMENT");

        //        "ConnectionStrings": {
        //  "USERMANAGEMENT": "Data Source=.;Initial Catalog=USERMANAGEMENT;User ID=sa;Password=Natalia@123"
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserGroups)
                .HasForeignKey(y => y.IdUser)
                .IsRequired();

            modelBuilder.Entity<UserGroup>()
                .HasOne(x => x.Group)
                .WithMany(y => y.UserGroups)
                .HasForeignKey(y => y.IdGroup)
                .IsRequired();
        }
    }
}