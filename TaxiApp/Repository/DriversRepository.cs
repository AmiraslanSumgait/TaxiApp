using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TaxiApp.Models;

namespace TaxiApp.Repository
{
    public class DriversRepository
    {
        public static ObservableCollection<Driver> GetAllDrivers()
        {
            ObservableCollection<Driver> Drivers;
            //var json = File.ReadAllText("../../Resources/Drivers.json"); 
            var json = File.ReadAllText(@"C:\Users\Amiraslan\source\repos\TaxiApp\TaxiApp\Resources\Drivers.json"); 
              Drivers = JsonSerializer.Deserialize<ObservableCollection<Driver>>(json);
            return Drivers;
        }

    }
}
