namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class ReportedJobPosting : BaseDeletableModel<string>
    {
        public ReportedJobPosting()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual JobPosting JobPosting { get; set; }

        public string JobPostingId { get; set; }

        public int Count { get; set; } = 1;
    }
}
