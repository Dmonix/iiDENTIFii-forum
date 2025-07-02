using Microsoft.AspNetCore.Identity;

namespace iiDENTIFii.Forum.Models
{
    public class User : IdentityUser
    {
        public string? DisplayName { get; set; }
        public bool IsModerator { get; set; } = false;
    }
}