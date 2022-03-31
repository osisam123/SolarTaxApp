using System;
using System.Collections.Generic;
using System.Text;

namespace SolarTaxApp.Shared.Models
{
    public class MultiSearch
    {
        public string Country { get; set; }
        public string TaxType { get; set; }
        public string HsCode { get; set; }
    }
}
