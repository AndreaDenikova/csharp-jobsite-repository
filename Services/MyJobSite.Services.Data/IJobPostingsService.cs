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
    }
}
