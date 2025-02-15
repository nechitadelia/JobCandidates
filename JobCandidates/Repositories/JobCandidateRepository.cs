﻿
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
            JobCandidate candidate = await _context.JobCandidates.Where(c => c.Email == email).FirstAsync();

            return candidate;
        }

        //check if candidate already exists in the DB
        public async Task<bool> CheckIfCandidateExists(string email)
        {
            return await _context.JobCandidates.AnyAsync(c => c.Email == email);
        }

        //add a new candidate to DB
        public bool AddCandidate(JobCandidateDto candidateDto)
        {
            JobCandidate candidate = new JobCandidate
            {
                Email = candidateDto.Email,
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                PhoneNumber = candidateDto.PhoneNumber,
                StartTimeInterval = ConvertTime(candidateDto.StartTimeInterval),
                EndTimeInterval = ConvertTime(candidateDto.EndTimeInterval),
                LinkedInProfileURL = candidateDto.LinkedInProfileURL,
                GitHubProfileURL = candidateDto.GitHubProfileURL,
                TextComment = candidateDto.TextComment
            };

            _context.JobCandidates.Add(candidate);
            return Save();
        }

        //edit an existing candidate to DB
        public async Task<bool> EditCandidate(JobCandidateDto candidateDto)
        {
            JobCandidate candidate = await GetCandidate(candidateDto.Email);

            if (candidate != null)
            {
                candidate.FirstName = candidateDto.FirstName;
                candidate.LastName = candidateDto.LastName;
                candidate.PhoneNumber = candidateDto.PhoneNumber;
                candidate.StartTimeInterval = ConvertTime(candidateDto.StartTimeInterval);
                candidate.EndTimeInterval = ConvertTime(candidateDto.EndTimeInterval);
                candidate.LinkedInProfileURL = candidateDto.LinkedInProfileURL;
                candidate.GitHubProfileURL = candidateDto.GitHubProfileURL;
                candidate.TextComment = candidateDto.TextComment;
            }

            return Save();
        }

        //convert time format HH:mm:ss
        private TimeOnly ConvertTime(string timeString)
        {
            if (string.IsNullOrEmpty(timeString))
            {
                return new TimeOnly(0, 0, 0);
            }

            int hour = int.Parse(timeString.Substring(0, 2));
            int minute = int.Parse(timeString.Substring(3, 2));
            int second = int.Parse(timeString.Substring(6, 2));

            return new TimeOnly(hour, minute, second);
        }

        //save changes to DB
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
