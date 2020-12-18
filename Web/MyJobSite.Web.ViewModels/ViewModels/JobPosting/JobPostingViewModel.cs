namespace MyJobSite.Web.ViewModels.ViewModels.JobPosting
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class JobPostingViewModel : IMapFrom<JobPosting>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string Requirments { get; set; }

        public string Responsibilities { get; set; }

        public string Type { get; set; }

        public string JobPostingCategoryName { get; set; }

        public string Instructions { get; set; }

        public string Skills { get; set; }

        public string Address { get; set; }

        public string CityName { get; set; }

        public string Benefits { get; set; }

        public string CompanyName { get; set; }

        public string CompanyInfoId { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }
    }
}
