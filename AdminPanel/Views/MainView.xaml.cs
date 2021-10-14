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
using System.Windows.Shapes;

namespace AdminPanel.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

       

        


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        private void Drivers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame.Content = new DriversListPage();
        }

        private void Rides_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame.Content = new RoutePrice();
        }
    }
}
