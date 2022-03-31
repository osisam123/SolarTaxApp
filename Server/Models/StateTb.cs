using System;
using System.Collections.Generic;

namespace SolarTaxApp.Server.Models
{
    public partial class StateTb
    {
        public string StateId { get; set; }
        public string Code { get; set; }
        public string StateName { get; set; }
        public string Flag { get; set; }
    }
}
