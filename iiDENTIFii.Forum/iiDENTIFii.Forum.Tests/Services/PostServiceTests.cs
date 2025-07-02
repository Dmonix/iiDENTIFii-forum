using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Services;

namespace iiDENTIFii.Forum.Tests.Services
{
    public class PostServiceTests
    {
        private IPostService postService;

        [SetUp]
        public void Setup()
        {
            postService = new PostService();
        }

        [Test]
        public void GetLikes_ShouldPass()
        {
            var post = postService.GetPost(1);

            Assert.IsNotNull(post);
            Assert.IsTrue(post.Comments.Count >= 0);
        }
    }
}