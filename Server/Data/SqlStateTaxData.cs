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
                           join b in _context.ClassificationTbs on a.Classificationid equals b.Classificationid
                           join e in _context.CategoryTbs on b.Categoryid equals e.Categoryid
                           join c in _context.TaxTbs on a.Taxid equals c.Taxid
                           join d in _context.StateTbs on a.Stateid equals d.Stateid
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.Categoryname,
                               Classificationid = a.Classificationid,
                               SolarModularCapacity = b.Solarmodularcapacity,
                               Description = b.Description,
                               Illustration = e.Imageurl,
                               ImageUrl = b.Illustrationurl,
                               HSCode = b.Hscode,
                               Taxid = c.Taxid,
                               TaxName = c.TaxName,
                               TaxCode = c.Taxcode,
                               Stateid = a.Stateid,
                               StateCode = d.Code,
                               StateName = d.Statename,
                               Taxpercentage = a.Taxpercentage
                           };
            return stateTax.ToList();
        }

        public StateTaxTreatement GetStateTax(string id)
        {
            var stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.Classificationid equals b.Classificationid
                           join e in _context.CategoryTbs on b.Categoryid equals e.Categoryid
                           join c in _context.TaxTbs on a.Taxid equals c.Taxid
                           join d in _context.StateTbs on a.Stateid equals d.Stateid
                           where a.Id == id
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.Categoryname,
                               Classificationid = a.Classificationid,
                               SolarModularCapacity = b.Solarmodularcapacity,
                               Description = b.Description,
                               Illustration = e.Imageurl,
                               ImageUrl = b.Illustrationurl,
                               HSCode = b.Hscode,
                               Taxid = c.Taxid,
                               TaxName = c.TaxName,
                               TaxCode = c.Taxcode,
                               Stateid = a.Stateid,
                               StateCode = d.Code,
                               StateName = d.Statename,
                               Taxpercentage = a.Taxpercentage
                           };
            return stateTax.FirstOrDefault();
        }

        public List<StateTaxTreatement> GetStateTaxSearch(string tax)
        {
            var stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.Classificationid equals b.Classificationid
                           join e in _context.CategoryTbs on b.Categoryid equals e.Categoryid
                           join c in _context.TaxTbs on a.Taxid equals c.Taxid
                           join d in _context.StateTbs on a.Stateid equals d.Stateid
                           where b.Solarmodularcapacity.ToLower().Contains(tax.ToLower())
                           || b.Description.ToLower().Contains(tax.ToLower())
                           || b.Hscode.ToLower().Contains(tax.ToLower())
                           || c.TaxName.ToLower() == tax.ToLower()
                           || c.Taxcode.ToLower() == tax.ToLower()
                           || d.Code.ToLower() == tax.ToLower()
                           || d.Statename.ToLower() == tax.ToLower()
                           || e.Categoryname.ToLower() == tax.ToLower()
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.Categoryname,
                               Classificationid = a.Classificationid,
                               SolarModularCapacity = b.Solarmodularcapacity,
                               Description = b.Description,
                               Illustration = e.Imageurl,
                               ImageUrl = b.Illustrationurl,
                               HSCode = b.Hscode,
                               Taxid = c.Taxid,
                               TaxName = c.TaxName,
                               TaxCode = c.Taxcode,
                               Stateid = a.Stateid,
                               StateCode = d.Code,
                               StateName = d.Statename,
                               Taxpercentage = a.Taxpercentage
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
                           join b in _context.ClassificationTbs on a.Classificationid equals b.Classificationid
                           join e in _context.CategoryTbs on b.Categoryid equals e.Categoryid
                           join c in _context.TaxTbs on a.Taxid equals c.Taxid
                           join d in _context.StateTbs on a.Stateid equals d.Stateid
                           where b.Hscode.Contains(words[2].ToString())
                           && d.Stateid.Contains(words[0].ToString())
                           && c.Taxid.Contains(words[1].ToString())
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.Categoryname,
                               Classificationid = a.Classificationid,
                               SolarModularCapacity = b.Solarmodularcapacity,
                               Description = b.Description,
                               Illustration = e.Imageurl,
                               ImageUrl = b.Illustrationurl,
                               HSCode = b.Hscode,
                               Taxid = c.Taxid,
                               TaxName = c.TaxName,
                               TaxCode = c.Taxcode,
                               Stateid = a.Stateid,
                               StateCode = d.Code,
                               StateName = d.Statename,
                               Taxpercentage = a.Taxpercentage
                           };
            }
            else 
            {
                stateTax = from a in _context.TaxTreatementTbs
                           join b in _context.ClassificationTbs on a.Classificationid equals b.Classificationid
                           join e in _context.CategoryTbs on b.Categoryid equals e.Categoryid
                           join c in _context.TaxTbs on a.Taxid equals c.Taxid
                           join d in _context.StateTbs on a.Stateid equals d.Stateid
                           where b.Hscode.Contains(words[2].ToString())
                           || d.Stateid.Contains(words[0].ToString())
                           || c.Taxid.Contains(words[1].ToString())
                           select new StateTaxTreatement()
                           {
                               Id = a.Id,
                               CategoryName = e.Categoryname,
                               Classificationid = a.Classificationid,
                               SolarModularCapacity = b.Solarmodularcapacity,
                               Description = b.Description,
                               Illustration = e.Imageurl,
                               ImageUrl = b.Illustrationurl,
                               HSCode = b.Hscode,
                               Taxid = c.Taxid,
                               TaxName = c.TaxName,
                               TaxCode = c.Taxcode,
                               Stateid = a.Stateid,
                               StateCode = d.Code,
                               StateName = d.Statename,
                               Taxpercentage = a.Taxpercentage
                           };
            }
                
            
            return stateTax.ToList();
        }
    }
}
