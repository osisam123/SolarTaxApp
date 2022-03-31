using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface IStateTaxData
    {
        List<StateTaxTreatement> GetStateTax();
        StateTaxTreatement GetStateTax(string id);
        List<StateTaxTreatement> GetStateTaxSearch(string tax);
        List<StateTaxTreatement> GetMultiStateTaxSearch(string tax);
    }
}
