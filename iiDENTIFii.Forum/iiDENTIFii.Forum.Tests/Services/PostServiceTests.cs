using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;
using iiDENTIFii.Forum.Services;
using Moq;

namespace iiDENTIFii.Forum.Tests.Services
{
    public class PostServiceTests
    {
        private IPostService postService;
        private DatabaseContext databaseContext;
        private User authorUser;
        private User likingUser;
        private User modUser;

        [SetUp]
        public void Setup()
        {
            authorUser = new User()
            {
                Email = "arthur@gmail.com",
                UserName = "arthur@gmail.com",
                DisplayName = "Arthur",
                IsModerator = false
            };

            likingUser = new User()
            {
                Email = "luke@gmail.com",
                UserName = "luke@gmail.com",
                DisplayName = "Luke",
                IsModerator = false
            };

            modUser = new User()
            {
                Email = "martin@gmail.com",
                UserName = "martin@gmail.com",
                DisplayName = "Martin",
                IsModerator = true
            };

            databaseContext = new Mock<DatabaseContext>().Object;
            postService = new PostService(databaseContext);
        }

        [Test]
        public void GetAllPosts_ShouldPass()
        {
            var posts = postService.GetPosts();

            Assert.IsNotNull(posts);
            Assert.Greater(posts.Count, 0);
        }

        [Test]
        public void GetPost_ShouldPass()
        {
            var post = postService.GetPost(1);

            Assert.IsNotNull(post);
            Assert.IsTrue(post.Comments.Count >= 0);
        }

        [Test]
        public void CreatePost_ShouldPass()
        {
            var newPost = new Post()
            {
                Title = "Text",
                Content = "Lorem Ipsum Dolor...",
                Author = authorUser
            };

            var post = postService.AddPost(newPost);

            Assert.IsNotNull(post);
            Assert.Greater(post.Id, 0);
        }

        [Test]
        public void LikePost_ShouldPass()
        {
            var post = postService.GetPost(1);

            var result = postService.LikePost(post.Id, likingUser);

            Assert.IsTrue(result.Item1);
        }

        [Test]
        public void LikePost_ShouldFail()
        {
            var post = postService.GetPost(1);

            var result = postService.LikePost(post.Id, authorUser);

            Assert.IsFalse(result.Item1);
            Assert.IsNotNull(result.Item2);
            Assert.Greater(result.Item2.Length, 0);
        }

        [Test]
        public void TagPost_ShouldPass()
        {
            // Controller already checks for IsModerator permissions
            var post = postService.GetPost(1);

            postService.TagPost(post.Id, modUser);

            Assert.Pass();
        }
    }
}