using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface IClassificationViewModel
    {
        public List<Classification> Classifications { get; set; }
        public Classification Classification { get; set; }

        Task GetClassifications();
        Task GetClassification(string id);
        Task GetClassificationSearch(string search);
        Task<bool> InsertClassification();
        Task<bool> UpdateClassification();
        Task DeleteClassification();
    }
}
