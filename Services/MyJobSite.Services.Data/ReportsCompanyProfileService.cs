using MyJobSite.Data.Common.Repositories;
using MyJobSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJobSite.Services.Data
{
    public class ReportsCompanyProfileService : IReportsCompanyProfileService
    {
        private readonly IDeletableEntityRepository<ReportedCompanyProfile> reportedCompanyProfileRepository;

        public ReportsCompanyProfileService(IDeletableEntityRepository<ReportedCompanyProfile> reportedCompanyProfileRepository)
        {
            this.reportedCompanyProfileRepository = reportedCompanyProfileRepository;
        }

        public async Task AddNewReportedProfile(string userId)
        {
            var report = new ReportedCompanyProfile
            {
                UserId = userId,
            };

            await this.reportedCompanyProfileRepository.AddAsync(report);
            await this.reportedCompanyProfileRepository.SaveChangesAsync();
        }

        public bool CheckIfProfileAlreadyReported(string userId)
        {
            var report = this.reportedCompanyProfileRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            if (report == null)
            {
                return false;
            }

            return true;
        }

        public async Task DeleteReport(string userId)
        {
            var report = this.reportedCompanyProfileRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            this.reportedCompanyProfileRepository.HardDelete(report);

            await this.reportedCompanyProfileRepository.SaveChangesAsync();
        }

        public ICollection<string> GetAllReportedCompanyProfilesIds()
        {
            var profiles = this.reportedCompanyProfileRepository.All().ToList();

            var listOfUserIds = new List<string>();

            foreach (var profile in profiles)
            {
                var id = profile.UserId;

                if (!listOfUserIds.Contains(id))
                {
                    listOfUserIds.Add(id);
                }
            }

            return listOfUserIds;
        }

        public async Task IncreaseCount(string userId)
        {
            var report = this.reportedCompanyProfileRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            report.Count += 1;

            this.reportedCompanyProfileRepository.Update(report);

            await this.reportedCompanyProfileRepository.SaveChangesAsync();
        }
    }
}
