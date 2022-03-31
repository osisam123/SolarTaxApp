using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class TaxTreatementViewModel : ITaxTreatementViewModel
    {
        public List<TaxTreatement> TaxTreatements { get; set; }
        public TaxTreatement TaxTreatement_ { get; set; }

        private HttpClient _httpClient;

        public TaxTreatementViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public TaxTreatementViewModel()
        {

        }
        public async Task DeleteTaxTreatement()
        {
            TaxTreatement taxTreatement = this.TaxTreatement_;
            await _httpClient.DeleteAsync("api/taxtreatement/" + taxTreatement.Id);
        }

        public async Task GetTaxTreatement(string id)
        {
            TaxTreatement taxTreatement = await _httpClient.GetFromJsonAsync<TaxTreatement>("api/taxtreatement/" + id);
            LoadSingleObject(taxTreatement);
        }

        public async Task GetTaxTreatements()
        {
            List<TaxTreatement> taxTreatement = await _httpClient.GetFromJsonAsync<List<TaxTreatement>>("api/taxtreatement");
            LoadCurrentObject(taxTreatement);
        }

        public async Task GetTaxTreatementSearch(string search)
        {
            List<TaxTreatement> taxTreatement = await _httpClient.GetFromJsonAsync<List<TaxTreatement>>("api/taxtreatement/" + search);
            LoadCurrentObject(taxTreatement);
        }

        public async Task<bool> InsertTaxTreatement()
        {
            TaxTreatement taxTreatement = this.TaxTreatement_;
            var resp = await _httpClient.PostAsJsonAsync<TaxTreatement>("api/taxtreatement", taxTreatement);
            if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateTaxTreatement()
        {
            TaxTreatement taxTreatement = this.TaxTreatement_;
            var resp = await _httpClient.PutAsJsonAsync<TaxTreatement>("api/taxtreatement/" + taxTreatement.Id, taxTreatement);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        private void LoadCurrentObject(List<TaxTreatement> taxTreatements)
        {
            this.TaxTreatements = new List<TaxTreatement>();
            foreach (TaxTreatement taxTreatement in taxTreatements)
            {
                this.TaxTreatements.Add(taxTreatement);
            }

        }

        private void LoadSingleObject(TaxTreatement taxTreatement)
        {
            this.TaxTreatement_ = new TaxTreatement();
            this.TaxTreatement_ = taxTreatement;
        }
    }
}
