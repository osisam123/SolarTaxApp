using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface IStateViewModel
    {
        public List<Country> Countries { get; set; }
        public Country Country_ { get; set; }

        Task GetCountries();
        Task GetCountry(string id);
        Task GetCountrySearch(string search);
        Task<bool> InsertCountry();
        Task<bool> UpdateCountry();
        Task DeleteCountry();
    }
}
