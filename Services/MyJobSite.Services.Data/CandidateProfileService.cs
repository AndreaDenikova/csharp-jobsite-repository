namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;
    using MyJobSite.Web.ViewModels.ViewModels;

    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly IDeletableEntityRepository<UserInfo> repository;

        public CandidateProfileService(IDeletableEntityRepository<UserInfo> repository)
        {
            this.repository = repository;
        }

        public T GetCandidateProfileInformation<T>(string id)
        {
            return this.repository.All().Where(u => u.UserId == id).To<T>().FirstOrDefault();
        }
    }
}
