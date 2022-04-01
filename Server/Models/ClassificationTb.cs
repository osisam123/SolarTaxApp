using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolarTaxApp.Server.Models
{
    public partial class ClassificationTb
    {
        public string Classificationid { get; set; }
        public string Categoryid { get; set; }
        public string Hscode { get; set; }
        public string Solarmodularcapacity { get; set; }
        public string Description { get; set; }
        public string Illustrationurl { get; set; }
    }
}
