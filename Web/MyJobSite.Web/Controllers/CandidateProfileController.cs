﻿namespace MyJobSite.Web.Controllers
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

        public CandidateProfileController(ICandidateProfileService candidateProfileService, UserManager<ApplicationUser> userManager)
        {
            this.candidateProfileService = candidateProfileService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> CandidateProfile()
        {
            var userId = this.userManager.GetUserId(this.User);

            var viewModel = this.candidateProfileService.GetCandidateProfileInformation<CandidateProfileViewModel>(userId);
            var user = await this.userManager.GetUserAsync(this.User);
            var userEmail = await this.userManager.GetEmailAsync(user);
            viewModel.Email = userEmail;
            return this.View(viewModel);
        }
    }
}