using Microsoft.AspNetCore.Mvc;
using Ralelu.WebAPI.Arguments.In.Post;
using Ralelu.WebAPI.Services.Interfaces;

namespace Ralelu.WebAPI.Controllers
{
    [ApiController]
    [Route("Post")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _postService.GetAll();
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
                var result = _postService.GetById(id);

                return result != null ? Ok(result) : NotFound();
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostCreate createPost)
        {
            try
            {
                if (string.IsNullOrEmpty(createPost.Title)
                || string.IsNullOrEmpty(createPost.Text))
                {
                    return BadRequest("Invalid arguments.");
                }

                var result = _postService.Create(createPost);

                return Ok(result);
            }
            catch
            {
                // TODO: Log error
                return StatusCode(500);
            }
        }
    }
}
