using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaxiApp.Models;

namespace AdminPanel.Views
{
    /// <summary>
    /// Interaction logic for DriversListPage.xaml
    /// </summary>
    public partial class DriversListPage : Page
    {
        public ObservableCollection<Driver> Drivers { get; set; }
        public DriversListPage()
        {
            InitializeComponent();
            DataContext = this;
            Drivers = new ObservableCollection<Driver>
            {
                new Driver
                {
                    Balance = 30,
                    CarNumber = "35NN270",
                    CarModel="Bmw X5 ",
                    Name="Nebi",
                    Rating=4,
                    Surname="Nebili"
                },
                new Driver
                { 
                    Balance = 120,
                    CarNumber = "99KK444",
                    CarModel="Bmw M5",
                    Name="Kenan",
                    Rating=5,
                    Surname="Idayatov"
                },
                new Driver
                {
                    Balance = 223,
                    CarNumber = "99EC255",
                    CarModel="Hyundai I30",
                    Name="Hörmət",
                    Rating=4,
                    Surname="Həmidov"
                },
                new Driver
                {
                    Balance = 110,
                    CarNumber = "99AC190",
                    CarModel="Nissa Juke",
                    Name="Fərid",
                    Rating=3,
                    Surname="Abizadə"
                },
                new Driver
                {
                    Balance = 40,
                    CarNumber = "20KE222",
                    CarModel="Opel Zafira",
                    Name="Raul",
                    Rating=4,
                    Surname="Qasimov"
                },
                new Driver
                {
                    Balance = 40,
                    CarNumber = "50YP755",
                    CarModel="Vaz2107",
                    Name="Ramin",
                    Rating=4,
                    Surname="Abdullayev"
                },
                new Driver
                {
                    Balance = 40,
                    CarNumber = "99ZZ44",
                    CarModel="Toyato Prado",
                    Name="Kamal",
                    Rating=4,
                    Surname="Əliyev"
                },
                   new Driver
                {
                    Balance = 40,
                    CarNumber = "99ZZ44",
                    CarModel="Toyato aaa",
                    Name="Kamal",
                    Rating=4,
                    Surname="Əliyev"
                },

            };
        }
    }
}
