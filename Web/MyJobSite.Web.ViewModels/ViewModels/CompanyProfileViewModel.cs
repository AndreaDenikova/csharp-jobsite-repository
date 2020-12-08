namespace MyJobSite.Web.ViewModels.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class CompanyProfileViewModel : IMapFrom<CompanyInfo>
    {
        public string CompanyName { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
