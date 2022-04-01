using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolarTaxApp.Server.Models
{
    public partial class TaxTb
    {
        public string Taxid { get; set; }
        public string Taxcode { get; set; }
        public string TaxName { get; set; }
    }
}
