namespace MyJobSite.Web.ViewModels.ViewModels.Company
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class BrowseReportedCompaniesViewModel : IMapFrom<CompanyInfo>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
