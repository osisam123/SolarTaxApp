using System;
using System.Collections.Generic;

namespace SolarTaxApp.Server.Models
{
    public partial class ViewTaxTreatement
    {
        public string Id { get; set; }
        public string ClassificationId { get; set; }
        public string CategoryName { get; set; }
        public string SolarModularCapacity { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string HsCode { get; set; }
        public string IllustrationUrl { get; set; }
        public string TaxId { get; set; }
        public string TaxName { get; set; }
        public string TaxCode { get; set; }
        public string StateId { get; set; }
        public string Code { get; set; }
        public string StateName { get; set; }
        public string TaxPercentage { get; set; }
    }
}
