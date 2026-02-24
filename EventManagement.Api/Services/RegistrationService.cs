using EventManagement.Api.Models;
using EventManagement.Api.Repositories;

namespace EventManagement.Api.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public (bool ok, int statusCode, string? error, Registration? created) CreateRegistration(Guid eventId, CreateRegistrationRequest request)
        {
            var ev = _registrationRepository.GetEventById(eventId);
            if (ev is null)
                return (false, 404, "Event not found.", null);

            var user = _registrationRepository.GetUserById(request.UserId);
            if (user is null)
                return (false, 404, "User not found.", null);

            // rule: no duplicate registration
            if (_registrationRepository.RegistrationExists(eventId, request.UserId))
                return (false, 400, "User is already registered for this event.", null);

            // rule: capacity check
            var currentCount = _registrationRepository.CountRegistrationsForEvent(eventId);
            if (currentCount >= ev.Capacity)
                return (false, 400, "Event is at capacity.", null);

            var reg = new Registration
            {
                Id = Guid.NewGuid(),
                EventId = eventId,
                UserId = request.UserId,
                RegisteredAt = DateTime.UtcNow,
                Status = string.IsNullOrWhiteSpace(request.Status) ? "Registered" : request.Status
            };

            var created = _registrationRepository.Add(reg);
            return (true, 201, null, created);
        }
    }
}