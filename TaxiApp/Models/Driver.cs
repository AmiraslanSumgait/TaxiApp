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
        public int Rating { get; set; }
        public double Balance { get; set; }
        
    }
}
