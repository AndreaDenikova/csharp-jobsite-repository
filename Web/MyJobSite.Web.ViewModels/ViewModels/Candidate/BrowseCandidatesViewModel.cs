namespace MyJobSite.Web.ViewModels.ViewModels.Candidate
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class BrowseCandidatesViewModel : IMapFrom<UserInfo>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserId { get; set; }

        public string ProfilePicture { get; set; }

        public string Address { get; set; }

        public string CityName { get; set; }
    }
}
