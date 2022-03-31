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
                            on a.CategoryId equals b.CategoryId
                            select new ClassificationList()
                            {
                                ClassificationId = a.ClassificationId,
                                CategoryId = a.CategoryId,
                                Category = b.CategoryName,
                                Solarmodularcapacity = a.SolarModularCapacity,
                                Hscode = a.HsCode,
                                Description = a.Description,
                                Illustrationurl = a.IllustrationUrl                                
                            };
            return classlist.ToList();
        }

        public ClassificationList GetActualClassification(string id)
        {
            var classlist = from a in _context.ClassificationTbs
                            join b in _context.CategoryTbs
                            on a.CategoryId equals b.CategoryId
                            where a.ClassificationId == id
                            select new ClassificationList()
                            {
                                ClassificationId = a.ClassificationId,
                                CategoryId = a.CategoryId,
                                Category = b.CategoryName,
                                Solarmodularcapacity = a.SolarModularCapacity,
                                Hscode = a.HsCode,
                                Description = a.Description,
                                Illustrationurl = a.IllustrationUrl
                            };
            return classlist.FirstOrDefault();
        }
    }
}
