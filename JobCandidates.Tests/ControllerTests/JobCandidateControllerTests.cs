using Azure;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobCandidates.Tests.ControllerTests
{
    public class JobCandidateControllerTests
    {
        private readonly IJobCandidateRepository _jobCandidateRepository;
        private readonly JobCandidateController _controller;

        public JobCandidateControllerTests()
        {
            //Dependencies
            _jobCandidateRepository = A.Fake<IJobCandidateRepository>();
            //SUT
            _controller = new JobCandidateController(_jobCandidateRepository);
        }

        //GET - The case where when the candidate already exists in DB
        [Fact]
        public async Task JobCandidateController_AddOrEdit_ReturnOKGetExistingCandidate()
        {
            //Arrange
            JobCandidate candidate = new JobCandidate { Email = "userTest2@yahoo.com" };
            string email = candidate.Email;

            A.CallTo(() => _jobCandidateRepository.CheckIfCandidateExists(email)).Returns(true);
            A.CallTo(() => _jobCandidateRepository.GetCandidate(email)).Returns(candidate);

            //Act
            var result = await _controller.AddOrEdit(email);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(candidate, okResult.Value);
        }

        //POST - The case when the candidate already exists in DB (Update an existing candidate)
        [Fact]
        public async Task JobCandidateController_AddOrEdit_ReturnOKIfExistingCandidate()
        {
            //Arrange
            JobCandidateDto candidateDto = A.Fake<JobCandidateDto>();
            string? email = candidateDto.Email;
            A.CallTo(() => _jobCandidateRepository.CheckIfCandidateExists(candidateDto.Email)).Returns(true);
            A.CallTo(() => _jobCandidateRepository.EditCandidate(candidateDto)).Returns(true);
            
            //Act
            var result = await _controller.AddOrEdit(candidateDto, email);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Existing candidate updated!", okResult.Value);
        }

        //POST - The case when the candidate doesn't exist in DB (Create a new candidate)
        [Fact]
        public async Task JobCandidateController_AddOrEdit_ReturnOKIfNewCandidate()
        {
            //Arrange
            JobCandidateDto candidateDto = A.Fake<JobCandidateDto>();
            A.CallTo(() => _jobCandidateRepository.CheckIfCandidateExists(candidateDto.Email)).Returns(false);
            A.CallTo(() => _jobCandidateRepository.AddCandidate(candidateDto)).Returns(true);

            //Act
            var result = await _controller.AddOrEdit(candidateDto);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("New candidate added!", okResult.Value);
        }

        //POST - The case when the ModelState is not valid (Email is not provided)
        [Fact]
        public async Task JobCandidateController_AddOrEdit_ReturnsBadRequest()
        {
            //Arrange
            JobCandidateDto candidateDto = A.Fake<JobCandidateDto>();
            _controller.ModelState.AddModelError("Email", "The email address is required");

            //Act
            var result = await _controller.AddOrEdit(candidateDto);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
