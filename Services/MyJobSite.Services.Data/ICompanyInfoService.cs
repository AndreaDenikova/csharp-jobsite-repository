namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using MyJobSite.Web.ViewModels.InputModels;

    public interface ICompanyInfoService
    {
        string UploadImageToCloudinary(Stream imageFileStream);

        Task PostCompanyInfoAsync(CompanyInfoInputModel input);

        string GetCompanyInfoId(string userId);

        string GetCompanyLogo(string userId);

        string GetCompanyName(string userId);

        string GetCompanyInfoName(string companyInfoId);

        string GetCompanyInfoLogo(string companyInfoId);
    }
}
