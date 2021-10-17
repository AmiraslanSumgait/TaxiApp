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
using TaxiApp.ViewModels;

namespace TaxiApp.Views
{
    /// <summary>
    /// Interaction logic for InfoDestinationUC.xaml
    /// </summary>
    public partial class InfoDestinationUC : UserControl
    {
        public InfoDestinationViewModel infoDestinationViewModel { get; set; }
        public InfoDestinationUC()
        {
            try
            {
                InitializeComponent();
                infoDestinationViewModel = new InfoDestinationViewModel(this);
                DataContext = infoDestinationViewModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
