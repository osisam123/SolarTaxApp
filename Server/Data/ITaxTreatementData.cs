using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface ITaxTreatementData
    {
        List<TaxTreatementTb> GetTaxTreatement();
        TaxTreatementTb GetTaxTreatement(string id);
        TaxTreatementTb AddTaxTreatement(TaxTreatementTb taxTreatement);
        TaxTreatementTb EditTaxTreatement(TaxTreatementTb taxTreatement);
        void DeleteTaxTreatement(TaxTreatementTb taxTreatement);
    }
}
