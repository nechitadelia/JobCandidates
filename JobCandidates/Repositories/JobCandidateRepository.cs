using System.Data.SqlClient;

namespace JobCandidates
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly IConfiguration _configuration;

        public JobCandidateRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
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

        public void AddOrEdit()
        {
            var connectionString = _configuration.GetConnectionString("CandidatesConnection");

            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("CandidateAddOrEdit", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //command.Parameters.AddWithValue();
                command.ExecuteNonQuery();
            }
        }
    }
}
