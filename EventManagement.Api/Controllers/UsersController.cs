using Microsoft.AspNetCore.Mvc;
using EventManagement.Api.Models;
using EventManagement.Api.Services;

namespace EventManagement.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users); // 200
        }

        [HttpGet("{id:guid}")]
        public ActionResult<User> GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user is null)
            {
                return NotFound(); // 404
            }

            return Ok(user); // 200
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User input)
        {
            if (string.IsNullOrWhiteSpace(input.FirstName))
                return BadRequest("FirstName is required."); // 400

            if (string.IsNullOrWhiteSpace(input.LastName))
                return BadRequest("LastName is required."); // 400

            if (string.IsNullOrWhiteSpace(input.Email))
                return BadRequest("Email is required."); // 400

            var created = _userService.CreateUser(input);
            return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created); // 201
        }
    }
}