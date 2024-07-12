using System.ComponentModel.DataAnnotations;

namespace JobCandidates
{
    public class JobCandidateDto
    {
        [Key]
        [MinLength(2, ErrorMessage = "The email must have at least 2 characters")]
        [MaxLength(100, ErrorMessage = "You reached the maximum number of characters")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The first name is required")]
        [MinLength(2, ErrorMessage = "The first name must have at least 2 letters")]
        [MaxLength(255, ErrorMessage = "You reached the maximum number of characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        [MinLength(2, ErrorMessage = "The last name must have at least 2 letters")]
        [MaxLength(255, ErrorMessage = "You reached the maximum number of characters")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "You reached the maximum number of characters")]
        public string? PhoneNumber { get; set; }
        public string? StartTimeInterval { get; set; }
        public string? EndTimeInterval { get; set; }

        [MaxLength(255, ErrorMessage = "You reached the maximum number of characters")]
        public string? LinkedInProfileURL { get; set; }

        [MaxLength(255, ErrorMessage = "You reached the maximum number of characters")]
        public string? GitHubProfileURL { get; set; }

        [Required(ErrorMessage = "The text comment is required")]
        public string TextComment { get; set; }
    }
}