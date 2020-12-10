namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAccountTypeService
    {
        string GetAccoutType(ClaimsPrincipal claimsPrincipal);

        string GetAccountTypeController(string userId);
    }
}
