﻿namespace MyJobSite.Data.Models
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

        public virtual CompanyInfo CompanyInfo { get; set; }

        [Required]
        public string CompanyInfoId { get; set; } 

        [Required]
        public string Benefits { get; set; }
    }
}
