namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using MyJobSite.Data.Models;

    public class AccountTypeService : IAccountTypeService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountTypeService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public string GetAccoutType(ClaimsPrincipal claimsPrincipal)
        {
            var user = this.userManager.GetUserAsync(claimsPrincipal).GetAwaiter().GetResult();
            string userType = user.AccountType;
            return userType;
        }
    }
}
