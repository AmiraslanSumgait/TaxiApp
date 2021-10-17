using AdminPanel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaxiApp.Command;
using TaxiApp.Models;
using TaxiApp.Services;

namespace AdminPanel.ViewModels
{
    public class DriversListViewModel
    {
        public DriversListPage DriversListPage { get; set; }

        public ObservableCollection<Driver> Drivers { get; set; }
        public ObservableCollection<Driver> TempDrivers { get; set; }

        public RelayCommandMain RemoveDriverCommand { get; set; }
        public RelayCommandMain AddDriverCommand { get; set; }

        public DriversListViewModel(DriversListPage driversListPage)
        {
            DriversListPage = driversListPage;
            DriversListPage.txbSearch.TextChanged += SearchTextBox_Changed;

            RemoveDriverCommand = new RelayCommandMain(
                action => RemoveButton_Click(),
                pre => true);

            AddDriverCommand = new RelayCommandMain(
                action => AddButton_Click(),
                pre => true);


            Drivers = new ObservableCollection<Driver>
            {
                new Driver
                {
                    Balance = 30,
                    CarNumber = "35-NN-270",
                    CarModel="Bmw X5 ",
                    Name="Nebi",
                    Rating=4,
                    Surname="Nebili"
                },
                new Driver
                {
                    Balance = 120,
                    CarNumber = "99-KK-444",
                    CarModel="Bmw M5",
                    Name="Kenan",
                    Rating=5,
                    Surname="Idayatov"
                },
                new Driver
                {
                    Balance = 223,
                    CarNumber = "99-EC-255",
                    CarModel="Hyundai I30",
                    Name="Hörmət",
                    Rating=4,
                    Surname="Həmidov"
                },
                new Driver
                {
                    Balance = 110,
                    CarNumber = "99-AC-190",
                    CarModel="Nissa Juke",
                    Name="Fərid",
                    Rating=3,
                    Surname="Abizadə"
                },
                new Driver
                {
                    Balance = 40,
                    CarNumber = "20-KE-222",
                    CarModel="Opel Zafira",
                    Name="Raul",
                    Rating=4,
                    Surname="Qasimov"
                },
                new Driver
                {
                    Balance = 40,
                    CarNumber = "50-YP-755",
                    CarModel="Vaz2107",
                    Name="Ramin",
                    Rating=4,
                    Surname="Abdullayev"
                },
                new Driver
                {
                    Balance = 40,
                    CarNumber = "99-ZZ-044",
                    CarModel="Toyato Prado",
                    Name="Kamal",
                    Rating=4,
                    Surname="Əliyev"
                }

            };

            TempDrivers = Drivers;

        }

        private void RemoveButton_Click()
        {
            var removeDriver = DriversListPage.lbDrivers.SelectedItem as Driver;
            Drivers.Remove(removeDriver);
        }

        private void SearchTextBox_Changed(object sender, TextChangedEventArgs e)
        {
            if (DriversListPage.txbSearch.Text.Length != 0)
            {
                var searchText = DriversListPage.txbSearch.Text.ToLower();
                List<Driver> driversList = new List<Driver>();
                driversList = TempDrivers.Where(d => d.Name.ToLower().StartsWith(searchText)).ToList();
                ObservableCollection<Driver> newList = new ObservableCollection<Driver>(driversList);
                Drivers = newList;
                DriversListPage.lbDrivers.ItemsSource = newList;

            }
            else if (DriversListPage.txbSearch.Text.Length == 0)
            {
                Drivers = TempDrivers;
                DriversListPage.lbDrivers.ItemsSource = Drivers;
            }
        }

        private void AddButton_Click()
        {
            AddDriverView addDriverView = new AddDriverView(Drivers);
            addDriverView.ShowDialog();
        }
    }
}
