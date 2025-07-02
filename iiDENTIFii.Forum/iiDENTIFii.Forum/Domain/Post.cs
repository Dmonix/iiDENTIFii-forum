namespace iiDENTIFii.Forum.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required User Author { get; set; }
        public List<PostComment> Comments { get; set; } = new List<PostComment>();
        public int Likes { get; set; }
        public bool IsTagged { get; set; } = false;
    }

    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsModerator { get; set; } = false;
    }

    public class PostComment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
    }
}