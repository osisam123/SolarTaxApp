using SolarTaxApp.Server.Models;
using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlStateTaxData : IStateTaxData
    {
        SolarTaxationDBContext _context;
        public SqlStateTaxData(SolarTaxationDBContext context)
        {
            this._context = context;
        }
        public List<StateTaxTreatement> GetStateTax()
        {
            var stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.ClassificationId equals b.ClassificationId
                           join e in _context.CategoryTbs on b.CategoryId equals e.CategoryId
                           join c in _context.TaxTbs on a.TaxId equals c.TaxId
                           join d in _context.StateTbs on a.StateId equals d.StateId
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.CategoryName,
                               Classificationid = a.ClassificationId,
                               SolarModularCapacity = b.SolarModularCapacity,
                               Description = b.Description,
                               Illustration = e.ImageUrl,
                               ImageUrl = b.IllustrationUrl,
                               HSCode = b.HsCode,
                               Taxid = c.TaxId,
                               TaxName = c.TaxName,
                               TaxCode = c.TaxCode,
                               Stateid = a.StateId,
                               StateCode = d.Code,
                               StateName = d.StateName,
                               Taxpercentage = a.TaxPercentage
                           };
            return stateTax.ToList();
        }

        public StateTaxTreatement GetStateTax(string id)
        {
            var stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.ClassificationId equals b.ClassificationId
                           join e in _context.CategoryTbs on b.CategoryId equals e.CategoryId
                           join c in _context.TaxTbs on a.TaxId equals c.TaxId
                           join d in _context.StateTbs on a.StateId equals d.StateId
                           where a.Id == id
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.CategoryName,
                               Classificationid = a.ClassificationId,
                               SolarModularCapacity = b.SolarModularCapacity,
                               Description = b.Description,
                               Illustration = e.ImageUrl,
                               ImageUrl = b.IllustrationUrl,
                               HSCode = b.HsCode,
                               Taxid = c.TaxId,
                               TaxName = c.TaxName,
                               TaxCode = c.TaxCode,
                               Stateid = a.StateId,
                               StateCode = d.Code,
                               StateName = d.StateName,
                               Taxpercentage = a.TaxPercentage
                           };
            return stateTax.FirstOrDefault();
        }

        public List<StateTaxTreatement> GetStateTaxSearch(string tax)
        {
            var stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.ClassificationId equals b.ClassificationId
                           join e in _context.CategoryTbs on b.CategoryId equals e.CategoryId
                           join c in _context.TaxTbs on a.TaxId equals c.TaxId
                           join d in _context.StateTbs on a.StateId equals d.StateId
                           where b.SolarModularCapacity.ToLower().Contains(tax.ToLower())
                           || b.Description.ToLower().Contains(tax.ToLower())
                           || b.HsCode.ToLower().Contains(tax.ToLower())
                           || c.TaxName.ToLower() == tax.ToLower()
                           || c.TaxCode.ToLower() == tax.ToLower()
                           || d.Code.ToLower() == tax.ToLower()
                           || d.StateName.ToLower() == tax.ToLower()
                           || e.CategoryName.ToLower() == tax.ToLower()
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.CategoryName,
                               Classificationid = a.ClassificationId,
                               SolarModularCapacity = b.SolarModularCapacity,
                               Description = b.Description,
                               Illustration = e.ImageUrl,
                               ImageUrl = b.IllustrationUrl,
                               HSCode = b.HsCode,
                               Taxid = c.TaxId,
                               TaxName = c.TaxName,
                               TaxCode = c.TaxCode,
                               Stateid = a.StateId,
                               StateCode = d.Code,
                               StateName = d.StateName,
                               Taxpercentage = a.TaxPercentage
                           };
            return stateTax.ToList();
        }

        public List<StateTaxTreatement> GetMultiStateTaxSearch(string tax)
        {
            IEnumerable<StateTaxTreatement> stateTax;

            string[] words = tax.Split('&');

            if (words[0] != null && words[1] != null && words[2] != null)
            {
                stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.ClassificationId equals b.ClassificationId
                           join e in _context.CategoryTbs on b.CategoryId equals e.CategoryId
                           join c in _context.TaxTbs on a.TaxId equals c.TaxId
                           join d in _context.StateTbs on a.StateId equals d.StateId
                           where b.HsCode.Contains(words[2].ToString())
                           && d.StateId.Contains(words[0].ToString())
                           && c.TaxId.Contains(words[1].ToString())
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.CategoryName,
                               Classificationid = a.ClassificationId,
                               SolarModularCapacity = b.SolarModularCapacity,
                               Description = b.Description,
                               Illustration = e.ImageUrl,
                               ImageUrl = b.IllustrationUrl,
                               HSCode = b.HsCode,
                               Taxid = c.TaxId,
                               TaxName = c.TaxName,
                               TaxCode = c.TaxCode,
                               Stateid = a.StateId,
                               StateCode = d.Code,
                               StateName = d.StateName,
                               Taxpercentage = a.TaxPercentage
                           };
            }
            else 
            {
                stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.ClassificationId equals b.ClassificationId
                           join e in _context.CategoryTbs on b.CategoryId equals e.CategoryId
                           join c in _context.TaxTbs on a.TaxId equals c.TaxId
                           join d in _context.StateTbs on a.StateId equals d.StateId
                           where b.HsCode.Contains(words[2].ToString())
                           || d.StateId.Contains(words[0].ToString())
                           || c.TaxId.Contains(words[1].ToString())
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.CategoryName,
                               Classificationid = a.ClassificationId,
                               SolarModularCapacity = b.SolarModularCapacity,
                               Description = b.Description,
                               Illustration = e.ImageUrl,
                               ImageUrl = b.IllustrationUrl,
                               HSCode = b.HsCode,
                               Taxid = c.TaxId,
                               TaxName = c.TaxName,
                               TaxCode = c.TaxCode,
                               Stateid = a.StateId,
                               StateCode = d.Code,
                               StateName = d.StateName,
                               Taxpercentage = a.TaxPercentage
                           };
            }
                
            
            return stateTax.ToList();
        }
    }
}
