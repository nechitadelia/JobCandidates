using System.ComponentModel.DataAnnotations;

namespace JobCandidates
{
    public class JobCandidate
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public TimeOnly StartTimeInterval { get; set; }
        public TimeOnly EndTimeInterval { get; set; }
        public string? LinkedInProfileURL { get; set; }
        public string? GitHubProfileURL { get; set; }
        public string TextComment { get; set; }
    }
}
