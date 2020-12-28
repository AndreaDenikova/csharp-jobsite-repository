namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;

    public class AccountTypeService : IAccountTypeService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;

        public AccountTypeService(UserManager<ApplicationUser> userManager, IDeletableEntityRepository<ApplicationUser> applicationUser)
        {
            this.userManager = userManager;
            this.applicationUser = applicationUser;
        }

        public string GetAccoutType(ClaimsPrincipal claimsPrincipal)
        {
            var user = this.userManager.GetUserAsync(claimsPrincipal).GetAwaiter().GetResult();
            string userType = user.AccountType;
            return userType;
        }

        public string GetAccountTypeController(string userId)
        {
            var user = this.applicationUser.All().Where(c => c.Id == userId).FirstOrDefault();
            var userType = user.AccountType;

            return userType;
        }

        public string GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            var user = this.userManager.GetUserAsync(claimsPrincipal).GetAwaiter().GetResult();
            string userId = user.Id;
            return userId;
        }

        public async Task MarkProfileAsDeleted(string id)
        {
            var profile = this.applicationUser.All().Where(u => u.Id == id).FirstOrDefault();

            this.applicationUser.Delete(profile);

            await this.applicationUser.SaveChangesAsync();
        }
    }
}
