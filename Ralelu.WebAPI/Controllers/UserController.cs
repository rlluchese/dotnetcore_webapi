using Microsoft.AspNetCore.Mvc;
using Ralelu.WebAPI.Arguments.In.User;
using Ralelu.WebAPI.Services.Interfaces;

namespace Ralelu.WebAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _userService.GetAll();
                return Ok(result);
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _userService.GetById(id);

                return result != null ? Ok(result) : NotFound();
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreate createUser)
        {
            try
            {
                if (string.IsNullOrEmpty(createUser.email)
                || string.IsNullOrEmpty(createUser.Name))
                {
                    return BadRequest("Invalid arguments.");
                }

                var result = _userService.Create(createUser);

                return Ok(result);
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UserCreate createUser, int id)
        {
            try
            {
                if (string.IsNullOrEmpty(createUser.email)
                || string.IsNullOrEmpty(createUser.Name))
                {
                    return BadRequest("Invalid arguments.");
                }

                var result = _userService.Update(createUser, id);

                return result != null ? Ok(result) : NotFound();
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _userService.Delete(id);

                return result ? Ok() : NotFound();
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }
    }
}
