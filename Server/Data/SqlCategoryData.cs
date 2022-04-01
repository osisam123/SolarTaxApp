using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlCategoryData : ICategoryData
    {
        SolarTaxationDBContext _context;
        public SqlCategoryData(SolarTaxationDBContext context)
        {
            _context = context;
        }
        public CategoryTb AddCategory(CategoryTb category)
        {
            category.Categoryid = Guid.NewGuid().ToString();
            _context.CategoryTbs.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(CategoryTb category)
        {
            _context.CategoryTbs.Remove(category);
            _context.SaveChanges();
        }

        public CategoryTb EditCategory(CategoryTb category)
        {
            var existingCategory = _context.CategoryTbs.Find(category.Categoryid);
            if (existingCategory != null)
            {
                existingCategory.Categoryname = category.Categoryname;
                existingCategory.CategoryDescription = category.CategoryDescription;
                existingCategory.Imageurl = category.Imageurl;                
                _context.CategoryTbs.Update(existingCategory);
                _context.SaveChanges();
            }
            return category;
        }

        public List<CategoryTb> GetCategory()
        {
            return _context.CategoryTbs.ToList();
        }

        public CategoryTb GetCategory(string id)
        {
            var category = _context.CategoryTbs.Find(id);
            return category;
        }
    }
}
