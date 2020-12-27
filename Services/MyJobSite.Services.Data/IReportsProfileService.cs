using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyJobSite.Services.Data
{
    public interface IReportsProfileService
    {
        Task AddNewReportedProfile(string userId);

        bool CheckIfProfileAlreadyReported(string userId);
    }
}
