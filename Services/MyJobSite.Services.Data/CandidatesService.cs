namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Web.ViewModels.InputModels;

    public class CandidatesService : ICandidatesService
    {
        private readonly IDeletableEntityRepository<Candidate> candidateRepository;

        public CandidatesService(IDeletableEntityRepository<Candidate> candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public bool CheckIfCandidateAlreadyApplied(string userId, string jobPostingId)
        {
            var candidate = this.candidateRepository.All().Where(c => c.UserId == userId && c.JobPostingId == jobPostingId).FirstOrDefault();

            if (candidate == null)
            {
                return false;
            }

            return true;
        }

        public async Task CreateNewCandidateForJobPostingAsync(string userId, string jobPostingId)
        {
            // if (this.candidateRepository.All().Where(c => c.UserId == input.UserId).FirstOrDefault() != null)
            // {

            // }
            var candidate = new Candidate
            {
                UserId = userId,
                JobPostingId = jobPostingId,
            };
            await this.candidateRepository.AddAsync(candidate);
            await this.candidateRepository.SaveChangesAsync();
        }

        public ICollection<string> GetAllJobPostingsIds(string userId)
        {
            var jobPostings = this.candidateRepository.All().Where(c => c.UserId == userId).ToList();

            var listOfJobPostingsIds = new List<string>();

            foreach (var jobPosting in jobPostings)
            {
                var jobPostingsId = jobPosting.JobPostingId;

                if (!listOfJobPostingsIds.Contains(jobPostingsId))
                {
                    listOfJobPostingsIds.Add(jobPostingsId);
                }
            }

            return listOfJobPostingsIds;
        }

        public ICollection<string> GetAllUsersIdOfJobPosting(string jobPostingId)
        {
            var candidates = this.candidateRepository.All().Where(c => c.JobPostingId == jobPostingId).ToList();

            var listOfUserIds = new List<string>();

            foreach (var candidate in candidates)
            {
                var userId = candidate.UserId;

                if (!listOfUserIds.Contains(userId))
                {
                    listOfUserIds.Add(userId);
                }
            }

            return listOfUserIds;
        }

        public async Task MarkAllApplyingsAsDeleted(string userId)
        {
            var applyings = this.candidateRepository.All().Where(a => a.UserId == userId).ToList();

            foreach (var applying in applyings)
            {
                this.candidateRepository.Delete(applying);

                await this.candidateRepository.SaveChangesAsync();
            }
        }
    }
}
