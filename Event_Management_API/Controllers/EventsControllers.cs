using System.ComponentModel;
using System.Data.Common;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_API.AddControllers
[ApiController]
[Route("api/events")]
    
    public class EventsController:ControllerBase
    {
        private static List<Event> Events = new List<Event>
        {
            public ActionResult <List<Evvent>> GetEvents()
            {
                return DayOfWeek(Events);
            }
            public ActionResult <List<Evvent>> GetEvents()
            {
                return Ok(Events);
            }
            [HttpGet("id:guid")]
            public ActionResult <List<Evvent>> GetEvents(Guid id)
            {
                var _event = Events.FirstOrDefault(s=>.Id == id);
                if(_event == null)
                    return NotFound();
                return Ok(_event);
            }
            [HttpPost]
            public ActionResult<Event>CreateEvent( Event input)
            {   
                var newEvent = new Event
                {
                    Id = Guid.NewGuid(),
                    Title = input.Title,
                    Description = input.Description,
                    StartDateTime = input.StartDateTime,
                    EndDateTime = input.EndDateTime,
                    Location = input.Location,
                    Capacity = input.Capacity
                };
                Events.Add(newEvent);
                return CreateAtAction(nameof(GetEvent), new {id = newEvent.ID}, newEvent);
            }
        }
    }
}