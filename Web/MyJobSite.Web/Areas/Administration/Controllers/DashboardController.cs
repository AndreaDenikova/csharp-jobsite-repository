namespace MyJobSite.Web.Areas.Administration.Controllers
{
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using MyJobSite.Web.ViewModels.ViewModels.JobPosting;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IReportsJobPostingService reportsJobPostingService;
        private readonly IReportsProfileService reportsProfileService;
        private readonly IJobPostingsService jobPostingsService;

        public DashboardController(ISettingsService settingsService, IReportsJobPostingService reportsJobPostingService, IReportsProfileService reportsProfileService, IJobPostingsService jobPostingsService)
        {
            this.settingsService = settingsService;
            this.reportsJobPostingService = reportsJobPostingService;
            this.reportsProfileService = reportsProfileService;
            this.jobPostingsService = jobPostingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }

        public async Task<IActionResult> DeleteJobPostingReport(string id) //// id == jobPostingId
        {
            await this.reportsJobPostingService.DeleteReport(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public async Task<IActionResult> DeleteJobPosting(string id) //// id == jobPostingId
        {
            await this.jobPostingsService.MarkJobPostingAsDeleted(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public async Task<IActionResult> DeleteProfileReport(string id) //// id == userId
        {
            await this.reportsProfileService.DeleteReport(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public IActionResult BrowseReportedJobPostings()
        {
            var ids = this.reportsJobPostingService.GetAllReportedJobPostings();
            var viewModel = this.jobPostingsService.GetSomeJobpostingsInformation<BrowseReportedJobPostingsViewModel>(ids);
            return this.View(viewModel);
        }
    }
}
