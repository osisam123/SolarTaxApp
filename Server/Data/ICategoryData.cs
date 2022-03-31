using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface ICategoryData
    {
        List<CategoryTb> GetCategory();
        CategoryTb GetCategory(string id);
        CategoryTb AddCategory(CategoryTb category);
        CategoryTb EditCategory(CategoryTb category);
        void DeleteCategory(CategoryTb category);
    }
}
