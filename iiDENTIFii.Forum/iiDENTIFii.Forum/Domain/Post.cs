namespace iiDENTIFii.Forum.Domain
{
    public class Post
    {
        private const string MisleadingDescription = "Misleading or false information";

        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required User Author { get; set; }
        public List<PostComment> Comments { get; set; } = new List<PostComment>();
        public int Likes { get; set; }
        public bool IsTagged { get; set; } = false;
        public string TagDescription { get; set; } = string.Empty;
    }
}