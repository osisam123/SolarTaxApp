using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface ICategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }

        Task GetCategories();
        Task GetCategory(string id);
        Task GetCategorySearch(string search);
        Task<bool> InsertCategory();
        Task<bool> UpdateCategory();
        Task DeleteCategory();


    }
}
