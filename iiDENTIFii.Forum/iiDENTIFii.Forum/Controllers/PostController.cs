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

        /// <summary>
        /// Endpoint for getting all posts across the Forum
        /// </summary>
        /// <param name="author">E-mail address of the author to filter by</param>
        /// <param name="fromDate">Starting date for a Date range</param>
        /// <param name="toDate">Ending date for a Date range</param>
        /// <param name="sort">Field to sort by: likes or date</param>
        /// <param name="sortDir">asc or desc for Ascending or Descending order</param>
        /// <param name="isTagged">Filtering by tagged posts</param>
        /// <param name="page">Page number of entries</param>
        /// <param name="size">Size of each page</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPosts(string author, string fromDate, string toDate, string sort, string sortDir, bool isTagged, int page = 1, int size = 10)
        {
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        /// <summary>
        /// Endpoint to get a single post, requires the post id
        /// </summary>
        /// <param name="id">Unique Id of the post</param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint for creating a new post on the forum, user must be logged in
        /// </summary>
        /// <param name="post">Contents of the post, must have a title and content</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult CreateNewPost([FromBody] Post post)
        {
            var user = GetUserFromClaim();
            if (user == null)
            {
                return BadRequest("User is not logged in");
            }

            post.Author = user;

            var newPost = postService.AddPost(post);

            return Ok(newPost.Id);
        }

        /// <summary>
        /// Endpoint to add a comment to a post
        /// </summary>
        /// <param name="id">Unique Id of the post</param>
        /// <param name="comment">Comment object for the post</param>
        /// <returns></returns>
        [HttpPost("{id}/comment")]
        [Authorize]
        public IActionResult AddCommentToPost(int id, [FromBody] PostComment comment)
        {
            postService.AddComment(id, comment);
            return Ok();
        }

        /// <summary>
        /// Endpoint to add a like to a post
        /// </summary>
        /// <param name="id">Unique Id of the post</param>
        /// <returns></returns>
        [HttpPut("{id}/like")]
        [Authorize]
        public IActionResult LikePost(int id)
        {
            var user = GetUserFromClaim();
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

        /// <summary>
        /// Endpoint for Moderators to tag a post
        /// </summary>
        /// <param name="id">Unique Id of the post</param>
        /// <returns></returns>
        [HttpPut("{id}/tag")]
        [Authorize]
        public IActionResult TagPost(int id)
        {
            var user = GetUserFromClaim();
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

        private User GetUserFromClaim()
        {
            var claimUser = this.HttpContext.User.Identity;
            return userService.GetUser(claimUser.Name);
        }
    }
}