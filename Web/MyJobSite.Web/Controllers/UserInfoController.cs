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
    using MyJobSite.Web.ViewModels.InputModels;

    public class UserInfoController : BaseController
    {
        private readonly IUserInfoService userInfoService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICitiesService citiesService;

        public UserInfoController(IUserInfoService userInfoService, UserManager<ApplicationUser> userManager, ICitiesService citiesService)
        {
            this.userInfoService = userInfoService;
            this.userManager = userManager;
            this.citiesService = citiesService;
        }

        public IActionResult UserInfo()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserInfo(UserInfoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var cityId = this.citiesService.GetCityId(input.CityName);
            input.CityId = cityId;

            input.UserId = this.userManager.GetUserId(this.User);

            await this.userInfoService.PostUserInfoAsync(input);
            return this.Redirect("/");
        }
    }
}
