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
using TaxiApp.Repository;
using TaxiApp.Services;

namespace AdminPanel.Views
{
    /// <summary>
    /// Interaction logic for RoutePrice.xaml
    /// </summary>
    public partial class RoutePrice : Page
    {
        public double Price { get; set; }
        public RoutePrice()
        {
            InitializeComponent();
            txbPrice.Text = RoutePriceRepository.GetRoutePrice().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txbPrice.Text != string.Empty)
            {
                //if (txbPrice.Text.Contains("."))
                //{
                //    txbPrice.Text = txbPrice.Text.Replace('.', ',');
                //}
                Price = double.Parse(txbPrice.Text);
                JsonService.WriteToJsonFile(Price, @"../../Resources/RoutePrice.json");
                MessageBox.Show("Save succesfully!", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
                MessageBox.Show("Please enter route price!");
        }
    }
}
