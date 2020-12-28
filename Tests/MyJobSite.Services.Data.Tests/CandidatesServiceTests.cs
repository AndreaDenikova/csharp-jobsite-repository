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
    using Xunit;

    public class CandidatesServiceTests
    {
        [Fact]
        public async Task CreateNewCandidateForJobPostingAsyncTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Candidate>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCandidatesData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CandidatesService(repository);

            await service.CreateNewCandidateForJobPostingAsync("8", "9");

            var candidatesCount = repository.All().ToList().Count;

            Assert.Equal(4, candidatesCount);
        }

        [Fact]
        public void CheckIfCandidateAlreadyAppliedTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<Candidate>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCandidatesData());

            var service = new CandidatesService(mockRepository.Object);

            var check = service.CheckIfCandidateAlreadyApplied("1", "2");

            Assert.True(check);
        }

        [Fact]
        public void GetAllUsersIdOfJobPostingTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<Candidate>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCandidatesData());

            var service = new CandidatesService(mockRepository.Object);

            var check = service.GetAllUsersIdOfJobPosting("2");

            var listOfUsers = new List<string> { "1" };

            Assert.Equal(listOfUsers, check);
        }

        [Fact]
        public void GetAllJobPostingsIdsTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<Candidate>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCandidatesData());

            var service = new CandidatesService(mockRepository.Object);

            var check = service.GetAllJobPostingsIds("1");

            var listOfJobPostings = new List<string> { "2" };

            Assert.Equal(listOfJobPostings, check);
        }

        [Fact]
        public async Task MarkAllApplyingsAsDeleted()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Candidate>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetCandidatesData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CandidatesService(repository);

            await service.MarkAllApplyingsAsDeleted("1");

            var user = repository.AllWithDeleted().Where(x => x.UserId == "1").FirstOrDefault();

            Assert.True(user.IsDeleted);
        }

        private IQueryable<Candidate> GetCandidatesData()
        {
            return new List<Candidate>
            {
                new Candidate
                {
                    UserId = "1",
                    JobPostingId = "2",
                },
                new Candidate
                {
                    UserId = "2",
                    JobPostingId = "3",
                },
                new Candidate
                {
                    UserId = "4",
                    JobPostingId = "5",
                },
            }.AsQueryable();
        }
    }
}
