using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlClassificationData : IClassificationData
    {
        SolarTaxationDBContext _context;
        public SqlClassificationData(SolarTaxationDBContext context)
        {
            _context = context;
        }
        public ClassificationTb AddClassification(ClassificationTb classification)
        {
            classification.Classificationid = Guid.NewGuid().ToString();
            _context.ClassificationTbs.Add(classification);
            _context.SaveChanges();
            return classification;
        }

        public void DeleteClassification(ClassificationTb classification)
        {
            _context.ClassificationTbs.Remove(classification);
            _context.SaveChanges();
        }

        public ClassificationTb EditClassification(ClassificationTb classification)
        {
            var existingClassification = _context.ClassificationTbs.Find(classification.Classificationid);
            if (existingClassification != null)
            {
                existingClassification.Categoryid = classification.Categoryid;
                existingClassification.Solarmodularcapacity = classification.Solarmodularcapacity;
                existingClassification.Description = classification.Description;
                existingClassification.Illustrationurl = classification.Illustrationurl;
                existingClassification.Hscode = classification.Hscode;
                _context.ClassificationTbs.Update(existingClassification);
                _context.SaveChanges();
            }
            return classification;
        }

        public List<ClassificationTb> GetClassification()
        {
            return _context.ClassificationTbs.ToList();
        }

        public ClassificationTb GetClassification(string id)
        {
            var classification = _context.ClassificationTbs.Find(id);
            return classification;
        }
    }
}
