using System;
using System.Collections.Generic;

namespace SolarTaxApp.Server.Models
{
    public partial class ClassificationTb
    {
        public string ClassificationId { get; set; }
        public string CategoryId { get; set; }
        public string HsCode { get; set; }
        public string SolarModularCapacity { get; set; }
        public string Description { get; set; }
        public string IllustrationUrl { get; set; }
    }
}
