namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class Candidate : BaseDeletableModel<string>
    {
        public Candidate()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual JobPosting JobPosting { get; set; }

        public string JobPostingId { get; set; }
    }
}
