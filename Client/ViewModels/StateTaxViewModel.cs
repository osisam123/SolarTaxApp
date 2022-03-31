using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class StateTaxViewModel : IStateTaxViewModel
    {
        public List<StateTax> StateTaxes { get; set; }
        public StateTax StateTax { get; set; }

        private HttpClient _httpClient;

        public StateTaxViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public StateTaxViewModel()
        {

        }
        public async Task GetStateTax(string id)
        {
            StateTax stateTax = await _httpClient.GetFromJsonAsync<StateTax>("statetax/onetax/" + id);
            LoadSingleObject(stateTax);
        }

        public async Task GetStateTaxes()
        {
            List<StateTax> stateTaxes = await _httpClient.GetFromJsonAsync<List<StateTax>>("statetax/alltax");
            LoadCurrentObject(stateTaxes);
        }

        public async Task GetStateTaxSearch(string search)
        {
            List<StateTax> stateTaxes = await _httpClient.GetFromJsonAsync<List<StateTax>>("statetax/gettax/" + search);
            LoadCurrentObject(stateTaxes);
        }
        public async Task GetMultiStateTaxSearch(MultiSearch search)
        {
            List<StateTax> stateTaxes = await _httpClient.GetFromJsonAsync<List<StateTax>>("statetax/getmultitax/" + search.Country +"&"+ search.TaxType + "&" + search.HsCode);
            LoadCurrentObject(stateTaxes);
        }

        private void LoadCurrentObject(List<StateTax> stateTaxes)
        {
            this.StateTaxes = new List<StateTax>();
            foreach (StateTax stateTax in stateTaxes)
            {
                this.StateTaxes.Add(stateTax);
            }

        }

        private void LoadSingleObject(StateTax stateTax)
        {
            this.StateTax = new StateTax();
            this.StateTax = stateTax;
        }
    }
}
