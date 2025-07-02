using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Services;

namespace iiDENTIFii.Forum.Tests.Services
{
    public class UserServiceTests
    {
        private IUserService userService;

        [SetUp]
        public void SetUp()
        {
            userService = new UserService();
        }

        [Test]
        public void AddLike_ShouldPass()
        {
            userService.AddLike("1");

            Assert.Pass();
        }
    }
}