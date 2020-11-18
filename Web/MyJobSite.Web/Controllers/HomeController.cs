namespace MyJobSite.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Web.ViewModels;

    public class HomeController : BaseController
    {
        public IActionResult Contact()
        {
            return this.View();
        }

        public IActionResult JobDetail()
        {
            return this.View();
        }

        public IActionResult BrowseCandidates()
        {
            return this.View();
        }

        public IActionResult Error404()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        public IActionResult LogIn()
        {
            return this.View();
        }

        public IActionResult BrowseJob()
        {
            return this.View();
        }

        public IActionResult AboutUs()
        {
            return this.View();
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
