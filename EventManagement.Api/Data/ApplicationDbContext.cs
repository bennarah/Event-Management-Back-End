using Microsoft.EntityFrameworkCore;
using EventManagement.Api.Models;

namespace EventManagement.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();

        // added to match exisiting migration table names:
        public DbSet<User> User => Set<User>();
        public DbSet<Registration> Registration => Set<Registration>();
    }
}
