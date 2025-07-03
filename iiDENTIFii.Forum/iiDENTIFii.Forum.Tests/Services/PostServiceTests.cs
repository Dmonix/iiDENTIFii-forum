using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Services;
using Moq;

namespace iiDENTIFii.Forum.Tests.Services
{
    public class PostServiceTests
    {
        private IPostService postService;
        private DatabaseContext databaseContext;

        [SetUp]
        public void Setup()
        {
            databaseContext = new Mock<DatabaseContext>().Object;
            postService = new PostService(databaseContext);
        }

        [Test]
        public void GetAllPosts_ShouldPass()
        {
            var posts = postService.GetPosts();

            Assert.IsNotNull(posts);
            Assert.GreaterOrEqual(posts.Count, 0);
        }

        [Test]
        public void GetPost_ShouldPass()
        {
            var post = postService.GetPost(1);

            Assert.IsNotNull(post);
            Assert.IsTrue(post.Comments.Count >= 0);
        }
    }
}