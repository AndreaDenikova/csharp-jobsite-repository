namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class JobPostingCategory : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public ICollection<JobPosting> JobPostings { get; set; }
    }
}
