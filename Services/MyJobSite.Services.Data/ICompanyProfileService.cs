namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICompanyProfileService
    {
        T GetCompanyProfileInformation<T>(string id);
    }
}
