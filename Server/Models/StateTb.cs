using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SolarTaxApp.Server.Models
{
    public partial class StateTb
    {
        public string Stateid { get; set; }
        public string Code { get; set; }
        public string Statename { get; set; }
        public string Flag { get; set; }
    }
}
