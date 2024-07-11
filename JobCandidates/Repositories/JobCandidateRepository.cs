
using Microsoft.EntityFrameworkCore;

namespace JobCandidates
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly DataContext _context;

        public JobCandidateRepository(DataContext context) 
        {
            _context = context;
        }

        //get one candidate from DB by email
        public async Task<JobCandidate> GetCandidate(string email)
        {
            return await _context.JobCandidates.Where(c => c.Email == email).FirstAsync();
        }

        //check if candidate already exists in the DB
        public async Task<bool> CheckIfCandidateExists(string email)
        {
            return await _context.JobCandidates.AnyAsync(c => c.Email == email);
        }

        //add a new candidate to DB
        public bool AddCandidate(CreateJobCandidateDto candidateDto)
        {
            JobCandidate candidate = new JobCandidate
            {
                Email = candidateDto.Email,
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                PhoneNumber = candidateDto.PhoneNumber,
                StartTimeInterval = candidateDto.StartTimeInterval,
                EndTimeInterval = candidateDto.EndTimeInterval,
                LinkedInProfileURL = candidateDto.LinkedInProfileURL,
                GitHubProfileURL = candidateDto.GitHubProfileURL,
                TextComment = candidateDto.TextComment
            };

            _context.JobCandidates.Add(candidate);
            return Save();
        }

        //edit an existing candidate to DB
        public async Task<bool> EditCandidate(EditJobCandidateDto candidateDto)
        {
            JobCandidate candidate = await GetCandidate(candidateDto.Email);

            if (candidate != null)
            {
                candidate.FirstName = candidateDto.FirstName;
                candidate.LastName = candidateDto.LastName;
                candidate.PhoneNumber = candidateDto.PhoneNumber;
                candidate.StartTimeInterval = candidateDto.StartTimeInterval;
                candidate.EndTimeInterval = candidateDto.EndTimeInterval;
                candidate.LinkedInProfileURL = candidateDto.LinkedInProfileURL;
                candidate.GitHubProfileURL = candidateDto.GitHubProfileURL;
                candidate.TextComment = candidateDto.TextComment;

                bool result = Save();
                if (result == false) { return false; }
            }

            return true;
        }

        //save changes to DB
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
