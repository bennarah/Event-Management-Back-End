using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers
{
    [ApiController]
    [Route("api/events/{id:guid}/registrations")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public ActionResult<Registration> Create(Guid id, [FromBody] CreateRegistrationRequest request)
        {
            if (request.UserId == Guid.Empty)
                return BadRequest("UserId is required."); // 400

            var (ok, statusCode, error, created) = _registrationService.CreateRegistration(id, request);

            if (!ok)
            {
                if (statusCode == 404) return NotFound(error);
                return BadRequest(error); // 400
            }

            // 201
            return StatusCode(StatusCodes.Status201Created, created);
        }
    }
}