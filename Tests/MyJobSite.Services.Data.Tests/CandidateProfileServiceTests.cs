namespace MyJobSite.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MyJobSite.Data;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Data.Repositories;
    using MyJobSite.Services.Mapping;
    using MyJobSite.Web.ViewModels.ViewModels;
    using Xunit;

    public class CandidateProfileServiceTests
    {
        [Fact]
        public async Task GetCandidateProfileInformationTest()
        {
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            //var repository = new EfDeletableEntityRepository<UserInfo>(new ApplicationDbContext(options.Options));
            //var repository2 = new EfDeletableEntityRepository<City>(new ApplicationDbContext(options.Options));

            //foreach (var item in this.GetCandidateProfileData())
            //{
            //    await repository.AddAsync(item);
            //    await repository.SaveChangesAsync();
            //}

            //await repository2.AddAsync(new City { Id = "1", Name = "asdf" });

            ////var mockRepository = new Mock<IDeletableEntityRepository<UserInfo>>();

            ////mockRepository.Setup(x => x.All()).Returns(this.GetCandidateProfileData());

            //var service = new CandidateProfileService(repository);

            //AutoMapperConfig.RegisterMappings(typeof(CandidateProfileViewModel).Assembly);

            //var profile = service.GetCandidateProfileInformation<CandidateProfileViewModel>("123");

            //Assert.Equal("asd", profile.Address);

            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            //var segmentsRepository = new EfDeletableEntityRepository<UserInfo>(new ApplicationDbContext(options.Options));
            //foreach (var segment in this.GetCandidateProfileData())
            //{
            //    await segmentsRepository.AddAsync(segment);
            //    await segmentsRepository.SaveChangesAsync();
            //}

            //AutoMapperConfig.RegisterMappings(typeof(CandidateProfileViewModel).Assembly);
            //var service = new CandidateProfileService(segmentsRepository);
            //var segments = service.GetCandidateProfileInformation<CandidateProfileViewModel>("lesson1");
            //Assert.NotNull(segments);
        }

        [Fact]
        public void GetCandidatesProfileInfoByUserIdsTest()
        {
            //var mockRepository = new Mock<IDeletableEntityRepository<UserInfo>>();

            //mockRepository.Setup(x => x.All()).Returns(this.GetCandidateProfileData());

            //var service = new CandidateProfileService(mockRepository.Object);

            //AutoMapperConfig.RegisterMappings(typeof(CandidateProfileViewModel).Assembly);

            //var listIds = new List<string> { "lesson1", "231" };

            //var profiles = service.GetCandidatesProfileInfoByUserIds<CandidateProfileViewModel>(listIds).ToList();

            //Assert.Equal(2, profiles.Count());
        }

        [Fact]
        public void CheckIfProfileDeletedTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<UserInfo>>();

            mockRepository.Setup(x => x.AllWithDeleted()).Returns(this.GetCandidateProfileData());

            var service = new CandidateProfileService(mockRepository.Object);

            var check = service.CheckIfProfileDeleted("lesson1");

            Assert.False(check);
        }

        private IQueryable<UserInfo> GetCandidateProfileData()
        {
            return new List<UserInfo>
            {
                new UserInfo
                {
                    UserId = "lesson1",
                    Address = "asd",
                    CityId = "1",
                    CV = "cv",
                    Description = "desc",
                    FirstName = "a",
                    LastName = "b",
                    ProfilePicture = "pic",
                },
                new UserInfo
                {
                    UserId = "231",
                    Address = "asd2",
                    CityId = "2",
                    CV = "cv2",
                    Description = "desc2",
                    FirstName = "n",
                    LastName = "q",
                    ProfilePicture = "pic2",
                },
                new UserInfo
                {
                    UserId = "4dwc",
                    Address = "asd3",
                    CityId = "3",
                    CV = "cv3",
                    Description = "desc3",
                    FirstName = "g",
                    LastName = "x",
                    ProfilePicture = "pic1",
                },
            }.AsQueryable();
        }
    }
}
