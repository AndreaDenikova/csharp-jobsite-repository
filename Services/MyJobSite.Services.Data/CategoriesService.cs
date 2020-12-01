namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<JobPostingCategory> repository;

        public CategoriesService(IDeletableEntityRepository<JobPostingCategory> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetCategories<T>()
        {
            return this.repository.All().To<T>().ToList();
        }
    }
}
