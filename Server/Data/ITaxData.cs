using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface ITaxData
    {
        List<TaxTb> GetTax();
        TaxTb GetTax(string id);
        TaxTb AddTax(TaxTb tax);
        TaxTb EditTax(TaxTb tax);
        void DeleteTax(TaxTb tax);
    }
}
