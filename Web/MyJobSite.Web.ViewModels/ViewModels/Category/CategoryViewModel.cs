namespace MyJobSite.Web.ViewModels.ViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class CategoryViewModel : IMapFrom<JobPostingCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int JobPostringsCount { get; set; }

        public int CandidatesCount { get; set; }
    }
}
