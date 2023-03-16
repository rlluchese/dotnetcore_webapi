using Microsoft.AspNetCore.Mvc;
using Ralelu.Domain.Entity;
using Ralelu.Infrastructure.Repository.Interface;
using Ralelu.WebAPI.Arguments.In.User;
using Ralelu.WebAPI.Arguments.Out.User;

namespace Ralelu.WebAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll().Select(x => (UserOut)x));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok((UserOut)user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreate createUser)
        {
            if (string.IsNullOrEmpty(createUser.email)
                || string.IsNullOrEmpty(createUser.Name))
            {
                return BadRequest("Invalid arguments.");
            }

            User user = new User(createUser.Name, createUser.email);
            _userRepository.Create(user);

            return Ok((UserOut)user);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UserCreate createUser, int id)
        {
            if (string.IsNullOrEmpty(createUser.email)
                || string.IsNullOrEmpty(createUser.Name))
            {
                return BadRequest("Invalid arguments.");
            }

            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Update(createUser.Name, createUser.email);
            _userRepository.Update(user);

            return Ok((UserOut)user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);

            return Ok();
        }
    }
}
