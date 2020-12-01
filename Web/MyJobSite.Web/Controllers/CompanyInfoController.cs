namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data;
    using MyJobSite.Web.ViewModels.InputModels;

    public class CompanyInfoController : BaseController
    {
        [HttpGet]
        public IActionResult CompanyInfo()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CompanyInfo(CompanyInfoInputModel input)
        {
            return this.View();
        }
    }
}
