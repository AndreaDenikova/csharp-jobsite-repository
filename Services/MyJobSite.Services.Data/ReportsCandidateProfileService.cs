namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;

    public class ReportsCandidateProfileService : IReportsCandidateProfileService
    {
        private readonly IDeletableEntityRepository<ReportedCandidateProfile> reportedCandidateProdielRepository;

        public ReportsCandidateProfileService(IDeletableEntityRepository<ReportedCandidateProfile> reportedCandidateProdielRepository)
        {
            this.reportedCandidateProdielRepository = reportedCandidateProdielRepository;
        }

        public async Task AddNewReportedProfile(string userId)
        {
            var report = new ReportedCandidateProfile
            {
                UserId = userId,
            };

            await this.reportedCandidateProdielRepository.AddAsync(report);
            await this.reportedCandidateProdielRepository.SaveChangesAsync();
        }

        public bool CheckIfProfileAlreadyReported(string userId)
        {
            var report = this.reportedCandidateProdielRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            if (report == null)
            {
                return false;
            }

            return true;
        }

        public async Task DeleteReport(string userId)
        {
            var report = this.reportedCandidateProdielRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            this.reportedCandidateProdielRepository.HardDelete(report);

            await this.reportedCandidateProdielRepository.SaveChangesAsync();
        }

        public ICollection<string> GetAllReportedCanidateProfilesIds()
        {
            var profiles = this.reportedCandidateProdielRepository.All().ToList();

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
            var report = this.reportedCandidateProdielRepository.All().Where(r => r.UserId == userId).FirstOrDefault();

            report.Count += 1;

            this.reportedCandidateProdielRepository.Update(report);

            await this.reportedCandidateProdielRepository.SaveChangesAsync();
        }
    }
}
