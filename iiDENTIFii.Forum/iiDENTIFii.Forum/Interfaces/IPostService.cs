using iiDENTIFii.Forum.Models;

namespace iiDENTIFii.Forum.Interfaces
{
    public interface IPostService
    {
        public void AddComment(int id, PostComment comment);
        public Post AddPost(Post post);
        public Post GetPost(int id);
        public List<Post> GetPosts();
        public Tuple<bool, string> LikePost(int id, User user);
    }
}