using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface ITaxViewModel
    {
        public List<Tax> Taxes { get; set; }
        public Tax Tax_ { get; set; }

        Task GetTaxes();
        Task GetTax(string id);
        Task GetTaxSearch(string search);
        Task<bool> InsertTax();
        Task<bool> UpdateTax();
        Task DeleteTax();
    }
}
