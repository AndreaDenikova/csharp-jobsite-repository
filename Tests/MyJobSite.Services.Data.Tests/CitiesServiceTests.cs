namespace MyJobSite.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using Xunit;

    public class CitiesServiceTests
    {
        [Fact]
        public void GetCityIdTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<City>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCityData());

            var service = new CitiesService(mockRepository.Object);

            var cityId = service.GetCityId("Sofia");

            Assert.Equal("1", cityId);
        }

        [Fact]
        public void GetCitiesTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<City>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetCityData());

            var service = new CitiesService(mockRepository.Object);

            var cityNames = service.GetCities();

            var result = new List<string> { "Sofia", "Plovdiv", "Tokyo" }.OrderBy(n => n);

            Assert.Equal(result, cityNames);
        }

        private IQueryable<City> GetCityData()
        {
            return new List<City>
            {
                new City
                {
                    Id = "1",
                    Name = "Sofia",
                },
                new City
                {
                    Id = "2",
                    Name = "Plovdiv",
                },
                new City
                {
                    Id = "3",
                    Name = "Tokyo",
                },
            }.AsQueryable();
        }
    }
}
