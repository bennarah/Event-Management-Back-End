using EventManagement.Api.Data;
using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User? GetById(Guid id)
        {
            return _context.User.Find(id);
        }

        public User Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}