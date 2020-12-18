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
        private readonly ICompanyInfoService companyInfoService;

        public CompanyProfileController(ICompanyProfileService companyProfileService, UserManager<ApplicationUser> userManager, ICompanyInfoService companyInfoService)
        {
            this.companyProfileService = companyProfileService;
            this.userManager = userManager;
            this.companyInfoService = companyInfoService;
        }

        [Authorize]
        public async Task<IActionResult> CompanyProfile(string id)
        {
            var viewModel = this.companyProfileService.GetCompanyProfileInformation<CompanyProfileViewModel>(id);
            var userId = this.companyInfoService.GetCompanyInfoUserId(id);
            var user = await this.userManager.FindByIdAsync(userId);
            var userEmail = await this.userManager.GetEmailAsync(user);
            viewModel.Email = userEmail;
            return this.View(viewModel);
        }
    }
}
