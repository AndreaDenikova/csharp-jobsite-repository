namespace MyJobSite.Web.Areas.Administration.Controllers
{
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using MyJobSite.Web.ViewModels.ViewModels.JobPosting;
    using MyJobSite.Web.ViewModels.ViewModels.Company;
    using MyJobSite.Web.ViewModels.ViewModels.Candidate;
    using System.Linq;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IReportsJobPostingService reportsJobPostingService;
        private readonly IReportsCompanyProfileService reportsCompanyProfileService;
        private readonly ICompanyProfileService companyProfileService;
        private readonly IReportsCandidateProfileService reportsCandidateProfileService;
        private readonly ICompanyInfoService companyInfoService;
        private readonly IJobPostingsService jobPostingsService;
        private readonly IUserInfoService userInfoService;
        private readonly ICandidatesService candidatesService;
        private readonly IAccountTypeService accountTypeService;
        private readonly ICandidateProfileService candidateProfileService;
        private readonly ICandidateFavoriteJobPostingsService favoriteJobPostingsService;

        public DashboardController(ISettingsService settingsService, IReportsJobPostingService reportsJobPostingService, IReportsCompanyProfileService reportsCompanyProfileService, ICompanyProfileService companyProfileService, IReportsCandidateProfileService reportsCandidateProfileService, ICompanyInfoService companyInfoService, IJobPostingsService jobPostingsService, IUserInfoService userInfoService, ICandidatesService candidatesService, IAccountTypeService accountTypeService, ICandidateProfileService candidateProfileService, ICandidateFavoriteJobPostingsService favoriteJobPostingsService)
        {
            this.settingsService = settingsService;
            this.reportsJobPostingService = reportsJobPostingService;
            this.reportsCompanyProfileService = reportsCompanyProfileService;
            this.companyProfileService = companyProfileService;
            this.reportsCandidateProfileService = reportsCandidateProfileService;
            this.companyInfoService = companyInfoService;
            this.jobPostingsService = jobPostingsService;
            this.userInfoService = userInfoService;
            this.candidatesService = candidatesService;
            this.accountTypeService = accountTypeService;
            this.candidateProfileService = candidateProfileService;
            this.favoriteJobPostingsService = favoriteJobPostingsService;
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

        public async Task<IActionResult> DeleteJobPosting(string id) //// id == userId
        {
            await this.candidatesService.MarkAllApplyingsAsDeletedByJobPostingId(id);

            await this.favoriteJobPostingsService.DeleteJobPostingFromFavoritesByJobPostingId(id);

            await this.jobPostingsService.MarkJobPostingAsDeleted(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public async Task<IActionResult> DeleteCompanyProfileReport(string id) //// id == userId
        {
            await this.reportsCompanyProfileService.DeleteReport(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public async Task<IActionResult> DeleteCandidateProfileReport(string id) //// id == userId
        {
            await this.reportsCandidateProfileService.DeleteReport(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public async Task<IActionResult> DeleteCompanyProfile(string id) //// id == userId
        {
            await this.companyInfoService.MarkCompanyInfoAsDeleted(id);

            var ids = this.jobPostingsService.GetAllJobPostingsByUserId(id);

            await this.jobPostingsService.MarkJobPostingsAsDeleted(ids);

            await this.jobPostingsService.MarkJobPostingAsDeleted(id);

            await this.accountTypeService.MarkProfileAsDeleted(id);

            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public async Task<IActionResult> DeleteCandidateProfile(string id) //// id == jobPostingId
        {
            await this.userInfoService.MarkUserInfoAsDeleted(id);

            await this.candidatesService.MarkAllApplyingsAsDeleted(id);

            await this.accountTypeService.MarkProfileAsDeleted(id);
            return this.Redirect("/"); //// TODO: fix it to reload the page
        }

        public IActionResult BrowseReportedJobPostings()
        {
            var ids = this.reportsJobPostingService.GetAllReportedJobPostingsIds().ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                var checkIfDeleted = this.jobPostingsService.CheckIfIsDeleted(ids[i]);

                if (checkIfDeleted == true)
                {
                    ids.Remove(ids[i]);
                    i--;
                }
            }

            var viewModel = this.jobPostingsService.GetSomeJobpostingsInformation<BrowseReportedJobPostingsViewModel>(ids);
            return this.View(viewModel);
        }

        public IActionResult BrowseReportedCompanies()
        {
            var ids = this.reportsCompanyProfileService.GetAllReportedCompanyProfilesIds().ToList();

            for (int i = 0; i < ids.Count; i++)
            {
                var checkIfDeleted = this.companyProfileService.CheckIfProfileDeleted(ids[i]);

                if (checkIfDeleted == true)
                {
                    ids.Remove(ids[i]);
                    i--;
                }
            } 
            var viewModel = this.companyProfileService.GetSomeCompaniesInformation<BrowseReportedCompaniesViewModel>(ids);
            return this.View(viewModel);
        }

        public IActionResult BrowseReportedCandidates()
        {
            var ids = this.reportsCandidateProfileService.GetAllReportedCanidateProfilesIds().ToList();

            for (int i = 0; i < ids.Count; i++)
            {
                var checkIfDeleted = this.candidateProfileService.CheckIfProfileDeleted(ids[i]);

                if (checkIfDeleted == true)
                {
                    ids.Remove(ids[i]);
                    i--;
                }
            }

            var viewModel = this.candidateProfileService.GetCandidatesProfileInfoByUserIds<BrowseReportedCandidatesViewModel>(ids);
            return this.View(viewModel);
        }
    }
}
