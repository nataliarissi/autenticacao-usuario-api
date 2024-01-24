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
        public DbSet<RegistrationGroup> RegistrationGroups { get; set; } = null!;
        public DbSet<UpdateGroup> UpdateGroups { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RegistrationUser> RegistrationUsers { get; set; } = null!; 
        public DbSet<UpdateUser> UpdateUsers { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<RegistrationPerson> RegistrationPeople { get; set; } = null!;
        public DbSet<UpdatePerson> UpdatePeople { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("USERMANAGEMENT");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(
                b =>
                {
                    b.HasKey(x => x.Id);
                    b.Property(x => x.Name).HasMaxLength(100);
                });

                //.HasKey(e => e.Id)
                //.Property(x => x.)
                //.IsRequired();

            //modelBuilder.Entity<Person>()
            //    .HasOne(e => e.User)
            //    .WithMany(e => e.Groups)
            //    .HasForeignKey(e => e.IdPerson)
            //    .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Group)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.IdGroup)
                .HasPrincipalKey(e => e.Id)
                .IsRequired();

        }
    }
}