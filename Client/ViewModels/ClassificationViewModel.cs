using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class ClassificationViewModel : IClassificationViewModel
    {
        public List<Classification> Classifications { get; set; }
        public Classification Classification { get; set; }

        private HttpClient _httpClient;

        public ClassificationViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public ClassificationViewModel()
        {

        }
        public async Task GetClassification(string id)
        {
            Classification Classification = await _httpClient.GetFromJsonAsync<Classification>("api/classification/" + id);
            LoadSingleObject(Classification);
        }

        public async Task GetClassifications()
        {
            List<Classification> Classifications = await _httpClient.GetFromJsonAsync<List<Classification>>("api/classification");
            LoadCurrentObject(Classifications);
        }

        public async Task GetClassificationSearch(string search)
        {
            List<Classification> Classifications = await _httpClient.GetFromJsonAsync<List<Classification>>("api/classification/" + search);
            LoadCurrentObject(Classifications);
        }

        public async Task<bool> InsertClassification()
        {
            Classification classification = this.Classification;
            var resp = await _httpClient.PostAsJsonAsync<Classification>("api/classification", classification);
            if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateClassification()
        {
            Classification classification = this.Classification;
            var resp = await _httpClient.PutAsJsonAsync<Classification>("api/classification/" + classification.Classificationid, classification);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
        public async Task DeleteClassification()
        {
            Classification classification = this.Classification;
            await _httpClient.DeleteAsync("api/classification/" + classification.Classificationid);
        }

        private void LoadCurrentObject(List<Classification> classifications)
        {
            this.Classifications = new List<Classification>();
            foreach (Classification classification in classifications)
            {
                this.Classifications.Add(classification);
            }

        }

        private void LoadSingleObject(Classification classification)
        {
            this.Classification = new Classification();
            this.Classification = classification;
        }

       
    }
}
