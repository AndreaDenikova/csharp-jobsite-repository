namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class CompanyInfo : BaseDeletableModel<string>
    {
        public CompanyInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
