using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class Tax
    {
        public string Taxid { get; set; }
        public string Taxcode { get; set; }
        public string TaxName { get; set; }

        public static implicit operator Tax(TaxTb tax)
        {
            return new Tax
            {
                Taxid = tax.TaxId,
                Taxcode = tax.TaxCode,
                TaxName = tax.TaxName
            };
        }

        public static implicit operator TaxTb(Tax tax)
        {
            return new TaxTb
            {
                TaxId = tax.Taxid,
                TaxCode = tax.Taxcode,
                TaxName = tax.TaxName
            };
        }
    }
}
