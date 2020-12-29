namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICandidateFavoriteJobPostingsService
    {
        Task AddNewCandidatesFavoriteJobPosting(string userId, string jobPostingId);

        Task DeleteJobPostingFromFavorites(string userid, string jobPostingId);

        Task DeleteJobPostingFromFavoritesByJobPostingId(string jobPostingId);

        bool CheckIfFavoriteJobPostingAlreadyExists(string userId, string jobPostingId);

        ICollection<string> GetAllFavoriteJobPostingsIds(string userId);
    }
}
