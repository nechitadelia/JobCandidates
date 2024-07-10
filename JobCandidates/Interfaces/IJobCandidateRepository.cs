namespace JobCandidates
{
    public interface IJobCandidateRepository
    {
        //get one candidate from DB by email
        JobCandidate GetCandidateByEmail(string email);

        //check if candidate already exists in the DB
        bool CheckIfCandidateExists(string email);

        //add a new candidate to DB
        void AddCandidate(JobCandidate candidate);
        
        //edit an existing candidate to DB
        void EditCandidate(JobCandidate candidate);
    }
}
