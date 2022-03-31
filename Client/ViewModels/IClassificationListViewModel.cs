using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface IClassificationListViewModel
    {
        public List<ActualClassification> ActualClassifications { get; set; }
        public ActualClassification ActualClassification { get; set; }

        Task GetActualClassifications();
        Task DeleteClassification();

    }
}
