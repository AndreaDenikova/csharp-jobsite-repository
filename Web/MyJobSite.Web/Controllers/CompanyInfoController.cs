namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.InputModels;

    public class CompanyInfoController : BaseController
    {
        private readonly ICompanyInfoService companyInfoService;
        private readonly UserManager<ApplicationUser> userManager;

        public CompanyInfoController(ICompanyInfoService companyInfoService, UserManager<ApplicationUser> userManager)
        {
            this.companyInfoService = companyInfoService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CompanyInfo()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CompanyInfo(CompanyInfoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            input.UserId = this.userManager.GetUserId(this.User);

            await this.companyInfoService.PostCompanyInfoAsync(input);
            return this.Redirect("/");
        }
    }
}
