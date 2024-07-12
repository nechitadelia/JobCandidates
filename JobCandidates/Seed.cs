namespace JobCandidates
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext context)
        {
            _dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!_dataContext.JobCandidates.Any())
            {
                List<JobCandidate> jobCandidates = new List<JobCandidate>()
                {
                    new JobCandidate()
                    {
                        Email = "delia.nechita9@gmail.com",
                        FirstName = "Delia",
                        LastName = "Nechita",
                        PhoneNumber = "+40751111111",
                        StartTimeInterval = new TimeOnly(09, 00, 00),
                        EndTimeInterval = new TimeOnly(18, 00, 00),
                        LinkedInProfileURL = "https://www.linkedin.com/in/delia-nechita/",
                        GitHubProfileURL = "https://github.com/nechitadelia",
                        TextComment = "This is the first candidate"
                    },
                    new JobCandidate()
                    {
                        Email = "userTest2@yahoo.com",
                        FirstName = "John",
                        LastName = "Simpsons",
                        PhoneNumber = "+40755555555",
                        StartTimeInterval = new TimeOnly(10, 30, 00),
                        EndTimeInterval = new TimeOnly(16, 00, 00),
                        LinkedInProfileURL = "https://www.linkedin.com/userTest1",
                        GitHubProfileURL = "https://github.com/userTest1",
                        TextComment = "This is the second candidate"
                    },
                    new JobCandidate()
                    {
                        Email = "userTest3@yahoo.com",
                        FirstName = "Monica",
                        LastName = "Green",
                        PhoneNumber = "+40788888888",
                        StartTimeInterval = new TimeOnly(15, 50, 00),
                        EndTimeInterval = new TimeOnly(20, 50, 00),
                        TextComment = "This is the third candidate"
                    }
                };

                _dataContext.JobCandidates.AddRange(jobCandidates);
                _dataContext.SaveChanges();
            }
        }
    }
}
