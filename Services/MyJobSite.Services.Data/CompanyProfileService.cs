namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

        public bool CheckIfProfileDeleted(string userId)
        {
            var profile = this.companyRepository.AllWithDeleted().Where(p => p.UserId == userId).FirstOrDefault();

            if (profile.IsDeleted == true)
            {
                return true;
            }

            return false;
        }

        public T GetCompanyProfileInformation<T>(string id)
        {
            var comp = this.companyRepository.All().Where(c => c.Id == id).To<T>().FirstOrDefault();
            return comp;
        }

        public T GetCompanyProfileInformationByUserId<T>(string id)
        {
            var comp = this.companyRepository.All().Where(c => c.UserId == id).To<T>().FirstOrDefault();
            return comp;
        }

        public ICollection<T> GetSomeCompaniesInformation<T>(ICollection<string> ids)
        {
            var listCompanies = new List<T>();

            foreach (var id in ids)
            {
                var companyInfo = this.companyRepository.All().Where(c => c.UserId == id).To<T>().FirstOrDefault();

                listCompanies.Add(companyInfo);
            }

            return listCompanies;
        }
    }
}
