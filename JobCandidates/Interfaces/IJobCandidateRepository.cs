namespace JobCandidates
{
    public interface IJobCandidateRepository
    {
        //get one candidate from DB by email
        Task<JobCandidate> GetCandidate(string email);

        //check if candidate already exists in the DB
        Task<bool> CheckIfCandidateExists(string email);

        //add a new candidate to DB
        bool AddCandidate(JobCandidateDto candidateDto);

        //edit an existing candidate to DB
        Task<bool> EditCandidate(JobCandidateDto candidateDto);

        //save changes to DB
        bool Save();
    }
}
