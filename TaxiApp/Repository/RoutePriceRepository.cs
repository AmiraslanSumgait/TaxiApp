using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaxiApp.Repository
{
    public class RoutePriceRepository
    {
        public static double GetRoutePrice()
        {
            double RoutePrice;
            //var json = File.ReadAllText("../../Resources/RideHistory.json");
            var json = File.ReadAllText(@"C:\Users\Amiraslan\source\repos\TaxiApp\AdminPanel\Resources\RoutePrice.json");
            RoutePrice = JsonSerializer.Deserialize<double>(json);

            return RoutePrice;
        }
    }
}
