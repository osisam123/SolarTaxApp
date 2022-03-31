using System;
using System.Collections.Generic;
using System.Text;

namespace SolarTaxApp.Shared.Models
{
    public class ClassificationList
    {
        public string ClassificationId { get; set; }
        public string CategoryId { get; set; }
        public string Category { get; set; }
        public string Hscode { get; set; }
        public string Solarmodularcapacity { get; set; }
        public string Description { get; set; }
        public string Illustrationurl { get; set; }
    }
}
