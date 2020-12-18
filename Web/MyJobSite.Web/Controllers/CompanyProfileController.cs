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
            if (string.IsNullOrEmpty(id))
            {
                var userId = this.userManager.GetUserId(this.User);
                var viewModel = this.companyProfileService.GetCompanyProfileInformationByUserId<CompanyProfileViewModel>(userId);
                var user = await this.userManager.FindByIdAsync(userId);
                var userEmail = await this.userManager.GetEmailAsync(user);
                viewModel.Email = userEmail;
                return this.View(viewModel);
            }
            else
            {
                var viewModel = this.companyProfileService.GetCompanyProfileInformation<CompanyProfileViewModel>(id);
                var userId = this.companyInfoService.GetCompanyInfoUserId(id);
                var user = await this.userManager.FindByIdAsync(userId);
                var userEmail = await this.userManager.GetEmailAsync(user);
                viewModel.Email = userEmail;
                return this.View(viewModel);
            }
        }

        //[Authorize]
        //public async Task<IActionResult> CompanyProfile()
        //{
        //    var userId = this.userManager.GetUserId(this.User);
        //    var viewModel = this.companyProfileService.GetCompanyProfileInformationByUserId<CompanyProfileViewModel>(userId);
        //    var user = await this.userManager.FindByIdAsync(userId);
        //    var userEmail = await this.userManager.GetEmailAsync(user);
        //    viewModel.Email = userEmail;
        //    return this.View(viewModel);
        //}
    }
}
