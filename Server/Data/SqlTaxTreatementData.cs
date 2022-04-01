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
                existingTaxTreatement.Classificationid = taxTreatement.Classificationid;
                existingTaxTreatement.Taxid = taxTreatement.Taxid;
                existingTaxTreatement.Stateid = taxTreatement.Stateid;
                existingTaxTreatement.Taxpercentage = taxTreatement.Taxpercentage;
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
