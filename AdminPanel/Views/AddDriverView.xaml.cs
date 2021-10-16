using AdminPanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Shapes;
using TaxiApp;
using TaxiApp.Models;

namespace AdminPanel.Views
{
    /// <summary>
    /// Interaction logic for AddDriverView.xaml
    /// </summary>
    public partial class AddDriverView : Window
    {
        public AddDriverViewModel AddDriverViewModel { get; set; }

        public AddDriverView(ObservableCollection<Driver> drivers)
        {
            InitializeComponent();
            AddDriverViewModel = new AddDriverViewModel(this, drivers);
            DataContext = AddDriverViewModel;
        }

    }
}
