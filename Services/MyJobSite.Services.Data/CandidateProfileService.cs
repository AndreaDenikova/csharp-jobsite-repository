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
        private readonly IDeletableEntityRepository<UserInfo> userInfoRepository;

        public CandidateProfileService(IDeletableEntityRepository<UserInfo> userInfoRepository)
        {
            this.userInfoRepository = userInfoRepository;
        }

        public T GetCandidateProfileInformationByUserId<T>(string id)
        {
            var userInfo = this.userInfoRepository.All().Where(u => u.UserId == id).To<T>().FirstOrDefault();

            return userInfo;
        }

        public T GetCandidateProfileInformation<T>(string id)
        {
            var userInfo = this.userInfoRepository.All().Where(u => u.Id == id).To<T>().FirstOrDefault();

            return userInfo;
        }
    }
}
