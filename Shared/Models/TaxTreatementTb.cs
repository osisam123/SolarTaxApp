using System;
using System.Collections.Generic;

namespace SolarTaxApp.Shared.Models
{
    public partial class TaxTreatementTb
    {
        public string Id { get; set; }
        public string ClassificationId { get; set; }
        public string TaxId { get; set; }
        public string StateId { get; set; }
        public string TaxPercentage { get; set; }
    }
}
