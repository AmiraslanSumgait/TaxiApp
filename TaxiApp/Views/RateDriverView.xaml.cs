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
using TaxiApp.ViewModels;

namespace TaxiApp.Views
{
    /// <summary>
    /// Interaction logic for RateDriverView.xaml
    /// </summary>
    public partial class RateDriverView : Window
    {
        public RateDriverViewModel RateDriverViewModel { get; set; }
        public RateDriverView()
        {
            try
            {
                InitializeComponent();
                RateDriverViewModel = new RateDriverViewModel(this);
                DataContext = RateDriverViewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            RateDriverViewModel.RatingValue = RatingBar.Value;
        }
    }
}
