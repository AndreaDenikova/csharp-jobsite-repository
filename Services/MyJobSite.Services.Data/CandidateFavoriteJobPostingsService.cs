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

        public async Task DeleteJobPostingFromFavorites(string userid, string jobPostingId)
        {
            var favorite = this.favoriteJobPostingRepository.All().Where(f => f.UserId == userid && f.JobPostingId == jobPostingId).FirstOrDefault();
            this.favoriteJobPostingRepository.HardDelete(favorite);
            await this.favoriteJobPostingRepository.SaveChangesAsync();
        }

        public async Task DeleteJobPostingFromFavoritesByJobPostingId(string jobPostingId)
        {
            var favorites = this.favoriteJobPostingRepository.All().Where(f => f.JobPostingId == jobPostingId).ToList();

            foreach (var favorite in favorites)
            {
                this.favoriteJobPostingRepository.Delete(favorite);

                await this.favoriteJobPostingRepository.SaveChangesAsync();
            }
        }

        public ICollection<string> GetAllFavoriteJobPostingsIds(string userId)
        {
            var favorites = this.favoriteJobPostingRepository.All().Where(f => f.UserId == userId).ToList();

            var listOfIds = new List<string>();

            foreach (var favorite in favorites)
            {
                var jobPostingId = favorite.JobPostingId;

                if (!listOfIds.Contains(jobPostingId))
                {
                    listOfIds.Add(jobPostingId);
                }
            }

            return listOfIds;
        }
    }
}
