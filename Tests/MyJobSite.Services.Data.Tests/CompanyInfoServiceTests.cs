namespace MyJobSite.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MyJobSite.Data;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Data.Repositories;
    using MyJobSite.Web.ViewModels.InputModels;
    using Xunit;

    public class CompanyInfoServiceTests
    {
        [Fact]
        public async Task PostCompanyInfoAsyncTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<CompanyInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCompanyInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CompanyInfoService(repository);

            var fileMockCv = new Mock<IFormFile>();

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMockCv.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMockCv.Setup(_ => _.FileName).Returns(fileName);
            fileMockCv.Setup(_ => _.Length).Returns(ms.Length);

            WebClient client = new WebClient();
            var stream = client.OpenRead("https://ichef.bbci.co.uk/news/976/cpsprodpb/41CF/production/_109474861_angrycat-index-getty3-3.jpg");

            var fileMockImage = new Mock<IFormFile>();
            fileMockImage.Setup(_ => _.OpenReadStream()).Returns(stream);
            fileMockImage.Setup(_ => _.FileName).Returns("cat.jpg");

            var inputModel = new CompanyInfoInputModel
            {
                UserId = "6",
                Name = "Andrea",
                Description = "bgscdsu",
                Logo = fileMockImage.Object,
                Address = "bcsuigvfdgvdfcdz",
                PhoneNumber = "0888130130",
            };

            await service.PostCompanyInfoAsync(inputModel);

            var candidatesCount = repository.All().ToList().Count;

            Assert.Equal(4, candidatesCount);
        }

        [Fact]
        public void GetCompanyInfoIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetCompanyInfoId("1");

            Assert.Equal("11", check);
        }

        [Fact]
        public void CheckIfHasInformationTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.CheckIfHasInformation("1");

            Assert.True(check);
        }

        [Fact]
        public async Task MarkCompanyInfoAsDeletedTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<CompanyInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCompanyInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CompanyInfoService(repository);

            await service.MarkCompanyInfoAsDeleted("1");

            var user = repository.AllWithDeleted().Where(x => x.UserId == "1").FirstOrDefault();

            Assert.True(user.IsDeleted);
        }

        [Fact]
        public void GetUserIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetUserId("11");

            Assert.Equal("1", check);
        }

        [Fact]
        public void GetCompanyLogoTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetCompanyLogo("1");

            Assert.Equal("ProfilePicture", check);
        }

        [Fact]
        public void GetCompanyNameTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetCompanyName("1");

            Assert.Equal("Andrea Denikova", check);
        }

        [Fact]
        public void GetCompanyInfoNameTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetCompanyInfoName("11");

            Assert.Equal("Andrea Denikova", check);
        }

        [Fact]
        public void GetCompanyInfoLogoTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetCompanyInfoLogo("11");

            Assert.Equal("ProfilePicture", check);
        }

        [Fact]
        public void GetCompanyInfoUserIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<CompanyInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCompanyInfoData());

            var service = new CompanyInfoService(mockRepository.Object);

            var check = service.GetCompanyInfoUserId("11");

            Assert.Equal("1", check);
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
