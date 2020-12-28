namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICompanyProfileService
    {
        T GetCompanyProfileInformation<T>(string id);

        T GetCompanyProfileInformationByUserId<T>(string id);

        ICollection<T> GetSomeCompaniesInformation<T>(ICollection<string> ids);

        bool CheckIfProfileDeleted(string userId);
    }
}
