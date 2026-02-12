

using System.Diagnostics.Tracing;

namespace EventManagement.Api.Services
{
    public interface IEventService
}

public interface IEventService
{
    List<Event> GetEvenets();

    Event GetEvent(Guid id);

    Event CreateEvent( Event input );
}