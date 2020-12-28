namespace MyJobSite.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;
    using MyJobSite.Web.ViewModels.ViewModels.Category;
    using Xunit;

    public class CategoriesServiceTests
    {
        [Fact]
        public void GetCategoryIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPostingCategory>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCategoryData());

            var service = new CategoriesService(mockRepository.Object, mockRepository.Object);

            var categoryId = service.GetCategoryId("Game");

            Assert.Equal("2", categoryId);
        }

        [Fact]
        public void GetCategoriesNamesTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPostingCategory>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCategoryData());

            var service = new CategoriesService(mockRepository.Object, mockRepository.Object);

            var categoryNames = service.GetCategoriesNames();

            var result = new List<string> { "Web", "Game", "Mobile" }.OrderBy(n => n);

            Assert.Equal(result, categoryNames);
        }

        [Fact]
        public void GetCategoriesTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<JobPostingCategory>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCategoryData());

            var service = new CategoriesService(mockRepository.Object, mockRepository.Object);

            AutoMapperConfig.RegisterMappings(typeof(CategoryViewModel).Assembly);

            var categories = service.GetCategories<CategoryViewModel>();

            Assert.Equal(3, categories.Count());
        }

        private IQueryable<JobPostingCategory> GetCategoryData()
        {
            return new List<JobPostingCategory>
            {
                new JobPostingCategory
                {
                    Id = "1",
                    Name = "Web",
                },
                new JobPostingCategory
                {
                    Id = "2",
                    Name = "Game",
                },
                new JobPostingCategory
                {
                    Id = "3",
                    Name = "Mobile",
                },
            }.AsQueryable();
        }
    }
}
