namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Web.ViewModels.ViewModels;

    public interface ICandidateProfileService
    {
        T GetCandidateProfileInformation<T>(string id);
    }
}
