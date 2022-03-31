using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class CategoryViewModel : ICategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        
        private HttpClient _httpClient;

        public CategoryViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public CategoryViewModel()
        {

        }
        public async Task GetCategories()
        {
            List<Category> categories = await _httpClient.GetFromJsonAsync<List<Category>>("api/category");
            LoadCurrentObject(categories);
        }

        public async Task GetCategory(string id)
        {
            Category category = await _httpClient.GetFromJsonAsync<Category>("api/category/" + id);
            LoadSingleObject(category);
        }

        public async Task GetCategorySearch(string search)
        {
            List<Category> categories = await _httpClient.GetFromJsonAsync<List<Category>>("api/category/" + search);
            LoadCurrentObject(categories);
        }

        public async Task<bool> InsertCategory()
        {
            Category category = this.Category;
            var resp = await _httpClient.PostAsJsonAsync<Category>("api/category", category);
            if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateCategory()
        {
            Category category = this.Category;
            var resp = await _httpClient.PutAsJsonAsync<Category>("api/category/" + Category.Categoryid, category);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task DeleteCategory()
        {
            Category category = this.Category;
            await _httpClient.DeleteAsync("api/category/" + category.Categoryid);
        }

        private void LoadCurrentObject(List<Category> categories)
        {
            this.Categories = new List<Category>();
            foreach (Category category in categories)
            {
                this.Categories.Add(category);
            }

        }

        private void LoadSingleObject(Category category)
        {
            this.Category = new Category();
            this.Category = category;
        }

       
    }
}
