﻿using MyJobSite.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobSite.Data.Models
{
    public class ReportedCompanyProfile : BaseDeletableModel<string>
    {

        public ReportedCompanyProfile()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public int Count { get; set; } = 1;

        //// public string Description { get; set; }
    }
}
