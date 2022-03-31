using System;
using System.Collections.Generic;

namespace SolarTaxApp.Server.Models
{
    public partial class CategoryTb
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
