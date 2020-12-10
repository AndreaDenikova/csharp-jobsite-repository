namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICategoriesService
    {
        IEnumerable<T> GetCategories<T>();

        public string GetCategoryId(string categoryName);
    }
}
