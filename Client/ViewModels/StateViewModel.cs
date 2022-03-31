using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class StateViewModel : IStateViewModel
    {
        public List<Country> Countries { get; set; }
        public Country Country_ { get; set; }

        private HttpClient _httpClient;

        public StateViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public StateViewModel()
        {

        }
        public async Task DeleteCountry()
        {
            Country country = this.Country_;
            await _httpClient.DeleteAsync("api/state/" + country.Stateid);
        }

        public async Task GetCountries()
        {
            List<Country> country = await _httpClient.GetFromJsonAsync<List<Country>>("api/state");
            LoadCurrentObject(country);
        }

        public async Task GetCountry(string id)
        {
            Country country = await _httpClient.GetFromJsonAsync<Country>("api/state/" + id);
            LoadSingleObject(country);
        }

        public async Task GetCountrySearch(string search)
        {
            List<Country> countries = await _httpClient.GetFromJsonAsync<List<Country>>("api/state/" + search);
            LoadCurrentObject(countries);
        }

        public async Task<bool> InsertCountry()
        {
            Country country = this.Country_;
            var resp = await _httpClient.PostAsJsonAsync<Country>("api/state", country);
            if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateCountry()
        {
            Country country = this.Country_;
            var resp = await _httpClient.PutAsJsonAsync<Country>("api/state/" + country.Stateid, country);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        private void LoadCurrentObject(List<Country> countries)
        {
            this.Countries = new List<Country>();
            foreach (Country country in countries)
            {
                this.Countries.Add(country);
            }

        }

        private void LoadSingleObject(Country country)
        {
            this.Country_ = new Country();
            this.Country_ = country;
        }
    }
}
