using iiDENTIFii.Forum.Interfaces;
using iiDENTIFii.Forum.Models;

namespace iiDENTIFii.Forum.Services
{
    public class PostService : IPostService
    {
        private readonly DatabaseContext db;

        public PostService(DatabaseContext databaseContext)
        {
            this.db = databaseContext;
        }

        public List<Post> GetPosts()
        {
            var posts = db.Posts.ToList();
            return posts;
        }

        public Post GetPost(int id)
        {
            return db.Posts.Single(post => post.Id == id);
        }

        public void AddComment(int id, PostComment comment)
        {
            throw new NotImplementedException();
        }

        public Post AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> LikePost(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}