namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IReportsJobPostingService
    {
        Task AddNewReportedJobPosting(string jobPostingId);

        bool CheckIfJobPostingAlreadyReported(string jobPostingId);

        Task IncreaseCount(string jobPosting);

        Task DeleteReport(string jobPostingId);

        ICollection<string> GetAllReportedJobPostings();
    }
}
