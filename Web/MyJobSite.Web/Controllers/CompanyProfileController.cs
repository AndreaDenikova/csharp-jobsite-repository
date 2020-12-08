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

    public class CompanyProfileController : BaseController
    {
        private readonly ICompanyProfileService companyProfileService;
        private readonly UserManager<ApplicationUser> userManager;

        public CompanyProfileController(ICompanyProfileService companyProfileService, UserManager<ApplicationUser> userManager)
        {
            this.companyProfileService = companyProfileService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> CompanyProfile()
        {
            var userId = this.userManager.GetUserId(this.User);

            var viewModel = this.companyProfileService.GetCompanyProfileInformation<CompanyProfileViewModel>(userId);
            var user = await this.userManager.GetUserAsync(this.User);
            var userEmail = await this.userManager.GetEmailAsync(user);
            viewModel.Email = userEmail;
            return this.View(viewModel);
        }
    }
}
