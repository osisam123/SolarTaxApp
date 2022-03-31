using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class ClassificationListViewModel : IClassificationListViewModel
    {       
        public List<ActualClassification> ActualClassifications { get; set; }
        public ActualClassification ActualClassification { get; set; }

        private HttpClient _httpClient;
        public ClassificationListViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public ClassificationListViewModel()
        {

        }

        public async Task GetActualClassifications()
        {
            List<ActualClassification> Classifications = await _httpClient.GetFromJsonAsync<List<ActualClassification>>("api/classification");
            LoadCurrentObject(Classifications);
        }
        public async Task DeleteClassification()
        {
            ActualClassification classification = this.ActualClassification;
            await _httpClient.DeleteAsync("api/classification/" + classification.Classificationid);
        }
        private void LoadCurrentObject(List<ActualClassification> classifications)
        {
            this.ActualClassifications = new List<ActualClassification>();
            foreach (ActualClassification classification in classifications)
            {
                this.ActualClassifications.Add(classification);
            }
        }
        private void LoadSingleObject(ActualClassification classification)
        {
            this.ActualClassification = new ActualClassification();
            this.ActualClassification = classification;
        }
    }
}
