using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class Category
    {
        public string Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string CategoryDescription { get; set; }
        public string Imageurl { get; set; }

        public static implicit operator Category(CategoryTb category)
        {
            return new Category
            {
                Categoryid = category.CategoryId,
                Categoryname = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                Imageurl = category.ImageUrl
            };
        }

        public static implicit operator CategoryTb(Category category)
        {
            return new CategoryTb
            {
                CategoryId = category.Categoryid,
                CategoryName = category.Categoryname,
                CategoryDescription = category.CategoryDescription,
                ImageUrl = category.Imageurl
            };
        }
        
    }
}
