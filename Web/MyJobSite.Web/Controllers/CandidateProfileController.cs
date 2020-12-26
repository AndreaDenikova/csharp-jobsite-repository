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
    using MyJobSite.Web.ViewModels.ViewModels;
    using MyJobSite.Web.ViewModels.ViewModels.Candidate;

    public class CandidateProfileController : BaseController
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserInfoService userInfoService;
        private readonly ICandidatesService candidatesService;
        private readonly IAccountTypeService accountTypeService;

        public CandidateProfileController(ICandidateProfileService candidateProfileService, UserManager<ApplicationUser> userManager, IUserInfoService userInfoService, ICandidatesService candidatesService, IAccountTypeService accountTypeService)
        {
            this.candidateProfileService = candidateProfileService;
            this.userManager = userManager;
            this.userInfoService = userInfoService;
            this.candidatesService = candidatesService;
            this.accountTypeService = accountTypeService;
        }

        [Authorize]
        public async Task<IActionResult> CandidateProfile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var userId = this.userManager.GetUserId(this.User);
                var accountType = this.accountTypeService.GetAccountTypeController(userId);

                if (accountType == "Candidate")
                {
                    var checkInformation = this.userInfoService.CheckIfHasInformation(userId);

                    if (checkInformation == false)
                    {
                        return this.RedirectToAction("UserInfo", "UserInfo");
                    }
                }

                var viewModel = this.candidateProfileService.GetCandidateProfileInformationByUserId<CandidateProfileViewModel>(userId);
                var user = await this.userManager.GetUserAsync(this.User);
                var userEmail = await this.userManager.GetEmailAsync(user);
                viewModel.Email = userEmail;
                return this.View(viewModel);
            }
            else
            {
                var viewModel = this.candidateProfileService.GetCandidateProfileInformation<CandidateProfileViewModel>(id);
                var userId = this.userInfoService.GetUserInfoUserId(id);
                var user = await this.userManager.FindByIdAsync(userId);
                var userEmail = await this.userManager.GetEmailAsync(user);
                viewModel.Email = userEmail;
                return this.View(viewModel);
            }
        }

        [Authorize]
        public IActionResult BrowseCandidates(string id) //// jobPostingId
        {
            var ids = this.candidatesService.GetAllUsersIdOfJobPosting(id);
            var viewModel = this.candidateProfileService.GetCandidatesProfileInfoByUserIds<BrowseCandidatesViewModel>(ids);

            return this.View(viewModel);
        }
    }
}
