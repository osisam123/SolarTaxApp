using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlTaxData : ITaxData
    {
        SolarTaxationDBContext _context;
        public SqlTaxData(SolarTaxationDBContext context)
        {
            _context = context;
        }
        public TaxTb AddTax(TaxTb tax)
        {
            tax.TaxId = Guid.NewGuid().ToString();
            _context.TaxTbs.Add(tax);
            _context.SaveChanges();
            return tax;
        }

        public void DeleteTax(TaxTb tax)
        {
            _context.TaxTbs.Remove(tax);
            _context.SaveChanges();
        }

        public TaxTb EditTax(TaxTb tax)
        {
            var existingTax = _context.TaxTbs.Find(tax.TaxId);
            if (existingTax != null)
            {
                existingTax.TaxCode = tax.TaxCode;
                existingTax.TaxName = tax.TaxName;
                _context.TaxTbs.Update(existingTax);
                _context.SaveChanges();
            }
            return tax;
        }

        public List<TaxTb> GetTax()
        {
            return _context.TaxTbs.ToList();
        }

        public TaxTb GetTax(string id)
        {
            var tax = _context.TaxTbs.Find(id);
            return tax;
        }
    }
}
