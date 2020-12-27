namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class ReportedProfile : BaseDeletableModel<string>
    {
        public ReportedProfile()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public int Count { get; set; } = 1;
    }
}
