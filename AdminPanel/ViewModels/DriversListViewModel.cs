using AdminPanel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaxiApp.Command;
using TaxiApp.Models;
using TaxiApp.Repository;
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

            Drivers = DriversRepository.GetAllDrivers();
            TempDrivers = Drivers;
            // Drivers list sort
            DriversListPage.lbDrivers.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

        }

        private void RemoveButton_Click()
        {
            var removeDriver = DriversListPage.lbDrivers.SelectedItem as Driver;
            Drivers.Remove(removeDriver);
            JsonService.WriteToJsonFile(Drivers, @"C:\Users\Amiraslan\source\repos\TaxiApp\TaxiApp\Resources\Drivers.json");
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
