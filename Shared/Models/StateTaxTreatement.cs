using System;
using System.Collections.Generic;
using System.Text;

namespace SolarTaxApp.Shared.Models
{
    public class StateTaxTreatement
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Classificationid { get; set; }        
        public string SolarModularCapacity { get; set; }
        public string Description { get; set; }
        public string Illustration { get; set; }
        public string ImageUrl { get; set; }
        public string HSCode { get; set; }
        public string Taxid { get; set; }
        public string TaxName { get; set; }
        public string TaxCode { get; set; }
        public string Stateid { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string Taxpercentage { get; set; }
    }
}
