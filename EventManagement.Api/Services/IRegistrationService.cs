using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public interface IRegistrationService
    {
        (bool ok, int statusCode, string? error, Registration? created) CreateRegistration(Guid eventId, CreateRegistrationRequest request);
    }
}