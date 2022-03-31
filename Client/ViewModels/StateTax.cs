using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class StateTax
    {
        public string Id { get; set; }
        public string Classificationid { get; set; }
        public string CategoryName { get; set; }
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

        public static implicit operator StateTax(StateTaxTreatement stateTaxTreatement)
        {
            return new StateTax
            {
                Id = stateTaxTreatement.Id,
                CategoryName = stateTaxTreatement.CategoryName,
                Classificationid = stateTaxTreatement.Classificationid,
                SolarModularCapacity = stateTaxTreatement.SolarModularCapacity,
                Description = stateTaxTreatement.Description,
                Illustration = stateTaxTreatement.Illustration,
                ImageUrl = stateTaxTreatement.ImageUrl,
                HSCode = stateTaxTreatement.HSCode,
                Taxid = stateTaxTreatement.Taxid,
                TaxName = stateTaxTreatement.TaxName,
                TaxCode = stateTaxTreatement.TaxCode,
                Stateid = stateTaxTreatement.Stateid,
                StateCode = stateTaxTreatement.StateCode,
                StateName = stateTaxTreatement.StateName,
                Taxpercentage = stateTaxTreatement.Taxpercentage
            };
        }

        public static implicit operator StateTaxTreatement(StateTax stateTax)
        {
            return new StateTaxTreatement
            {
                Id = stateTax.Id,
                CategoryName = stateTax.CategoryName,
                Classificationid = stateTax.Classificationid,
                SolarModularCapacity = stateTax.SolarModularCapacity,
                Description = stateTax.Description,
                Illustration = stateTax.Illustration,
                ImageUrl = stateTax.ImageUrl,
                HSCode = stateTax.HSCode,
                Taxid = stateTax.Taxid,
                TaxName = stateTax.TaxName,
                TaxCode = stateTax.TaxCode,
                Stateid = stateTax.Stateid,
                StateCode = stateTax.StateCode,
                StateName = stateTax.StateName,
                Taxpercentage = stateTax.Taxpercentage
            };
        }
    }
}
