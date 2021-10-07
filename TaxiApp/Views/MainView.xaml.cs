using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Navigation;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Device.Location;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public partial class MainView : Window
    {
<<<<<<< HEAD

        public MainViewModel MainViewModel { get; set; }
        public MainView()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel(MyMapView, StartNavigationButton, RecenterButton, SearchAddressButton, AddressTextBox, MessagesTextBlock, ExitAppButton, this);

        }

=======
        public MainView()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel(MyMapView, StartNavigationButton, RecenterButton,SearchAddressButton, AddressTextBox, MessagesTextBlock,this);
        }
>>>>>>> a7fc0c65240d445a3821ec1c6987798b1db0a80e
    }
}
