
namespace JobCandidates
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly DataContext _context;

        public JobCandidateRepository(DataContext context) 
        {
            _context = context;
        }

        public JobCandidate GetCandidateByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfCandidateExists(string email)
        {
            throw new NotImplementedException();
        }

        public void AddCandidate(JobCandidate candidate)
        {
            throw new NotImplementedException();
        }

        public void EditCandidate(JobCandidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
