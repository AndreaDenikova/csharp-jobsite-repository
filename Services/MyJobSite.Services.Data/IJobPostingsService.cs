namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyJobSite.Web.ViewModels.InputModels;

    public interface IJobPostingsService
    {
        Task PostJobPostingAsync(JobPostingInputModel input);

        T GetJobPostingInformation<T>(string id);

        ICollection<T> GetCandidateAllJobPostingsInformation<T>(ICollection<string> ids); //// ids = jobPostingsIds

        ICollection<T> GetSomeJobpostingsInformation<T>(ICollection<string> ids);

        ICollection<T> GetJobPostingsInfo<T>(string categoryId);

        ICollection<T> GetCompanyAllJobPostingsInfo<T>(string companyInfoId);

        string GetJobPostingId(string id);

        string GetCompanyInfoId(string jobPostingId);
    }
}
