using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Models
{
    public class Ridehistory
    {
        public string ForUsername { get; set; }
        public string YourLocation { get; set; }
        public string Destination { get; set; }
        public double Payment { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Your location->{YourLocation} Destination->{Destination} Payment->{Payment} DatTime->{Date.ToString("dddd, dd MMMM yyyy HH:mm")}";
        }
    }
}
