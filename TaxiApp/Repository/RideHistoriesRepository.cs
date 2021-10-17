using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaxiApp.Models;

namespace TaxiApp.Repository
{
    public class RideHistoriesRepository
    {
        public static List<Ridehistory> GetAllRideHistories()
        {
            List<Ridehistory> Ridehistories;
            //var json = File.ReadAllText("../../Resources/RideHistory.json");
            var json = File.ReadAllText(@"C:\Users\user\source\repos\TaxiApp\TaxiApp\Resources\RideHistory.json");
            Ridehistories = JsonSerializer.Deserialize<List<Ridehistory>>(json);

            return Ridehistories;
        }
    }
}
