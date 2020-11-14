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

        public virtual Company Company { get; set; }

        public string CompanyId { get; set; }

        public string Picture { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
