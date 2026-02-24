using EventManagement.Api.Data;
using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Event? GetEventById(Guid eventId)
        {
            return _context.Events.Find(eventId);
        }

        public User? GetUserById(Guid userId)
        {
            return _context.User.Find(userId);
        }

        public int CountRegistrationsForEvent(Guid eventId)
        {
            return _context.Registration.Count(r => r.EventId == eventId);
        }

        public bool RegistrationExists(Guid eventId, Guid userId)
        {
            return _context.Registration.Any(r => r.EventId == eventId && r.UserId == userId);
        }

        public Registration Add(Registration registration)
        {
            _context.Registration.Add(registration);
            _context.SaveChanges();
            return registration;
        }
    }
}