using AdminPanel.ViewModels;
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
        public DriversListViewModel DriversListViewModel { get; set; }
        public DriversListPage()
        {
            InitializeComponent();
            DriversListViewModel = new DriversListViewModel(this);
            DataContext = DriversListViewModel;
        }
    }
}
