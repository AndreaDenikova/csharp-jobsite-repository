namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Data;
    using MyJobSite.Services.Data;
    using MyJobSite.Web.ViewModels.ViewModels.Category;

    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Categories()
        {
            var viewModel = this.categoriesService.GetCategories<CategoryViewModel>();
            return this.View(viewModel);
        }
    }
}
