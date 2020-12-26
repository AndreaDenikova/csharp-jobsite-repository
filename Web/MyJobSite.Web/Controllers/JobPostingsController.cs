namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.InputModels;
    using MyJobSite.Web.ViewModels.ViewModels.JobPosting;

    public class JobPostingsController : BaseController
    {
        private readonly IJobPostingsService jobPostingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountTypeService accountTypeService;
        private readonly ICategoriesService categoriesService;
        private readonly ICompanyInfoService companyInfoService;
        private readonly ICitiesService citiesService;
        private readonly ICandidatesService candidatesService;
        private readonly IUserInfoService userInfoService;

        public JobPostingsController(IJobPostingsService jobPostingService, UserManager<ApplicationUser> userManager, IAccountTypeService accountTypeService, ICategoriesService categoriesService, ICompanyInfoService companyInfoService, ICitiesService citiesService, ICandidatesService candidatesService, IUserInfoService userInfoService)
        {
            this.jobPostingService = jobPostingService;
            this.userManager = userManager;
            this.accountTypeService = accountTypeService;
            this.categoriesService = categoriesService;
            this.companyInfoService = companyInfoService;
            this.citiesService = citiesService;
            this.candidatesService = candidatesService;
            this.userInfoService = userInfoService;
        }

        [Authorize]
        public IActionResult JobPostings()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> JobPostings(JobPostingInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var userType = this.accountTypeService.GetAccountTypeController(userId);

            if (userType == "Candidate")
            {
                this.Redirect("/");
            }

            if (input.MinSalary != 0 && input.MaxSalary != 0 && input.MinSalary >= input.MaxSalary)
            {
                return this.RedirectToAction("JobPostings");
            }

            //// TODO: Fix the check

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var categoryId = this.categoriesService.GetCategoryId(input.Category);
            input.JobPostingCategoryId = categoryId;

            var companyInfoId = this.companyInfoService.GetCompanyInfoId(userId);
            input.CompanyInfoId = companyInfoId;

            var cityId = this.citiesService.GetCityId(input.CityName);
            input.CityId = cityId;

            await this.jobPostingService.PostJobPostingAsync(input);
            return this.Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetJobPosting(string id)
        {
            var companyInfoId = this.jobPostingService.GetCompanyInfoId(id);
            var companyInfoLogo = this.companyInfoService.GetCompanyInfoLogo(companyInfoId);
            var companyInfoName = this.companyInfoService.GetCompanyInfoName(companyInfoId);

            var viewModel = this.jobPostingService.GetJobPostingInformation<JobPostingViewModel>(id);
            viewModel.Logo = companyInfoLogo;
            viewModel.CompanyName = companyInfoName;

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult BrowseJobPostings(string id)
        {
            var viewModel = this.jobPostingService.GetJobPostingsInfo<BrowseJobPostingViewModel>(id);
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]

        public IActionResult GetCompanyJobPostings()
        {
            var userId = this.userManager.GetUserId(this.User);

            var accountType = this.accountTypeService.GetAccountTypeController(userId);

            if (accountType == "Candidate")
            {
                return this.Redirect("/");
            }

            var checkInfo = this.companyInfoService.CheckIfHasInformation(userId);

            if (checkInfo == false)
            {
                return this.RedirectToAction("CompanyInfo", "CompanyInfo");
            }

            var companyInfoId = this.companyInfoService.GetCompanyInfoId(userId);

            var viewModel = this.jobPostingService.GetCompanyAllJobPostingsInfo<BrowseJobPostingViewModel>(companyInfoId);

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]

        public ActionResult GetCandidateApplyings()
        {
            var userId = this.userManager.GetUserId(this.User);

            var checkInfo = this.userInfoService.CheckIfHasInformation(userId);

            if (checkInfo == false)
            {
                return this.RedirectToAction("UserInfo", "UserInfo");
            }

            var ids = this.candidatesService.GetAllJobPostingsIds(userId);

            if (ids == null)
            {
                return this.RedirectToAction("GetNoApplyingsForJobPosting", "MessagesToUsers");
            }

            var viewModel = this.jobPostingService.GetCandidateAllJobPostingsInformation<BrowseJobPostingViewModel>(ids);

            return this.View(viewModel);
        }
    }
}
