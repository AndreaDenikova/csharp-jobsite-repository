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
    using MyJobSite.Web.ViewModels.ViewModels.JobPosting;

    public class FavoriteJobPostingsController : BaseController
    {
        private readonly ICandidateFavoriteJobPostingsService candidateFavoriteJobPostingsService;
        private readonly IAccountTypeService accountTypeService;
        private readonly IJobPostingsService jobPostingsService;
        private readonly UserManager<ApplicationUser> userManager;

        public FavoriteJobPostingsController(ICandidateFavoriteJobPostingsService candidateFavoriteJobPostingsService, IAccountTypeService accountTypeService, IJobPostingsService jobPostingsService, UserManager<ApplicationUser> userManager)
        {
            this.candidateFavoriteJobPostingsService = candidateFavoriteJobPostingsService;
            this.accountTypeService = accountTypeService;
            this.jobPostingsService = jobPostingsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> AddToFavorites(string id) //// id == jobPostingId
        {
            var userId = this.userManager.GetUserId(this.User);
            var accountType = this.accountTypeService.GetAccountTypeController(userId);

            if (accountType == "Company")
            {
                return this.Redirect("/"); //// TODO: Change this Redirect with Message
            }

            var checkIfJobApplicationAlreadyAdded = this.candidateFavoriteJobPostingsService.CheckIfFavoriteJobPostingAlreadyExists(userId, id);

            if (checkIfJobApplicationAlreadyAdded == true)
            {
                return this.Redirect("/"); //// TODO: Change this Redirect with Message
            }

            await this.candidateFavoriteJobPostingsService.AddNewCandidatesFavoriteJobPosting(userId, id);
            return this.Redirect("/"); //// TODO: Change this Redirect with Message
        }

        [Authorize]
        public IActionResult GetFavoriteJobPostings()
        {
            var userId = this.userManager.GetUserId(this.User);
            var accountType = this.accountTypeService.GetAccountTypeController(userId);

            if (accountType == "Company")
            {
                this.Redirect("/");
            }

            var jobPostingsIds = this.candidateFavoriteJobPostingsService.GetAllFavoriteJobPostingsIds(userId);
            var viewModel = this.jobPostingsService.GetCandidateAllJobPostingsInformation<BrowseJobPostingViewModel>(jobPostingsIds);

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> RemoveFavoriteJobPosting(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var accountType = this.accountTypeService.GetAccountTypeController(userId);

            if (accountType == "Company")
            {
                this.Redirect("/");
            }

            await this.candidateFavoriteJobPostingsService.DeleteJobPostingFromFavorites(userId, id);
            return this.Redirect("/"); //// TODO: Change this Redirect with Message
        }
    }
}
