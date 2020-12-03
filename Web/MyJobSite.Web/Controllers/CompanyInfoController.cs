namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data;
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.InputModels;

    public class CompanyInfoController : BaseController
    {
        private readonly ICompanyInfoService companyInfoService;

        public CompanyInfoController(ICompanyInfoService companyInfoService)
        {
            this.companyInfoService = companyInfoService;
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

            await this.companyInfoService.PostCompanyInfoAsync(input);
            return this.Redirect("/");
        }
    }
}
