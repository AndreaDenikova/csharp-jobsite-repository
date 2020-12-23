﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyJobSite.Data.Models;
using MyJobSite.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJobSite.Web.Controllers
{
    public class FavoriteJobPostings : BaseController
    {
        private readonly ICandidateFavoriteJobPostingsService candidateFavoriteJobPostingsService;
        private readonly IAccountTypeService accountTypeService;
        private readonly UserManager<ApplicationUser> userManager;

        public FavoriteJobPostings(ICandidateFavoriteJobPostingsService candidateFavoriteJobPostingsService, IAccountTypeService accountTypeService, UserManager<ApplicationUser> userManager)
        {
            this.candidateFavoriteJobPostingsService = candidateFavoriteJobPostingsService;
            this.accountTypeService = accountTypeService;
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
    }
}
