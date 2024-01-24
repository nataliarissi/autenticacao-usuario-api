using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using UserAuthenticationAPI.DbContextRepository.Models.Groups;
using UserAuthenticationAPI.DbContextRepository.Models.People;
using UserAuthenticationAPI.DbContextRepository.Models.Users;

namespace UserAuthenticationAPI.UserDbContext
{
    public class AuthenticationDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<UserGroup> UserGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("USERMANAGEMENT");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(
                b =>
                {
                    b.HasMany(x => x.UserGroup)
                    .WithOne(x => x.User);
                    b.HasKey(x => x.Id);
                    b.Property(x => x.Name).HasMaxLength(100);
                });

                //.HasKey(x => x.Id)
                //.Property(x => x.)
                //.IsRequired();

            //modelBuilder.Entity<Person>()
            //    .HasOne(x => x.User)
            //    .WithManyx => x.Groups)
            //    .HasForeignKey(x => x.IdPerson)
            //    .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasMany(x => x.UserGroup)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.IdGroup)
                .HasPrincipalKey(x => x.Id)
                .IsRequired();
        }
    }
}