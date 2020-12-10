namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class JobPosting : BaseDeletableModel<string>
    {
        public JobPosting()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Requirements { get; set; }

        [Required]
        public string Responsibilities { get; set; }

        [Required]
        public string Skills { get; set; }

        public virtual CompanyInfo CompanyInfo { get; set; }

        [Required]
        public string CompanyInfoId { get; set; }

        [Required]
        public string Benefits { get; set; }

        public virtual JobPostingCategory JobPostingCategory { get; set; }

        public string JobPostingCategoryId { get; set; }

        public string Instructions { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }
    }
}
