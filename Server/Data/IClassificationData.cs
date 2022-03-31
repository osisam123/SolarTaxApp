using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface IClassificationData
    {
        List<ClassificationTb> GetClassification();
        ClassificationTb GetClassification(string id);
        ClassificationTb AddClassification(ClassificationTb classification);
        ClassificationTb EditClassification(ClassificationTb classification);
        void DeleteClassification(ClassificationTb classification);
    }
}
