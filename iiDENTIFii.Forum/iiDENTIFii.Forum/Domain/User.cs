namespace iiDENTIFii.Forum.Domain
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsModerator { get; set; } = false;
    }
}