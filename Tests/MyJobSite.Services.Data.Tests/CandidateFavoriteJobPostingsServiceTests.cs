using Microsoft.EntityFrameworkCore;
using Moq;
using MyJobSite.Data;
using MyJobSite.Data.Common.Repositories;
using MyJobSite.Data.Models;
using MyJobSite.Data.Repositories;
using MyJobSite.Services.Mapping;
using MyJobSite.Web.ViewModels.ViewModels.JobPosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyJobSite.Services.Data.Tests
{
    public class CandidateFavoriteJobPostingsServiceTests
    {
        [Fact]
        public async Task AddNewCandidatesFavoriteJobPostingTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<FavoriteJobPosting>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetFavoritesData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CandidateFavoriteJobPostingsService(repository);

            await service.AddNewCandidatesFavoriteJobPosting("8", "9");

            var favoritesCount = repository.All().ToList().Count;

            Assert.Equal(4, favoritesCount);
        }

        [Fact]
        public async Task DeleteJobPostingFromFavoritesTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<FavoriteJobPosting>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetFavoritesData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var service = new CandidateFavoriteJobPostingsService(repository);

            await service.DeleteJobPostingFromFavorites("1", "2");

            var favoritesCount = repository.All().ToList().Count;

            Assert.Equal(2, favoritesCount);
        }

        [Fact]
        public void CheckIfFavoriteJobPostingAlreadyExistsTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<FavoriteJobPosting>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetFavoritesData());

            var service = new CandidateFavoriteJobPostingsService(mockRepository.Object);

            var favoritesCount = service.CheckIfFavoriteJobPostingAlreadyExists("1", "2");

            Assert.True(favoritesCount);
        }

        [Fact]
        public void GetCategoriesTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<FavoriteJobPosting>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetFavoritesData());

            var service = new CandidateFavoriteJobPostingsService(mockRepository.Object);

            var categories = service.GetAllFavoriteJobPostingsIds("1");

            Assert.Single(categories);
        }

        private IQueryable<FavoriteJobPosting> GetFavoritesData()
        {
            return new List<FavoriteJobPosting>
            {
                new FavoriteJobPosting
                {
                    UserId = "1",
                    JobPostingId = "2",
                },
                new FavoriteJobPosting
                {
                    UserId = "2",
                    JobPostingId = "3",
                },
                new FavoriteJobPosting
                {
                    UserId = "4",
                    JobPostingId = "5",
                },
            }.AsQueryable();
        }
    }
}
