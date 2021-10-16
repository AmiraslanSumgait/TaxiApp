using AdminPanel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaxiApp;
using TaxiApp.Command;
using TaxiApp.Models;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace AdminPanel.ViewModels
{
    public class AddDriverViewModel
    {
        public AddDriverView AddDriverView { get; set; }

        private ObservableCollection<Driver> _drivers = new ObservableCollection<Driver>();

        public RelayCommandMain AddDriverCommand { get; set; }
        public RelayCommandMain CloseCommand { get; set; }

        public AddDriverViewModel(AddDriverView addDriverView, ObservableCollection<Driver> drivers)
        {
            AddDriverView = addDriverView;
            _drivers = drivers;

            AddDriverCommand = new RelayCommandMain(
                action => AddDriverButton_Click(),
                Predicate => true);

            CloseCommand = new RelayCommandMain(
                action => AddDriverView.Close(),
                Predicate => true);
        }

        private void AddDriverButton_Click()
        {
            if (ErrorService.IsError != true)
            {
                Driver driver = new Driver
                {
                    Name = AddDriverView.tbName.Text,
                    Surname = AddDriverView.tbSurname.Text,
                    CarNumber = AddDriverView.tbCarNumber.Text,
                    CarModel = AddDriverView.tbCarModel.Text
                };
                AddDriverView.tbCarNumber.Text = AddDriverView.tbCarNumber.Text.Insert(2, "-");
                AddDriverView.tbCarNumber.Text = AddDriverView.tbCarNumber.Text.Insert(5, "-");
                driver.CarNumber = AddDriverView.tbCarNumber.Text;
                if (!_drivers.Any(d => d.CarNumber == driver.CarNumber))
                {
                    driver.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(driver.Name.ToLower());
                    driver.Surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(driver.Surname.ToLower());
                    _drivers.Add(driver);
                    AddDriverView.Close();
                }
                else
                {
                    AddDriverView.tbCarNumber.Text = AddDriverView.tbCarNumber.Text.Remove(2, 1);
                    AddDriverView.tbCarNumber.Text = AddDriverView.tbCarNumber.Text.Remove(4, 1);
                    notifier.ShowWarning("This car number is already available!");
                }
            }
            else if (AddDriverView.tbName.Text == ""
                    || AddDriverView.tbSurname.Text == ""
                    || AddDriverView.tbCarModel.Text == ""
                    || AddDriverView.tbCarNumber.Text == "")
            {
                notifier.ShowInformation("Please fill in the information completely.");
            }
            else
            {
                notifier.ShowWarning("Please enter the information correctly.");
            }
        }

        #region Create notifier
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 5,
                offsetY: 5);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2),
                maximumNotificationCount: MaximumNotificationCount.FromCount(2));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        #endregion
    }
}
