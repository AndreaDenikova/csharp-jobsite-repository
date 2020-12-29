namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyJobSite.Web.ViewModels.ViewModels.Message;

    public class MessagesToUsersController : BaseController
    {
        [Authorize]
        public IActionResult AlreadyAppliedForJobPosting()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Message(string message)
        {
            var viewModel = new Messages
            {
                Message = message,
            };

            return this.View(viewModel);
        }
    }
}
