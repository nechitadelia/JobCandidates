using System.ComponentModel.DataAnnotations;

namespace JobCandidates
{
    public class EditJobCandidateDto
    {
        [Key]
        public string Email { get; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string? PhoneNumber { get; set; }
        public TimeOnly StartTimeInterval { get; set; }
        public TimeOnly EndTimeInterval { get; set; }
        [MaxLength(255)]
        public string? LinkedInProfileURL { get; set; }
        [MaxLength(255)]
        public string? GitHubProfileURL { get; set; }
        public string TextComment { get; set; }
    }
}
