namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> cityReposirory;

        public CitiesService(IDeletableEntityRepository<City> cityReposirory)
        {
            this.cityReposirory = cityReposirory;
        }

        public ICollection<string> GetCities()
        {
            var listOfNames = new List<string>();
            var cities = this.cityReposirory.All().OrderBy(c => c.Name);

            foreach (var city in cities)
            {
                var cityName = city.Name;
                listOfNames.Add(cityName);
            }

            return listOfNames;
        }

        public string GetCityId(string cityName)
        {
            var city = this.cityReposirory.All().Where(c => c.Name == cityName).FirstOrDefault();
            var cityId = city.Id;

            return cityId;
        }
    }
}
