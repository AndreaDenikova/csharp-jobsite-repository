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

    public class CandidateController : BaseController
    {
        private readonly ICandidatesService candidatesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountTypeService accountTypeService;

        public CandidateController(ICandidatesService candidatesService, UserManager<ApplicationUser> userManager, IAccountTypeService accountTypeService)
        {
            this.candidatesService = candidatesService;
            this.userManager = userManager;
            this.accountTypeService = accountTypeService;
        }

        [Authorize]
        public async Task<IActionResult> GetJobPosting(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var userAlreadyApplied = this.candidatesService.CheckIfCandidateAlreadyApplied(userId, id);

            var accountType = this.accountTypeService.GetAccountTypeController(userId);

            if (accountType == "Company")
            {
                return this.Redirect("/");
            }

            if (userAlreadyApplied == true)
            {
                return this.Redirect("/");
            }

            await this.candidatesService.CreateNewCandidateForJobPostingAsync(userId, id);
            return this.RedirectToAction("GetJobPosting", "JobPostings", new { id });
        }
    }
}
