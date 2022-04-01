using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolarTaxApp.Server.Models
{
    public partial class CategoryTb
    {
        public string Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string CategoryDescription { get; set; }
        public string Imageurl { get; set; }
    }
}
