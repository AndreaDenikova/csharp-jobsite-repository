namespace MyJobSite.Services.Data
{
    using MyJobSite.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICitiesService
    {
        string GetCityId(string cityName);

        ICollection<string> GetCities();
    }
}
