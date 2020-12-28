using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyJobSite.Services.Data
{
    public interface IReportsCandidateProfileService 
    {
        Task AddNewReportedProfile(string userId);

        bool CheckIfProfileAlreadyReported(string userId);

        Task IncreaseCount(string userId);

        Task DeleteReport(string userId);

        ICollection<string> GetAllReportedCanidateProfilesIds();
    }
}
