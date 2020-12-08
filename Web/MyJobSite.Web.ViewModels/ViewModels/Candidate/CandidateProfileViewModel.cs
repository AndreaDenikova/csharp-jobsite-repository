namespace MyJobSite.Web.ViewModels.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class CandidateProfileViewModel : IMapFrom<UserInfo>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        public string Cv { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

    }
}
