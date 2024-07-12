using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidates.Tests.RepositoryTests
{
    public class JobCandidateRepositoryTests
    {
        private readonly JobCandidateRepository _jobCandidateRepository;

        public JobCandidateRepositoryTests()
        {
            //Dependencies
            DataContext dbContext = GetDbContext();

            //SUT
            _jobCandidateRepository = new JobCandidateRepository(dbContext);
        }

        private DataContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DataContext(options);
            dbContext.Database.EnsureCreated();
            if (dbContext.JobCandidates.Count() < 0)
            {
                for (int i = 0; i <= 2; i++)
                {
                    dbContext.JobCandidates.Add(new JobCandidate()
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
                    });
                    dbContext.SaveChanges();
                }
            }
            return dbContext;
        }

        [Fact]
        public void JobCandidateRepository_AddCandidate_ReturnsBool()
        {
            //Arrange
            JobCandidateDto candidateDto = new JobCandidateDto {
                Email = "userTest2@yahoo.com",
                FirstName = "John",
                LastName = "Simpsons",
                TextComment = "This is the second candidate"
            };
            JobCandidate candidate = new JobCandidate
            {
                Email = candidateDto.Email,
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                TextComment = candidateDto.TextComment
            };

            //Act
            var result = _jobCandidateRepository.AddCandidate(candidateDto);

            //Assert
            Assert.True(result);
        }
    }
}