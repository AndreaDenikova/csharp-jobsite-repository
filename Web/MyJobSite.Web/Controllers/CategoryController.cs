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
    using MyJobSite.Web.ViewModels.ViewModels.Category;

    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IAccountTypeService accountTypeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserInfoService userInfoService;
        private readonly ICompanyInfoService companyInfoService;

        public CategoryController(ICategoriesService categoriesService, IAccountTypeService accountTypeService, UserManager<ApplicationUser> userManager, IUserInfoService userInfoService, ICompanyInfoService companyInfoService)
        {
            this.categoriesService = categoriesService;
            this.accountTypeService = accountTypeService;
            this.userManager = userManager;
            this.userInfoService = userInfoService;
            this.companyInfoService = companyInfoService;
        }

        public IActionResult Categories()
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
            else if (accountType == "Company")
            {
                var checkInformation = this.companyInfoService.CheckIfHasInformation(userId);

                if (checkInformation == false)
                {
                    return this.RedirectToAction("CompanyInfo", "CompanyInfo");
                }
            }

            var viewModel = this.categoriesService.GetCategories<CategoryViewModel>();
            return this.View(viewModel);
        }
    }
}
