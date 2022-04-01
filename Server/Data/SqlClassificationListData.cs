using SolarTaxApp.Server.Models;
using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlClassificationListData : IClassificationListData
    {
        SolarTaxationDBContext _context;
        public SqlClassificationListData(SolarTaxationDBContext context)
        {
            _context = context;
        }
        public List<ClassificationList> GetActualClassification()
        {
            var classlist = from a in _context.ClassificationTbs
                            join b in _context.CategoryTbs
                            on a.Categoryid equals b.Categoryid
                            select new ClassificationList()
                            {
                                ClassificationId = a.Classificationid,
                                CategoryId = a.Categoryid,
                                Category = b.Categoryname,
                                Solarmodularcapacity = a.Solarmodularcapacity,
                                Hscode = a.Hscode,
                                Description = a.Description,
                                Illustrationurl = a.Illustrationurl                                
                            };
            return classlist.ToList();
        }

        public ClassificationList GetActualClassification(string id)
        {
            var classlist = from a in _context.ClassificationTbs
                            join b in _context.CategoryTbs
                            on a.Categoryid equals b.Categoryid
                            where a.Classificationid == id
                            select new ClassificationList()
                            {
                                ClassificationId = a.Classificationid,
                                CategoryId = a.Categoryid,
                                Category = b.Categoryname,
                                Solarmodularcapacity = a.Solarmodularcapacity,
                                Hscode = a.Hscode,
                                Description = a.Description,
                                Illustrationurl = a.Illustrationurl
                            };
            return classlist.FirstOrDefault();
        }
    }
}
