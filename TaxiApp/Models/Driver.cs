using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Driver : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public double Rating { get; set; }
        public double Balance { get; set; }
        public string CarGraphic { get; set; }
        public int RouteCount { get; set; } = 0;
        public double RatingAll { get; set; } = 0;

    }
}
