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

    public class UserInfoServiceTests
    {
        [Fact]
        public async Task CreateNewCandidateForJobPostingAsyncTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<UserInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetUserInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new UserInfoService(repository);

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

            var inputModel = new UserInfoInputModel
            {
                UserId = "6",
                FirstName = "Andrea",
                LastName = "Denikova",
                Description = "bgscdsu",
                ProfilePicture = fileMockImage.Object,
                Cv = fileMockCv.Object,
                Address = "bcsuigvfdgvdfcdz",
                CityId = "1",
            };

            await service.PostUserInfoAsync(inputModel);

            var candidatesCount = repository.All().ToList().Count;

            Assert.Equal(4, candidatesCount);
        }

        [Fact]
        public void GetUserInfoUserIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<UserInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetUserInfoData());

            var service = new UserInfoService(mockRepository.Object);

            var check = service.GetUserInfoUserId("1");

            Assert.Equal("1", check);
        }

        [Fact]
        public void CheckIfHasInformationTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<UserInfo>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetUserInfoData());

            var service = new UserInfoService(mockRepository.Object);

            var check = service.CheckIfHasInformation("1");

            Assert.True(check);
        }

        [Fact]
        public async Task MarkUserInfoAsDeletedTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<UserInfo>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetUserInfoData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new UserInfoService(repository);

            await service.MarkUserInfoAsDeleted("1");

            var user = repository.AllWithDeleted().Where(x => x.UserId == "1").FirstOrDefault();

            Assert.True(user.IsDeleted);
        }

        private IQueryable<UserInfo> GetUserInfoData()
        {
            return new List<UserInfo>
            {
                new UserInfo
                {
                    UserId = "1",
                    FirstName = "Andrea",
                    LastName = "Denikova",
                    Description = "bgscdsu",
                    ProfilePicture = "ProfilePicture",
                    CV = "Cv",
                    Address = "bcsuigvfdgvdfcdz",
                    CityId = "1",
                },
                new UserInfo
                {
                    UserId = "2",
                    FirstName = "Adi",
                    LastName = "Petrova",
                    Description = "bggvfdgvdfscdsu",
                    ProfilePicture = "ProfilePicture",
                    CV = "Cv",
                    Address = "bcsuicdz",
                    CityId = "1",
                },
                new UserInfo
                {
                    UserId = "4",
                    FirstName = "Andrea",
                    LastName = "Denikova",
                    Description = "bggvrdgvdfscdsu",
                    ProfilePicture = "ProfilePicture",
                    CV = "Cv",
                    CityId = "3",
                },
            }.AsQueryable();
        }
    }
}
