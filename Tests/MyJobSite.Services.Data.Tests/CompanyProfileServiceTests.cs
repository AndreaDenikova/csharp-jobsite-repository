namespace MyJobSite.Services.Data.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MyJobSite.Data;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Data.Repositories;
    using MyJobSite.Services.Mapping;
    using MyJobSite.Web.ViewModels.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class CompanyProfileServiceTests
    {
        [Fact]
        public async Task GetCompanyProfileInformationTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<CompanyInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCompanyInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CompanyProfileService(repository);

            AutoMapperConfig.RegisterMappings(typeof(CompanyProfileViewModel).Assembly);

            var profile = service.GetCompanyProfileInformation<CompanyProfileViewModel>("11");

            Assert.Equal("bcsuigvfdgvdfcdz", profile.Address);
        }

        [Fact]
        public async Task GetCompanyProfileInformationByUserIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<CompanyInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCompanyInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CompanyProfileService(repository);

            AutoMapperConfig.RegisterMappings(typeof(CompanyProfileViewModel).Assembly);

            var profile = service.GetCompanyProfileInformationByUserId<CompanyProfileViewModel>("1");

            Assert.Equal("bcsuigvfdgvdfcdz", profile.Address);
        }

        [Fact]
        public async Task GetSomeCompaniesInformationTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<CompanyInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCompanyInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CompanyProfileService(repository);

            AutoMapperConfig.RegisterMappings(typeof(CompanyProfileViewModel).Assembly);

            var listOfUserIds = new List<string> { "1", "2" };

            var companyInfo = service.GetSomeCompaniesInformation<CompanyProfileViewModel>(listOfUserIds);

            Assert.Equal(2, companyInfo.Count);
        }

        [Fact]
        public void CheckIfProfileDeletedTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.AllWithDeleted()).Returns(this.GetCompanyInfoData());

            var service = new CompanyProfileService(mockRepository.Object);

            var check = service.CheckIfProfileDeleted("1");

            Assert.False(check);
        }

        private IQueryable<CompanyInfo> GetCompanyInfoData()
        {
            return new List<CompanyInfo>
            {
                new CompanyInfo
                {
                    Id = "11",
                    UserId = "1",
                    Name = "Andrea Denikova",
                    Description = "bgscdsu",
                    Logo = "ProfilePicture",
                    Address = "bcsuigvfdgvdfcdz",
                    PhoneNumber = "888130130",
                },
                new CompanyInfo
                {
                    Id = "22",
                    UserId = "2",
                    Name = "Andrea Denikova",
                    Description = "bgscdsu",
                    Logo = "ProfilePicture",
                    Address = "bcsuigvfdgvdfcdz",
                    PhoneNumber = "888130130",
                },
                new CompanyInfo
                {
                    Id = "33",
                    UserId = "3",
                    Name = "Andrea Denikova",
                    Description = "bgscdsu",
                    Logo = "ProfilePicture",
                    Address = "bcsuigvfdgvdfcdz",
                    PhoneNumber = "888130130",
                },
            }.AsQueryable();
        }
    }
}
