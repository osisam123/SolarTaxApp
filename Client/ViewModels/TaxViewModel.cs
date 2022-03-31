using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class TaxViewModel : ITaxViewModel
    {
        public List<Tax> Taxes { get; set; }
        public Tax Tax_ { get; set; }

        private HttpClient _httpClient;
        public TaxViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public TaxViewModel()
        {

        }
        public async Task DeleteTax()
        {
            Tax tax = this.Tax_;
            await _httpClient.DeleteAsync("api/tax/" + tax.Taxid);
        }

        public async Task GetTax(string id)
        {
            Tax tax = await _httpClient.GetFromJsonAsync<Tax>("api/tax/" + id);
            LoadSingleObject(tax);
        }

        public async Task GetTaxes()
        {
            List<Tax> tax = await _httpClient.GetFromJsonAsync<List<Tax>>("api/tax");
            LoadCurrentObject(tax);
        }

        public async Task GetTaxSearch(string search)
        {
            List<Tax> tax = await _httpClient.GetFromJsonAsync<List<Tax>>("api/tax/" + search);
            LoadCurrentObject(tax);
        }

        public async Task<bool> InsertTax()
        {
            Tax tax = this.Tax_;
           var resp = await _httpClient.PostAsJsonAsync<Tax>("api/tax", tax);
            if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateTax()
        {
            Tax tax = this.Tax_;
            var resp = await _httpClient.PutAsJsonAsync<Tax>("api/tax/" + tax.Taxid, tax);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
        private void LoadCurrentObject(List<Tax> taxes)
        {
            this.Taxes = new List<Tax>();
            foreach (Tax tax in taxes)
            {
                this.Taxes.Add(tax);
            }

        }

        private void LoadSingleObject(Tax tax)
        {
            this.Tax_ = new Tax();
            this.Tax_ = tax;
        }
    }
}
