namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;

    public class ReportsProfileService : IReportsProfileService
    {
        private readonly IDeletableEntityRepository<ReportedProfile> reportedProfileRepository;

        public ReportsProfileService(IDeletableEntityRepository<ReportedProfile> reportedProfileRepository)
        {
            this.reportedProfileRepository = reportedProfileRepository;
        }

        public async Task AddNewReportedProfile(string userId)
        {
            var report = new ReportedProfile
            {
                UserId = userId,
            };

            await this.reportedProfileRepository.AddAsync(report);
            await this.reportedProfileRepository.SaveChangesAsync();
        }

        public bool CheckIfProfileAlreadyReported(string userId)
        {
            var report = this.reportedProfileRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            if (report == null)
            {
                return false;
            }

            return true;
        }

        public async Task DeleteReport(string userId)
        {
            var report = this.reportedProfileRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            this.reportedProfileRepository.HardDelete(report);

            await this.reportedProfileRepository.SaveChangesAsync();
        }

        public async Task IncreaseCount(string userId)
        {
            var report = this.reportedProfileRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            report.Count += 1;

            this.reportedProfileRepository.Update(report);

            await this.reportedProfileRepository.SaveChangesAsync();
        }
    }
}
