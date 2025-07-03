using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iiDENTIFii.Forum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IUserService userService;

        public PostController(IPostService postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            try
            {
                var post = postService.GetPost(id);
                return Ok(post);
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest($"Post with {id} could not be found");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateNewPost([FromBody] Post post)
        {
            var userClaim = this.HttpContext.User.Identity;
            var user = userService.GetUser(userClaim.Name);
            if (user == null)
            {
                return BadRequest("User is not logged in");
            }

            post.Author = user;

            var newPost = postService.AddPost(post);

            return Ok(newPost.Id);
        }

        [HttpPost("{id}/comment")]
        [Authorize]
        public IActionResult AddCommentToPost(int id, PostComment comment)
        {
            postService.AddComment(id, comment);
            return Ok();
        }

        [HttpPut("{id}/like")]
        [Authorize]
        public IActionResult LikePost(int id)
        {
            var user = this.HttpContext.User.Identity as User;
            if (user == null)
            {
                return BadRequest("User is not logged in");
            }

            var result = postService.LikePost(id, user);
            if (result.Item1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Item2);
            }
        }

        [HttpPut("{id}/tag")]
        [Authorize]
        public IActionResult TagPost(int id)
        {
            var user = this.HttpContext.User.Identity as User;
            if (user == null)
            {
                return BadRequest("User is not logged in");
            }

            if (!user.IsModerator)
            {
                return BadRequest("Only moderators may tag posts");
            }

            postService.TagPost(id, user);

            return Ok();
        }
    }
}