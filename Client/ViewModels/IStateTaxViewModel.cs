using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public interface IStateTaxViewModel
    {
        public List<StateTax> StateTaxes { get; set; }
        public StateTax StateTax { get; set; }

        Task GetStateTaxes();
        Task GetStateTax(string id);
        Task GetStateTaxSearch(string search);
        Task GetMultiStateTaxSearch(MultiSearch search);
    }
}
