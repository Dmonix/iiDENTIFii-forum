using System.ComponentModel.DataAnnotations;

namespace iiDENTIFii.Forum.Dtos
{
    public class UserForRegistrationDto
    {
        [Required]
        public string? DisplayName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}