namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IReportsProfileService
    {
        Task AddNewReportedProfile(string userId);

        bool CheckIfProfileAlreadyReported(string userId);

        Task IncreaseCount(string userId);

        Task DeleteReport(string userId);
    }
}
