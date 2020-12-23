namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;

    public class CandidateFavoriteJobPostingsService : ICandidateFavoriteJobPostingsService
    {
        private readonly IDeletableEntityRepository<FavoriteJobPosting> favoriteJobPostingRepository;

        public CandidateFavoriteJobPostingsService(IDeletableEntityRepository<FavoriteJobPosting> favoriteJobPostingRepository)
        {
            this.favoriteJobPostingRepository = favoriteJobPostingRepository;
        }

        public async Task AddNewCandidatesFavoriteJobPosting(string userId, string jobPostingId)
        {
            var favorite = new FavoriteJobPosting
            {
                UserId = userId,
                JobPostingId = jobPostingId,
            };

            await this.favoriteJobPostingRepository.AddAsync(favorite);
            await this.favoriteJobPostingRepository.SaveChangesAsync();
        }

        public bool CheckIfFavoriteJobPostingAlreadyExists(string userId, string jobPostingId)
        {
            var favorite = this.favoriteJobPostingRepository.All().Where(f => f.UserId == userId && f.JobPostingId == jobPostingId).FirstOrDefault();

            if (favorite == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
