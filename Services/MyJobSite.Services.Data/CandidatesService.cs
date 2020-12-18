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
    }
}
