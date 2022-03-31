using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class ActualClassification
    {
        public string Classificationid { get; set; }
        public string Categoryid { get; set; }
        public string Category { get; set; }
        public string Hscode { get; set; }
        public string Solarmodularcapacity { get; set; }
        public string Description { get; set; }
        public string Illustrationurl { get; set; }

        public static implicit operator ActualClassification(ClassificationList classification)
        {
            return new ClassificationList
            {
                CategoryId = classification.CategoryId,
                Category = classification.Category,
                ClassificationId = classification.ClassificationId,
                Solarmodularcapacity = classification.Solarmodularcapacity,
                Description = classification.Description,
                Hscode = classification.Hscode,
                Illustrationurl = classification.Illustrationurl
            };
        }

        public static implicit operator ClassificationList(ActualClassification classification)
        {
            return new ClassificationList
            {
                CategoryId = classification.Categoryid,
                Category = classification.Category,
                ClassificationId = classification.Classificationid,
                Solarmodularcapacity = classification.Solarmodularcapacity,
                Description = classification.Description,
                Hscode = classification.Hscode,
                Illustrationurl = classification.Illustrationurl
            };
        }
    }
}
