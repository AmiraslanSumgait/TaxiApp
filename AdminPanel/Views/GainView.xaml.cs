using System;
using System.Collections.Generic;
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
using TaxiApp.Repository;

namespace AdminPanel.Views
{
    /// <summary>
    /// Interaction logic for GainView.xaml
    /// </summary>
    public partial class GainView : Page
    {
        public List<Ridehistory> RideHistories { get; set; }
        public double AllProfit { get; set; }
        public GainView()
        {
            InitializeComponent();
            RideHistories = RideHistoriesRepository.GetAllRideHistories();
            RideHistories.ForEach(r => AllProfit += r.Payment);
            var original = AllProfit;
            AllProfit = Math.Truncate(original * 100) / 100;
            textAllProfit.Text = AllProfit.ToString() + " AZN";
        }
    }
}
