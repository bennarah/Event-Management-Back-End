using EventManagement.Api.Models;

namespace EventManagement.Api.Repositories
{
    public interface IRegistrationRepository
    {
        Event? GetEventById(Guid eventId);
        User? GetUserById(Guid userId);

        int CountRegistrationsForEvent(Guid eventId);
        bool RegistrationExists(Guid eventId, Guid userId);

        Registration Add(Registration registration);
    }
}