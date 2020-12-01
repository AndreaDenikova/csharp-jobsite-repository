namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data;

    public class CompanyInfoController : BaseController
    {
        private readonly ApplicationDbContext db;

        public CompanyInfoController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult CompanyInfo()
        {
            return this.View();
        }

        //[HttpPost]
        //public IActionResult CompanyInfo()
        //{
        //    return this.View();
        //}
    }
}
