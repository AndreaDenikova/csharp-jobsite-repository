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

    public class CandidateProfileController : BaseController
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserInfoService userInfoService;

        public CandidateProfileController(ICandidateProfileService candidateProfileService, UserManager<ApplicationUser> userManager, IUserInfoService userInfoService)
        {
            this.candidateProfileService = candidateProfileService;
            this.userManager = userManager;
            this.userInfoService = userInfoService;
        }

        [Authorize]
        public async Task<IActionResult> CandidateProfile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var userId = this.userManager.GetUserId(this.User);

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
    }
}
