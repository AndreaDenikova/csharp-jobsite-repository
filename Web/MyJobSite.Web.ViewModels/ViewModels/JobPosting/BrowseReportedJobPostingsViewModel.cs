using MyJobSite.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobSite.Web.ViewModels.ViewModels.JobPosting
{
    public class BrowseReportedJobPostingsViewModel : IMapFrom<MyJobSite.Data.Models.JobPosting>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string CompanyInfoLogo { get; set; }

        public string Type { get; set; }

        public string JobPostingCategoryName { get; set; }

        public string Address { get; set; }

        public string CityName { get; set; }

        public string CompanyName { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
