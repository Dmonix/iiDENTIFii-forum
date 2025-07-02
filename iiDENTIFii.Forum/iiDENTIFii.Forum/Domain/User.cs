namespace iiDENTIFii.Forum.Models
{
    public class User
    {
        public required string UserId { get; set; }
        public required string DisplayName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsModerator { get; set; } = false;
    }
}