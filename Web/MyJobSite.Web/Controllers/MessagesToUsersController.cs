namespace MyJobSite.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesToUsersController : BaseController
    {
        [Authorize]
        public IActionResult AlreadyAppliedForJobPosting()
        {
            return this.View();
        }
    }
}
