namespace iiDENTIFii.Forum.Models
{
    public class Post
    {
        private const string MisleadingDescription = "Misleading or false information";

        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required User Author { get; set; }
        public List<PostComment> Comments { get; set; } = new List<PostComment>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public bool IsTagged { get; set; } = false;
        public string TagDescription { get; set; } = string.Empty;
    }
}