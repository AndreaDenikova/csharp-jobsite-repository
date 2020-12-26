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
        private readonly IAccountTypeService accountTypeService;

        public CompanyProfileController(ICompanyProfileService companyProfileService, UserManager<ApplicationUser> userManager, ICompanyInfoService companyInfoService, IAccountTypeService accountTypeService)
        {
            this.companyProfileService = companyProfileService;
            this.userManager = userManager;
            this.companyInfoService = companyInfoService;
            this.accountTypeService = accountTypeService;
        }

        [Authorize]
        public async Task<IActionResult> CompanyProfile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var userId = this.userManager.GetUserId(this.User);
                var accountType = this.accountTypeService.GetAccountTypeController(userId);
                if (accountType == "Company")
                {
                    var checkInformation = this.companyInfoService.CheckIfHasInformation(userId);

                    if (checkInformation == false)
                    {
                        return this.RedirectToAction("CompanyInfo", "CompanyInfo");
                    }
                }

                var viewModel = this.companyProfileService.GetCompanyProfileInformationByUserId<CompanyProfileViewModel>(userId);
                var user = await this.userManager.FindByIdAsync(userId);
                var userEmail = await this.userManager.GetEmailAsync(user);
                viewModel.Email = userEmail;
                return this.View(viewModel);
            }
            else
            {
                var userId = this.companyInfoService.GetUserId(id);
                var viewModel = this.companyProfileService.GetCompanyProfileInformation<CompanyProfileViewModel>(id);
                var user = await this.userManager.FindByIdAsync(userId);
                var userEmail = await this.userManager.GetEmailAsync(user);
                viewModel.Email = userEmail;
                return this.View(viewModel);
            }
        }
    }
}
