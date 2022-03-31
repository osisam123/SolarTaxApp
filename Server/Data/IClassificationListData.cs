using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface IClassificationListData
    {
        public List<ClassificationList> GetActualClassification();

        public ClassificationList GetActualClassification(string id);
    }
}
