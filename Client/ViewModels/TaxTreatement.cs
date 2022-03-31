using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class TaxTreatement
    {
        public string Id { get; set; }
        public string Classificationid { get; set; }
        public string Taxid { get; set; }
        public string Stateid { get; set; }
        public string Taxpercentage { get; set; }

        public static implicit operator TaxTreatement(TaxTreatementTb taxTreatement)
        {
            return new TaxTreatement
            {
                Id = taxTreatement.Id,
                Taxid = taxTreatement.TaxId,
                Classificationid = taxTreatement.ClassificationId,
                Stateid = taxTreatement.StateId,
                Taxpercentage = taxTreatement.TaxPercentage
            };
        }

        public static implicit operator TaxTreatementTb(TaxTreatement taxTreatement)
        {
            return new TaxTreatementTb
            {
                Id = taxTreatement.Id,
                TaxId = taxTreatement.Taxid,
                ClassificationId = taxTreatement.Classificationid,
                StateId = taxTreatement.Stateid,
                TaxPercentage = taxTreatement.Taxpercentage
            };
        }
    }
}
