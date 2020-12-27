using MyJobSite.Data.Common.Repositories;
using MyJobSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJobSite.Services.Data
{
    public class ReportsJobPostingService : IReportsJobPostingService
    {
        private readonly IDeletableEntityRepository<ReportedJobPosting> reportedJobPostingsRepository;

        public ReportsJobPostingService(IDeletableEntityRepository<ReportedJobPosting> reportedJobPostingsRepository)
        {
            this.reportedJobPostingsRepository = reportedJobPostingsRepository;
        }

        public async Task AddNewReportedJobPosting(string jobPostingId)
        {
            var report = new ReportedJobPosting
            {
                JobPostingId = jobPostingId,
            };

            await this.reportedJobPostingsRepository.AddAsync(report);
            await this.reportedJobPostingsRepository.SaveChangesAsync();
        }

        public bool CheckIfJobPostingAlreadyReported(string jobPostingId)
        {
            var report = this.reportedJobPostingsRepository.All().Where(r => r.JobPostingId == jobPostingId).FirstOrDefault();

            if (report == null)
            {
                return false;
            }

            return true;
        }
    }
}
