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

    public class JobPostingsController : BaseController
    {
        private readonly IJobPostingsService jobPostingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountTypeService accountTypeService;
        private readonly ICategoriesService categoriesService;
        private readonly ICompanyInfoService companyInfoService;

        public JobPostingsController(IJobPostingsService jobPostingService, UserManager<ApplicationUser> userManager, IAccountTypeService accountTypeService, ICategoriesService categoriesService, ICompanyInfoService companyInfoService)
        {
            this.jobPostingService = jobPostingService;
            this.userManager = userManager;
            this.accountTypeService = accountTypeService;
            this.categoriesService = categoriesService;
            this.companyInfoService = companyInfoService;
        }

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

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var categoryId = this.categoriesService.GetCategoryId(input.Category);
            input.JobPostingCategoryId = categoryId;

            var companyInfoId = this.companyInfoService.GetCompanyInfoId(userId);
            input.CompanyInfoId = companyInfoId;

            await this.jobPostingService.PostJobPostingAsync(input);
            return this.Redirect("/");
        }
    }
}
