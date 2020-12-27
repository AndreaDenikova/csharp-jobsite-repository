namespace MyJobSite.Web.Areas.Administration.Controllers
{
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IReportsJobPostingService reportsJobPostingService;
        private readonly IReportsProfileService reportsProfileService;

        public DashboardController(ISettingsService settingsService, IReportsJobPostingService reportsJobPostingService, IReportsProfileService reportsProfileService)
        {
            this.settingsService = settingsService;
            this.reportsJobPostingService = reportsJobPostingService;
            this.reportsProfileService = reportsProfileService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }

        
    }
}
