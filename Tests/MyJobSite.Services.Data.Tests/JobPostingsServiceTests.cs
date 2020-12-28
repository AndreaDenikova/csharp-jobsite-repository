using Microsoft.EntityFrameworkCore;
using Moq;
using MyJobSite.Data;
using MyJobSite.Data.Common.Repositories;
using MyJobSite.Data.Models;
using MyJobSite.Data.Repositories;
using MyJobSite.Services.Mapping;
using MyJobSite.Web.ViewModels.InputModels;
using MyJobSite.Web.ViewModels.ViewModels.JobPosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyJobSite.Services.Data.Tests
{
    public class JobPostingsServiceTests
    {
        [Fact]
        public async Task PostCompanyInfoAsyncTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<JobPosting>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetJobPostingData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new JobPostingsService(repository);

            var inputModel = new JobPostingInputModel
            {
                JobTitle = "Game Developer",
                Description = "cfbdsuicbsioachnishc",
                Location = "ncscnskojcos",
                Requirements = "bciusdbciosbchishncs",
                Skills = "bhisudbc isubc is",
                Responsibilities = "cbsucbn sicsinhcsnhucv dxicjnis",
                Benefits = "bcsuigvfdgvdvdvdfcdz",
                Category = "Game",
                JobPostingCategoryId = "1",
                CompanyInfoId = "11",
                VacancyType = "Full time",
                CityId = "111",
                Instructions = "nhcidoshncsdhncsd",
                MaxSalary = 2500,
                MinSalary = 1000,
            };

            await service.PostJobPostingAsync(inputModel);

            var candidatesCount = repository.All().ToList().Count;

            Assert.Equal(2, candidatesCount);
        }

        [Fact]
        public async Task MarkJobPostingAsDeletedTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<JobPosting>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetJobPostingData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new JobPostingsService(repository);

            await service.MarkJobPostingAsDeleted("2222");

            var user = repository.AllWithDeleted().Where(x => x.Id == "2222").FirstOrDefault();

            Assert.True(user.IsDeleted);
        }

        [Fact]
        public async Task GetJobPostingInformationTest()
        {
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //  .UseInMemoryDatabase(Guid.NewGuid().ToString());

            //var repository = new EfDeletableEntityRepository<JobPosting>(new ApplicationDbContext(options.Options));

            //foreach (var item in this.GetJobPostingData())
            //{
            //    await repository.AddAsync(item);
            //    await repository.SaveChangesAsync();
            //}

            //var service = new JobPostingsService(repository);

            //AutoMapperConfig.RegisterMappings(typeof(JobPostingViewModel).Assembly);

            //var profile = service.GetJobPostingInformation<JobPostingViewModel>("2222");

            //Assert.Equal("Game Developer", profile.Title);
        }

        [Fact]
        public void GetJobPostingIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPosting>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetJobPostingData());

            var service = new JobPostingsService(mockRepository.Object);

            var check = service.GetJobPostingId("22");

            Assert.Equal("22", check);
        }

        [Fact]
        public void GetCompanyInfoIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPosting>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetJobPostingData());

            var service = new JobPostingsService(mockRepository.Object);

            var check = service.GetCompanyInfoId("2222");

            Assert.Equal("22", check);
        }

        [Fact]
        public void GetAllJobPostingsByUserIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPosting>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetJobPostingData());

            var service = new JobPostingsService(mockRepository.Object);

            var cityNames = service.GetAllJobPostingsByUserId("22");

            var result = new List<string> { "2222" }.OrderBy(n => n);

            Assert.Equal(result, cityNames);
        }

        [Fact]
        public async Task MarkJobPostingsAsDeleted()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<JobPosting>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetJobPostingData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new JobPostingsService(repository);

            var listIds = new List<string> { "2222" };

            await service.MarkJobPostingsAsDeleted(listIds);

            foreach (var id in listIds)
            {
                var user = repository.AllWithDeleted().Where(x => x.Id == id).FirstOrDefault();
                Assert.True(user.IsDeleted);
            }
        }

        [Fact]
        public void CheckIfIsDeletedTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPosting>>();

            mockRepository.Setup(x => x.AllWithDeleted()).Returns(this.GetJobPostingData());

            var service = new JobPostingsService(mockRepository.Object);

            var check = service.CheckIfIsDeleted("2222");

            Assert.False(check);
        }

        [Fact]
        public void GetJobPostingsCountTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPosting>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetJobPostingData());

            var service = new JobPostingsService(mockRepository.Object);

            var check = service.GetJobPostingsCount("2");

            Assert.Equal(1, check);
        }

        private IQueryable<JobPosting> GetJobPostingData()
        {
            return new List<JobPosting>
            {
                new JobPosting
                {
                    Id = "2222",
                    Title = "Game Developer",
                    Description = "cfbdsuicbsioachnishc",
                    Address = "ncscnskojcos",
                    Requirements = "bciusdbciosbchishncs",
                    Skills = "bhisudbc isubc is",
                    Responsibilities = "cbsucbn sicsinhcsnhucv dxicjnis",
                    Benefits = "bcsuigvfdgvdvdvdfcdz",
                    JobPostingCategoryId = "2",
                    CompanyInfoId = "22",
                    Type = "Full time",
                    CityId = "222",
                    Instructions = "nhcidoshncsdhncsd",
                    MaxSalary = 2500,
                    MinSalary = 1000,
                    IsDeleted = false,
                },
            }.AsQueryable();
        }
    }
}
