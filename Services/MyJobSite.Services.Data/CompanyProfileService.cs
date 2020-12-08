namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class CompanyProfileService : ICompanyProfileService
    {
        private readonly IDeletableEntityRepository<CompanyInfo> companyRepository;

        public CompanyProfileService(IDeletableEntityRepository<CompanyInfo> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public T GetCompanyProfileInformation<T>(string id)
        {
            var comp = this.companyRepository.All().Where(c => c.UserId == id).To<T>().FirstOrDefault();
            return comp;
        }
    }
}
