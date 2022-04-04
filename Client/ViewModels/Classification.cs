using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class Classification
    {
        public string Classificationid { get; set; }
        public string Categoryid { get; set; }
        public string Hscode { get; set; }
        public string Solarmodularcapacity { get; set; }
        public string Description { get; set; }
        public string Illustrationurl { get; set; }

        public static implicit operator Classification(ClassificationTb classification)
        {
            return new Classification
            {
                Categoryid = classification.Categoryid,
                Classificationid = classification.Classificationid,
                Solarmodularcapacity = classification.Solarmodularcapacity,
                Description = classification.Description,
                Hscode = classification.Hscode,
                Illustrationurl  = classification.Illustrationurl
            };
        }

        public static implicit operator ClassificationTb(Classification classification)
        {
            return new ClassificationTb
            {
                Categoryid = classification.Categoryid,
                Classificationid = classification.Classificationid,
                Solarmodularcapacity = classification.Solarmodularcapacity,
                Description = classification.Description,
                Hscode = classification.Hscode,
                Illustrationurl = classification.Illustrationurl
            };
        }
    }
}
