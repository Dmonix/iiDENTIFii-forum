using iiDENTIFii.Forum.Models;

namespace iiDENTIFii.Forum.Interfaces
{
    public interface IPostService
    {
        public void AddComment(int id, PostComment comment);
        public Post AddPost(Post post);
        public Post GetPost(int id);
        public List<Post> GetPosts(string author = "", string fromDate = "", string toDate = "", string sort = "", string sortDir = "", bool isTagged = false, int page = 1, int size = 10);
        public Tuple<bool, string> LikePost(int id, User user);
        public void TagPost(int id, User user);
    }
}