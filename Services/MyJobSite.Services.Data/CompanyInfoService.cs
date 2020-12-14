namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Identity;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Web.ViewModels.InputModels;

    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly IDeletableEntityRepository<CompanyInfo> companyInfoRepository;

        public CompanyInfoService(IDeletableEntityRepository<CompanyInfo> companyInfoRepository)
        {
            this.companyInfoRepository = companyInfoRepository;
        }

        public string GetCompanyInfoId(string userId)
        {
            var user = this.companyInfoRepository.All().Where(c => c.UserId == userId).FirstOrDefault();
            var companyInfoId = user.Id;

            return companyInfoId;
        }

        public string GetCompanyLogo(string userId)
        {
            var user = this.companyInfoRepository.All().Where(c => c.UserId == userId).FirstOrDefault();
            var logo = user.Logo;

            return logo;
        }

        public string GetCompanyName(string userId)
        {
            var user = this.companyInfoRepository.All().Where(c => c.UserId == userId).FirstOrDefault();
            var companyName = user.Name;

            return companyName;
        }

        public async Task PostCompanyInfoAsync(CompanyInfoInputModel input)
        {
            var companyInfo = new CompanyInfo
            {
                Name = input.Name,
                UserId = input.UserId,
                Logo = this.UploadImageToCloudinary(input.Logo.OpenReadStream()),
                Description = input.Description,
                Address = input.Address,
                PhoneNumber = input.PhoneNumber,
            };
            await this.companyInfoRepository.AddAsync(companyInfo);
            await this.companyInfoRepository.SaveChangesAsync();
        }

        public string UploadImageToCloudinary(Stream imageFileStream)
        {
            Account account = new Account
            {
                Cloud = "dbtzqb6py",
                ApiKey = "276848394448911",
                ApiSecret = "ymMC-yDsSc2BGAtvUYWrOcDLaTg",
            };

            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("thrumbnail", imageFileStream),
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUri.AbsoluteUri;
        }
    }
}
