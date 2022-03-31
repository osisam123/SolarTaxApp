using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface ITaxTreatementViewModel
    {
        public List<TaxTreatement> TaxTreatements { get; set; }
        public TaxTreatement TaxTreatement_ { get; set; }

        Task GetTaxTreatements();
        Task GetTaxTreatement(string id);
        Task GetTaxTreatementSearch(string search);
        Task<bool> InsertTaxTreatement();
        Task<bool> UpdateTaxTreatement();
        Task DeleteTaxTreatement();
    }
}
