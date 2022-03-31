using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlTaxTreatementData : ITaxTreatementData
    {
        SolarTaxationDBContext _context;
        public SqlTaxTreatementData(SolarTaxationDBContext context)
        {
            _context = context;
        }
        public TaxTreatementTb AddTaxTreatement(TaxTreatementTb taxTreatement)
        {
            taxTreatement.Id = Guid.NewGuid().ToString();
            _context.TaxTreatementTbs.Add(taxTreatement);
            _context.SaveChanges();
            return taxTreatement;
        }

        public void DeleteTaxTreatement(TaxTreatementTb taxTreatement)
        {
            _context.TaxTreatementTbs.Remove(taxTreatement);
            _context.SaveChanges();
        }

        public TaxTreatementTb EditTaxTreatement(TaxTreatementTb taxTreatement)
        {
            var existingTaxTreatement = _context.TaxTreatementTbs.Find(taxTreatement.Id);
            if (existingTaxTreatement != null)
            {
                existingTaxTreatement.ClassificationId = taxTreatement.ClassificationId;
                existingTaxTreatement.TaxId = taxTreatement.TaxId;
                existingTaxTreatement.StateId = taxTreatement.StateId;
                existingTaxTreatement.TaxPercentage = taxTreatement.TaxPercentage;
                _context.TaxTreatementTbs.Update(existingTaxTreatement);
                _context.SaveChanges();
            }
            return taxTreatement;
        }

        public List<TaxTreatementTb> GetTaxTreatement()
        {
            return _context.TaxTreatementTbs.ToList();

        }

        public TaxTreatementTb GetTaxTreatement(string id)
        {
            var taxTreatement = _context.TaxTreatementTbs.Find(id);
            return taxTreatement;
        }
    }
}
