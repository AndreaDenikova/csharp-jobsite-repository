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
        private readonly IDeletableEntityRepository<JobPostingCategory> jobPostingCategoryRepository;

        public CategoriesService(IDeletableEntityRepository<JobPostingCategory> repository, IDeletableEntityRepository<JobPostingCategory> jobPostingCategoryRepository)
        {
            this.repository = repository;
            this.jobPostingCategoryRepository = jobPostingCategoryRepository;
        }

        public IEnumerable<T> GetCategories<T>()
        {
            return this.repository.All().To<T>().ToList();
        }

        public ICollection<string> GetCategoriesNames()
        {
            var categories = this.jobPostingCategoryRepository.All().OrderBy(c => c.Name);

            var listOfNames = new List<string>();

            foreach (var category in categories)
            {
                var nameOfCategory = category.Name;
                listOfNames.Add(nameOfCategory);
            }

            return listOfNames;
        }

        public string GetCategoryId(string categoryName)
        {
            var category = this.jobPostingCategoryRepository.All().Where(c => c.Name == categoryName).FirstOrDefault();
            var categoryId = category.Id;

            return categoryId;
        }
    }
}
