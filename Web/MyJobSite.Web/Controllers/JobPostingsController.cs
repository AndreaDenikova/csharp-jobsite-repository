namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data.Models;

    public class JobPostingsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public JobPostingsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult JobPostings()
        {
            return this.View();
        }
    }
}
