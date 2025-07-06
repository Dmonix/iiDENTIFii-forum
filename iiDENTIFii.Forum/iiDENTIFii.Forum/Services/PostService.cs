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

        public List<Post> GetPosts(string author = "", DateTime? fromDate = null, DateTime? toDate = null, string sort = "", string sortDir = "", bool isTagged = false, int page = 1, int size = 10)
        {
            var postQuery = db.Posts;
            if (!string.IsNullOrEmpty(author))
            {
                postQuery.Where(p => p.Author.Email == author);
            }

            if (fromDate != null)
            {
                postQuery.Where(p => p.CreatedDate >= fromDate);
            }

            if (toDate != null)
            {
                postQuery.Where(p => p.CreatedDate <= toDate);
            }

            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(sortDir))
            {
                if (sortDir.Equals("asc", StringComparison.InvariantCultureIgnoreCase))
                {
                    postQuery.OrderBy(p => p.GetType().GetProperty(sort).GetValue(p, null));
                }
                else
                {
                    postQuery.OrderByDescending(p => p.GetType().GetProperty(sort).GetValue(p, null));
                }
            }

            postQuery.Where(p => p.IsTagged == isTagged);
            postQuery.Skip((page - 1) * page).Take(size);

            var posts = postQuery.ToList();
            return posts;
        }

        public Post GetPost(int id)
        {
            return db.Posts.Single(post => post.Id == id);
        }

        public Post AddPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();

            return post;
        }

        public void AddComment(int id, PostComment comment)
        {
            var post = db.Posts.Single(post => post.Id == id);
            post.Comments.Add(comment);
            db.Posts.Update(post);
            db.SaveChanges();
        }

        public Tuple<bool, string> LikePost(int id, User user)
        {
            var post = db.Posts.Single(post => post.Id == id);
            if (post.Author.Email == user.Email)
            {
                return new Tuple<bool, string>(false, "Author cannot like their own post");
            }

            var currentlyLiked = post.Likes.Where(like => like.UserEmail == user.Email);
            if (currentlyLiked.Any())
            {
                // A user cannot like a post more than once, functionality does not require a like to be removed
                // Potential future requirement to remove matched like, for now return fail state
                return new Tuple<bool, string>(false, "User can only like a post once");
            }

            post.Likes.Add(new Like() { UserEmail = user.Email });
            db.Posts.Update(post);
            db.SaveChanges();

            return new Tuple<bool, string>(true, String.Empty);
        }

        public void TagPost(int id, User user)
        {
            var post = db.Posts.Single(post => post.Id == id);
            post.IsTagged = true;
            db.Posts.Update(post);
            db.SaveChanges();
        }
    }
}