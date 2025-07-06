namespace iiDENTIFii.Forum.Models
{
    public class Post
    {
        private const string MisleadingDescription = "Misleading or false information";

        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public User Author { get; set; } = new User();
        public List<PostComment> Comments { get; set; } = new List<PostComment>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public int LikeCount => Likes.Count;
        public bool IsTagged { get; set; } = false;
        public string TagDescription => IsTagged ? MisleadingDescription : String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}